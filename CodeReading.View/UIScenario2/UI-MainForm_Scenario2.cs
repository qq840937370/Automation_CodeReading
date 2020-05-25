using CodeReading.Entity;
using CodeReading.Entity.MainForm;
using CodeReading.View.BLL.HalconHelper;
using CodeReading.View.DAL;
//using CodeReading.View.MainFormServiceReference;
using HalconDotNet;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CodeReading.View
{
    public partial class UI_MainForm_Scenario2 : Form
    {
        #region 全局变量

        // 已扫描文件个数
        int ImgNumber = 0;
        // 实时影像Thread
        Thread openThread = null;
        // 数据处理Thread
        Thread dataProcessingThread = null;
        // 相机参数Thread
        Thread camerarfsThread;

        // 相机句柄
        HTuple hv_AcqHandle = null;
        // halcon控件-实时影像
        HTuple rtaHalconWin;
        // halcon控件-处理结果
        HTuple icsHalconWin;

        // 图像宽高变量,平均值，方差
        HTuple hv_Mean = null, hv_Deviation = null;
        //rdo
        string KindOfPicture = "";
        #endregion

        #region 实例化对象
        // 实例化MainFormBLL对象
        MainFormBLL mainFormBLL = new MainFormBLL();
        // 全局UsedInfo数据
        UsedInfo usedInfodata = new UsedInfo();
        // 识别
        HalconHelpers halconHelpers = new HalconHelpers();

        /// <summary>
        /// 当前扫描数据区域显示用 SHIL数据表
        /// </summary>
        private MainFormDataSet.SHILDataTable CurrentDataSHIL = new MainFormDataSet.SHILDataTable();

        /// <summary>
        /// 当前扫描数据区域显示用 CWDL数据表
        /// </summary>
        private MainFormDataSet.CWDLDataTable CurrentDataCWDL = new MainFormDataSet.CWDLDataTable();

        /// <summary>
        /// 当前扫描数据区域显示用 HNCL数据表
        /// </summary>
        private MainFormDataSet.HNCLDataTable CurrentDataHNCL = new MainFormDataSet.HNCLDataTable();

        #endregion

        /// <summary>
        /// Win加载起点
        /// </summary>
        public UI_MainForm_Scenario2()
        {
            InitializeComponent();
            rtaHalconWin = hWinctl_RTA.HalconWindow;
            icsHalconWin = hWinctl_ICS.HalconWindow;
        }

        /// <summary>
        /// Win加载起点
        /// </summary>
        /// <param name="uname"></param>
        public UI_MainForm_Scenario2(string uname)
        {
            InitializeComponent();
            rtaHalconWin = hWinctl_RTA.HalconWindow;
            icsHalconWin = hWinctl_ICS.HalconWindow;
        }
        /// <summary>
        /// 窗口登陆事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_MainForm_Scenario2_Load(object sender, EventArgs e)
        {
            // 右下角时间显示
            timer_Now.Start();
            // 扫描张数
            //Thread imgNumb = new Thread(ImgNumb);
            //imgNumb.Start();
        }
        #region 最大化最小化关闭按钮
        /// <summary>
        /// 最小化按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picBox_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// 最大化按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picBox_Max_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }

        }
        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picBox_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();          // 退出应用
            System.Environment.Exit(1);  // 终止此应用进程
        }
        #endregion
        #region 窗体移动
        private Point mPoint;
        /// <summary>
        /// 鼠标按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnl_Head_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }
        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnl_Head_MouseMove(object sender, MouseEventArgs e)
        {

        }
        #endregion
        #region 实时显示内容
        /// <summary>
        /// 右下角时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Now_Tick(object sender, EventArgs e)
        {
            DateTime dtnow = System.DateTime.Now;
            tslbl_Time.Text = dtnow.ToString();
        }
        /// <summary>
        /// 扫描张数,相机速率
        /// </summary>
        private void ImgNumb()
        {
            int i = 1;
            while (i > 0)
            {
                UsedInfo usedInfo = new UsedInfo();
                tssl_ImgNumber.Text = "已扫描文件：" + usedInfo.ImgCount.ToString() + "个";
                Thread.SpinWait(3000);
            }
        }
        #endregion
        #region TSMI按钮
        /// <summary>
        /// 系统信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_About_Click(object sender, EventArgs e)
        {
            UI_About_Scenario2 aboutForm = new UI_About_Scenario2();
            aboutForm.ShowDialog();
        }
        /// <summary>
        /// 扫描历史
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_History_Click(object sender, EventArgs e)
        {
            UI_History_Scenario2 historyForm = new UI_History_Scenario2();
            historyForm.ShowDialog();
        }
        /// <summary>
        /// 自动捕捉按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_Auto_Click(object sender, EventArgs e)
        {
            bool imgAutoCheck = tsmi_Auto.Checked;
            if (mainFormBLL.ImgAutobll(imgAutoCheck) == true)
            {
                tsmi_Auto.Checked = true;
            }
            else if (mainFormBLL.ImgAutobll(imgAutoCheck) == false)
            {
                tsmi_Auto.Checked = false;
            }
        }
        /// <summary>
        /// 登陆按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_Login_Click(object sender, EventArgs e)
        {
            this.Hide();
            UI_Login_Scenario2 ui_Login_Scenario2 = new UI_Login_Scenario2();
            ui_Login_Scenario2.Show();
        }
        /// <summary>
        /// 离开按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_Logout_Click(object sender, EventArgs e)
        {
            LoginInfo.state = LoginState.未登录;
            this.Hide();
            UI_Login_Scenario2 ui_Login_Scenario2 = new UI_Login_Scenario2();
            ui_Login_Scenario2.Show();
        }
        #endregion

        #region 打开相机处理
        /// <summary>
        /// 打开相机按钮压下
        /// </summary>
        private void tsmi_OpenCamera_Click(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            // 相机线程
            openThread = new Thread( new ThreadStart(OpenThread));
            openThread.Start();
            //Thread.Sleep(5000);
            //DataProcessing();
            // 数据处理
            dataProcessingThread = new Thread(new ThreadStart(DataProcessing));
            dataProcessingThread.Start();
        }
        /// <summary>
        /// 实时影像Thread
        /// </summary>
        private void OpenThread()
        {
            try
            {
                // 识图
                if (AutoT.state == AutoTState.AT)
                {

                    // 自动识图方法-返回
                    halconHelpers.AutomaticMapRecognitionMethod(rtaHalconWin, icsHalconWin,out UsedInfo usedInfo);
                    //AutomaticMapRecognitionMethod(rtaHalconWin, icsHalconWin, out UsedInfo usedInfo);

                }
            }
            catch (HalconException halExp)
            {
                MessageBox.Show("图像处理信息获取失败！" + halExp.GetErrorCode() +halExp.GetErrorMessage());
                tssl_CameraStatus.Text = "扫描信息异常";
            }
        }

        /// <summary>
        /// 自动识图假方法
        /// </summary>
        /// <param name="rtaHalconWin"> halcon控件-实时影像</param>
        /// <param name="icsHalconWin"> halcon控件-处理结果</param>
        /// <param name="usedInfo"> 返回的信息类 </param>
        private void AutomaticMapRecognitionMethod(HTuple rtaHalconWin, HTuple icsHalconWin, out UsedInfo usedInfo)
        {
            // 返回值初始化
            var result = new UsedInfo();
            result.DbId = "1SHIL";
            result.OtherID = "6527815";
            result.Sign = "1";
            result.TagCode = "110112572371,110112572370,110112572373,110112572375,110112572374,110112572368,110112572369,110112572367,110112572372,";
            #region
            // 释放相机句柄
            HOperatorSet.CloseAllFramegrabbers();
            // 连接相机
            HOperatorSet.OpenFramegrabber("GigEVision2", 0, 0, 0, 0, 0, 0, "progressive",
        -1, "default", -1, "false", "default", "c42f90f2b7fa_Hikvision_MVCE12010GM",
        0, -1, out hv_AcqHandle);
            HObject ho_Image = null;
            HOperatorSet.GenEmptyObj(out ho_Image);

            ho_Image.Dispose();
            HOperatorSet.GrabImage(out ho_Image, hv_AcqHandle);
            #endregion
            result.HImg = ho_Image;
            usedInfo = result;
        }

        /// <summary>
        /// 数据处理(查数据 比对数据 保存数据)
        /// </summary>
        public void DataProcessing()
        {
            Thread.Sleep(5000);
            while (1 == 1)
            {
                // 识图
                if (AutoT.state == AutoTState.AT)
                {
                    // 全局usedInfodata赋值
                    usedInfodata.DbId = halconHelpers.usedInfoDbId;         // 表类别
                    usedInfodata.OtherID = halconHelpers.usedInfoOtherID;   // 模拟主键
                    usedInfodata.Sign = halconHelpers.usedInfoSign;         // 签字
                    usedInfodata.TagCode = halconHelpers.usedInfoTagCode;   // 条形码
                    usedInfodata.HImg = halconHelpers.usedInfoHImg;         // HObject图片
                                                                            // 查数据
                    SelectData();

                    // 比对数据
                    DataCheck();
                    Thread.Sleep(3000);
                }
            }
        }
        MainFormDAL mainFormDAL = new MainFormDAL();
        /// <summary>
        /// 查数据
        /// </summary>
        /// <returns></returns>
        private void SelectData()
        {
            // 获取数据
            //var client = new MainFormServiceClient();
            // 如果是1SHIL
            if (usedInfodata.DbId== "1SHIL")
            {
                var result = new DataSHIL();
                //result = client.dataSHIL(usedInfodata);
                result = mainFormDAL.dataSHIL(usedInfodata);
                // 検索結果件数判定
                if (result.DataTable.Rows.Count == 0)
                {
                    //MessageBox.Show(" 数据表里没有该条数据 或 表污损严重！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    // 把扫描到的数据绘制到"当前扫描数据区域"并表底颜色标红
                }
                else
                {
                    // 绘制到"当前扫描数据区域"
                    CurrentDataSHIL = result.DataTable;
                    //bds_CumulativeData.DataSource = CurrentDataSHIL;
                    //dgv_CumulativeData.DataSource = bds_CumulativeData;
                }
            }
            // 如果是2HNCL
            else if (usedInfodata.DbId == "2HNCL")
            {
                var result = new DataHNCL();
                //result = client.dataHNCL(usedInfodata);
            }
            // 如果是3CWDL
            else if (usedInfodata.DbId == "3CWDL")
            {
                var result = new DataCWDL();
                //result = client.dataCWDL(usedInfodata);
            }
        }

        /// <summary>
        /// 比对数据
        /// </summary>
        private void DataCheck()
        {
            //对比结果
            int i = 1;
            // 比对结果
            if (i == 1)
            {
                //DataGridView1.RowsDefaultCellStyle.BackColor = Color.Yellow;         // 所有
                //DataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.Aqua;    // 列
                //DataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.LightGray;  // 行
                //DataGridView1[0, 0].Style.BackColor = Color.Pink;                    // 某个单元格
                //try
                //{
                // 赋值
                usedInfodata.Pass = "1";
                string ScanDate = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                usedInfodata.ScanDate = ScanDate;                     // 日期
                usedInfodata.FileName = ScanDate + ".bmp";            // 图片名
                                                                      // 保存数据
                mainFormBLL.CaptureImgbll(usedInfodata);
                #region 显示数据
                // 显示相机获取的数据-绿色
                dgv_CurrentData.Rows.Clear();
                DataGridViewRow Row = new DataGridViewRow();
                int RowCurindex = dgv_CurrentData.Rows.Add(Row);
                dgv_CurrentData.Rows[RowCurindex].Cells["ScanDate"].Value = usedInfodata.ScanDate;
                dgv_CurrentData.Rows[RowCurindex].Cells["DbId"].Value = usedInfodata.DbId;
                dgv_CurrentData.Rows[RowCurindex].Cells["OtherID"].Value = usedInfodata.OtherID;
                dgv_CurrentData.Rows[RowCurindex].Cells["TagCode"].Value = usedInfodata.TagCode;
                dgv_CurrentData.Rows[RowCurindex].Cells["Sign"].Value = usedInfodata.Sign;
                dgv_CurrentData.Rows[RowCurindex].Cells["Pass"].Value = usedInfodata.Pass;
                dgv_CurrentData.Rows[RowCurindex].Cells["FileName"].Value = usedInfodata.FileName;
                dgv_CurrentData.Rows[RowCurindex].DefaultCellStyle.BackColor = Color.GreenYellow;       // 整行绿
                // 添加到记录栏-绿色
                DataGridViewRow CumRow = new DataGridViewRow();
                dgv_CumulativeData.Rows.Add(CumRow);
                int RowCumindex = dgv_CumulativeData.Rows.Count - 1;
                dgv_CumulativeData.Rows[RowCumindex].Cells["hisyScanDate"].Value = usedInfodata.ScanDate;
                dgv_CumulativeData.Rows[RowCumindex].Cells["hisyDbId"].Value = usedInfodata.DbId;
                dgv_CumulativeData.Rows[RowCumindex].Cells["hisyOtherID"].Value = usedInfodata.OtherID;
                dgv_CumulativeData.Rows[RowCumindex].Cells["hisyTagCode"].Value = usedInfodata.TagCode;
                dgv_CumulativeData.Rows[RowCumindex].Cells["hisySign"].Value = usedInfodata.Sign;
                dgv_CumulativeData.Rows[RowCumindex].Cells["hisyPass"].Value = usedInfodata.Pass;
                dgv_CumulativeData.Rows[RowCumindex].Cells["hisyFileName"].Value = usedInfodata.FileName;
                #endregion

                // 已扫描文件个数
                ImgNumber = ImgNumber + 1;  //已扫描文件：0个

                tssl_ImgNumber.Text = "已扫描文件：" + ImgNumber + "个";
            }
            else if (i != 1)
            {
                // 赋值
                usedInfodata.Pass = "0";
                string ScanDate = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                usedInfodata.ScanDate = ScanDate;                     // 日期
                usedInfodata.FileName = ScanDate + ".bmp";            // 图片名

                // 显示相机获取的数据-红色
                dgv_CurrentData.Rows.Clear();
                DataGridViewRow Row = new DataGridViewRow();
                int RowCurindex = dgv_CurrentData.Rows.Add(Row);
                dgv_CurrentData.Rows[RowCurindex].Cells["ScanDate"].Value = usedInfodata.ScanDate;
                dgv_CurrentData.Rows[RowCurindex].Cells["DbId"].Value = usedInfodata.DbId;
                dgv_CurrentData.Rows[RowCurindex].Cells["OtherID"].Value = usedInfodata.OtherID;
                dgv_CurrentData.Rows[RowCurindex].Cells["TagCode"].Value = usedInfodata.TagCode;
                dgv_CurrentData.Rows[RowCurindex].Cells["Sign"].Value = usedInfodata.Sign;
                dgv_CurrentData.Rows[RowCurindex].Cells["Pass"].Value = usedInfodata.Pass;
                dgv_CurrentData.Rows[RowCurindex].Cells["FileName"].Value = usedInfodata.FileName;
                dgv_CurrentData.Rows[RowCurindex].DefaultCellStyle.BackColor = Color.Red;       // 整行红
                // 已扫描文件个数
                ImgNumber = ImgNumber + 1;  //已扫描文件：0个

                tssl_ImgNumber.Text = "已扫描文件：" + ImgNumber + "个";
                // 休眠
                dataProcessingThread.Suspend();
            }
        }
        #endregion

        #region 自动识别与手动识别切换
        /// <summary>
        /// 自动识别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rad_AT_CheckedChanged(object sender, EventArgs e)
        {
            // 手动可选框隐藏
            pnl_radpnl.Visible = false;
            // 自动识别表示变为自动
            AutoT.state = AutoTState.AT;
        }

        /// <summary>
        /// 手动识别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rad_MT_CheckedChanged(object sender, EventArgs e)
        {
            // 手动可选框显示
            pnl_radpnl.Visible = true;
            // 自动识别表示变为手动
            AutoT.state = AutoTState.MT;
        }
        #endregion

        #region 手动选择pnl_radpnl区域

        /// <summary>
        /// 植入物使用清单选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rad_SHIL_CheckedChanged(object sender, EventArgs e)
        {
            // 手动识图&&植入物使用清单选中
            if (AutoT.state == AutoTState.MT && rad_HNCL.Checked == true)
            {
                KindOfPicture = "1SHIL";
            }
        }

        /// <summary>
        /// 高净值耗材使用清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rad_HNCL_CheckedChanged(object sender, EventArgs e)
        {
            // 手动识图&&高净值耗材使用清单
            if (AutoT.state == AutoTState.MT && rad_HNCL.Checked == true)
            {
                KindOfPicture = "2HNCL";
            }
        }

        /// <summary>
        /// 耗材仓库配送出库单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rad_CWDL_CheckedChanged(object sender, EventArgs e)
        {
            // 手动识图&&耗材仓库配送出库单
            if (AutoT.state == AutoTState.MT && rad_CWDL.Checked == true)
            {
                KindOfPicture = "3CWDL";
            }
        }
        #endregion

        /// <summary>
        /// 抓取图片保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_CaptureImg_Click(object sender, EventArgs e)
        {
            //if (mainFormBLL.CaptureImgbll() > 0)
            //{

            //    //弹框2秒后自动消失

            //    //DataGridView.HitTestInfo
            //}
            //else
            //{
            //    MessageBox.Show("图片保存失败！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            mainFormBLL.CaptureImgbll(usedInfodata);
        }
    }
}