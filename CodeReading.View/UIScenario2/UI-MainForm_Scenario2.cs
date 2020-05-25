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
        //Thread camerarfsThread;

        // 相机句柄
        //HTuple hv_AcqHandle = null;
        // halcon控件-实时影像
        HTuple rtaHalconWin;
        // halcon控件-处理结果
        HTuple icsHalconWin;

        // 图像宽高变量,平均值，方差
        //HTuple hv_Mean = null, hv_Deviation = null;
        //rdo
        string KindOfPicture = "";
        // 全局DbIdstr
        string DbIdstr = "";
        #endregion

        #region 实例化对象
        // 实例化MainFormBLL对象
        MainFormBLL mainFormBLL = new MainFormBLL();
        // 实例化MainFormDAL对象
        MainFormDAL mainFormDAL = new MainFormDAL();
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

            // 注册窗体关闭事件
            this.FormClosing += new FormClosingEventHandler(MainForm_Closing);
        }
        /// <summary>
        /// 添加窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            // 终止数据处理Thread
            dataProcessingThread.Abort();
            // 终止实时影像Thread
            openThread.Abort();
            // 释放相机句柄
            HOperatorSet.CloseAllFramegrabbers();
            Application.Exit();                   // 退出应用
            System.Environment.Exit(1);           // 终止此应用进程
        }

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
                }
            }
            catch (HalconException halExp)
            {
                MessageBox.Show("图像处理信息获取失败！" + halExp.GetErrorCode() +halExp.GetErrorMessage());
                tssl_CameraStatus.Text = "扫描信息异常";
            }
        }

        /// <summary>
        /// 数据处理(查数据 比对数据 保存数据图片显示数据)
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

                    // 全局变量判断变量DbIdstr赋值
                    DbIdstr = usedInfodata.DbId;
                    // 如果是1SHIL
                    if (DbIdstr == "1SHIL")
                    {
                        // 查数据
                        SelectData();

                        // 赋值
                        string ScanDate = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                        usedInfodata.ScanDate = ScanDate;                     // 日期
                        usedInfodata.FileName = ScanDate + ".bmp";            // 图片名
                                                                              // 比对数据通过
                        if (DataCheck() == 1)
                        {
                            ///DataGridView1.RowsDefaultCellStyle.BackColor = Color.Yellow;         // 所有
                            ///DataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.Aqua;    // 列
                            ///DataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.LightGray;  // 行
                            ///DataGridView1[0, 0].Style.BackColor = Color.Pink;                    // 某个单元格

                            // 赋值
                            usedInfodata.Pass = "1";

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

                        // 比对数据不通过
                        else if (DataCheck() == 0)
                        {
                            // 赋值
                            usedInfodata.Pass = "0";

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
                            // 条形码不正确时标红
                            //if (usedInfodata.TagCode != CurrentDataSHIL.Rows[0]["TagCode"].ToString())
                            //{
                            //    dgv_CurrentData.Rows[RowCurindex].Cells["TagCode"].Style.BackColor = Color.Red;    // 条形码的单元格标红
                            //}
                            // 未签字时标红
                            if (usedInfodata.Sign == "0")
                            {
                                dgv_CurrentData.Rows[RowCurindex].Cells["Sign"].Style.BackColor = Color.Red;    // 签字的单元格标红
                            }
                            // 已扫描文件个数
                            ImgNumber = ImgNumber + 1;  //已扫描文件：ImgNumber个

                            tssl_ImgNumber.Text = "已扫描文件：" + ImgNumber + "个";
                            // 休眠
                            //dataProcessingThread.Suspend();
                        }
                        Thread.Sleep(3000);
                    }

                    // 如果是2HNCL
                    else if (DbIdstr == "2HNCL")
                    {
                        // 查数据
                        SelectData();

                        // 赋值
                        string ScanDate = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                        usedInfodata.ScanDate = ScanDate;                     // 日期
                        usedInfodata.FileName = ScanDate + ".bmp";            // 图片名
                        // 比对数据通过
                        if (DataCheck() == 1)
                        {
                            // 赋值
                            usedInfodata.Pass = "1";

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
                        // 比对数据不通过
                        else if (DataCheck() == 0)
                        {
                            // 赋值
                            usedInfodata.Pass = "0";

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
                            // 条形码不正确时标红
                            //if (usedInfodata.TagCode != CurrentDataSHIL.Rows[0]["TagCode"].ToString())
                            //{
                            //    dgv_CurrentData.Rows[RowCurindex].Cells["TagCode"].Style.BackColor = Color.Red;    // 条形码的单元格标红
                            //}
                            // 未签字时标红
                            if (usedInfodata.Sign == "0")
                            {
                                dgv_CurrentData.Rows[RowCurindex].Cells["Sign"].Style.BackColor = Color.Red;    // 签字的单元格标红
                            }
                            // 已扫描文件个数
                            ImgNumber = ImgNumber + 1;  //已扫描文件：ImgNumber个

                            tssl_ImgNumber.Text = "已扫描文件：" + ImgNumber + "个";
                            // 休眠
                            //dataProcessingThread.Suspend();
                        }
                        Thread.Sleep(3000);
                    }

                    // 如果是3CWDL
                    else if (DbIdstr == "3CWDL")
                    {
                        // 查数据
                        SelectData();

                        // 赋值
                        string ScanDate = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                        usedInfodata.ScanDate = ScanDate;                     // 日期
                        usedInfodata.FileName = ScanDate + ".bmp";            // 图片名
                        // 比对数据通过
                        if (DataCheck() == 1)
                        {
                            // 赋值
                            usedInfodata.Pass = "1";

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
                        // 比对数据不通过
                        else if (DataCheck() == 0)
                        {
                            // 赋值
                            usedInfodata.Pass = "0";

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
                            // 条形码不正确时标红
                            //if (usedInfodata.TagCode != CurrentDataSHIL.Rows[0]["TagCode"].ToString())
                            //{
                            //    dgv_CurrentData.Rows[RowCurindex].Cells["TagCode"].Style.BackColor = Color.Red;    // 条形码的单元格标红
                            //}
                            // 未签字时标红
                            if (usedInfodata.Sign == "0")
                            {
                                dgv_CurrentData.Rows[RowCurindex].Cells["Sign"].Style.BackColor = Color.Red;    // 签字的单元格标红
                            }
                            // 已扫描文件个数
                            ImgNumber = ImgNumber + 1;  //已扫描文件：ImgNumber个

                            tssl_ImgNumber.Text = "已扫描文件：" + ImgNumber + "个";
                            // 休眠
                            //dataProcessingThread.Suspend();
                        }
                        Thread.Sleep(3000);
                    }
                    else
                    {
                        //清除表单
                        dgv_CurrentData.Rows.Clear();
                    }
                }
            }
        }

        /// <summary>
        /// 查数据
        /// </summary>
        /// <returns></returns>
        private void SelectData()
        {
            // 获取数据
            //var client = new MainFormServiceClient();
            // 如果是1SHIL
            if (DbIdstr == "1SHIL")
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
            else if (DbIdstr == "2HNCL")
            {
                var result = new DataHNCL();
                result = mainFormDAL.dataHNCL(usedInfodata);
                // 検索結果件数判定
                if (result.DataTable.Rows.Count == 0)
                {
                    //MessageBox.Show(" 数据表里没有该条数据 或 表污损严重！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    // 把扫描到的数据绘制到"当前扫描数据区域"并表底颜色标红
                }
                else
                {
                    // 绘制到"当前扫描数据区域"
                    CurrentDataHNCL = result.DataTable;
                }
            }
            // 如果是3CWDL
            else if (DbIdstr == "3CWDL")
            {
                var result = new DataCWDL();
                result = mainFormDAL.dataCWDL(usedInfodata);
                // 検索結果件数判定
                if (result.DataTable.Rows.Count == 0)
                {
                    //MessageBox.Show(" 数据表里没有该条数据 或 表污损严重！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    // 把扫描到的数据绘制到"当前扫描数据区域"并表底颜色标红
                }
                else
                {
                    // 绘制到"当前扫描数据区域"
                    CurrentDataCWDL = result.DataTable;
                }
            }
        }

        /// <summary>
        /// 比对数据
        /// </summary>
        /// <returns></returns>
        private int DataCheck()
        {
            ////扫描到的值
            //usedInfodata.DbId = halconHelpers.usedInfoDbId;         // 表类别
            //usedInfodata.OtherID = halconHelpers.usedInfoOtherID;   // 模拟主键
            //usedInfodata.Sign = halconHelpers.usedInfoSign;         // 签字
            //usedInfodata.TagCode = halconHelpers.usedInfoTagCode;   // 条形码
            //usedInfodata.HImg = halconHelpers.usedInfoHImg;         // HObject图片

            if (DbIdstr == "1SHIL")
            {
                // 扫描到的值usedInfodata=数据库查的值CurrentDataSHIL
                string HospitalizationNumberstr = CurrentDataSHIL.Rows[0]["HospitalizationNumber"].ToString();
                string TagCodestr = CurrentDataSHIL.Rows[0]["TagCode"].ToString();
                //System.Diagnostics.Debug.Print(Hosp+"  "+ TagC);
                //System.Diagnostics.Debug.Print(usedInfodata.OtherID + "  " + usedInfodata.TagCode);
                if (usedInfodata.OtherID == HospitalizationNumberstr &&
                    //usedInfodata.TagCode == TagCodestr &&
                    usedInfodata.Sign == "1"
                    )
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            // 如果是2HNCL
            else if (DbIdstr == "2HNCL")
            {
                // 扫描到的值usedInfodata=数据库查的值CurrentDataHNCL
                string HospitalizationNumberstr = CurrentDataHNCL.Rows[0]["HospitalizationNumber"].ToString();
                string TagCodestr = CurrentDataHNCL.Rows[0]["TagCode"].ToString();
                //System.Diagnostics.Debug.Print(Hosp+"  "+ TagC);
                //System.Diagnostics.Debug.Print(usedInfodata.OtherID + "  " + usedInfodata.TagCode);
                if (usedInfodata.OtherID == HospitalizationNumberstr &&
                    //usedInfodata.TagCode == TagCodestr &&
                    usedInfodata.Sign == "1"
                    )
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            // 如果是3CWDL
            else if (DbIdstr == "3CWDL")
            {
                // 扫描到的值usedInfodata=数据库查的值CurrentDataSHIL
                string TagCodestr = CurrentDataCWDL.Rows[0]["TagCode"].ToString();
                //System.Diagnostics.Debug.Print(Hosp+"  "+ TagC);
                //System.Diagnostics.Debug.Print(usedInfodata.OtherID + "  " + usedInfodata.TagCode);
                if (//usedInfodata.TagCode == TagCodestr &&
                    usedInfodata.Sign == "1"
                    )
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 2;
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