using CodeReading.Entity;
using CodeReading.Entity.MainForm;
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
        // 实时影像Thread
        Thread openThread = null;

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

        // rad值
        string KindOfPicture = null;
        #endregion

        #region 实例化对象
        // 实例化MainFormBLL对象
        MainFormBLL mainFormBLL = new MainFormBLL();
        // 实例化CaptureImg对象
        //CaptureImg capimg = new CaptureImg();
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
            ////释放相机句柄
            //HOperatorSet.CloseAllFramegrabbers();
            //try
            //{
            //    if (hv_AcqHandle != null) { return; }
            //    //连接相机
            //    HOperatorSet.OpenFramegrabber("GigEVision2", 0, 0, 0, 0, 0, 0, "progressive",
            //-1, "default", -1, "false", "default", "c42f90f2b7fa_Hikvision_MVCE12010GM",
            //0, -1, out hv_AcqHandle);
            //    tssl_CameraStatus.Text = "扫描相机连接成功";

            //}
            //catch (HOperatorException)
            //{
            //    MessageBox.Show("相机连接失败！");
            //    tssl_CameraStatus.Text = "扫描相机未连接";
            //}

            //if (hv_AcqHandle == null)
            //{
            //    return;
            //}
            // 实时影像Thread
            openThread = new Thread(OpenThread);
            openThread.Start();
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
                    AutomaticMapRecognitionMethod(rtaHalconWin, icsHalconWin, out UsedInfo usedInfo);

                    // 数据处理(查数据 比对数据 保存数据)
                    DataProcessing();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("图像处理信息获取失败！");
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
        // 数据处理(查数据 比对数据 保存数据)
        public int DataProcessing()
        {
            // 查数据
            SelectData();

            // 比对数据
            if (DataCheck() == 1)
            {
                try
                {
                    // 保存数据

                    // 返回1-保存成功
                    return 1;
                }
                catch
                {
                    // 返回2-比对通过但保存失败
                    return 2;
                }
            }
            else
            {
                // 返回0-比对通过不通过（返回错误数据）
                return 0;
            }
        }
        /// <summary>
        /// 查数据
        /// </summary>
        /// <returns></returns>
        private void SelectData()
        {
            // 获取数据
            var client = new HistoryServiceClient();
            // 
            if ()
            {
                var result = client.Search(searchConditions);
            }
            // 

            // 検索結果件数判定
            if (result.SearchData.Rows.Count == 0)
            {
                MessageBox.Show(" 未检索到任何数据！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                // 隐藏检索结果数目
                lbl_ResultsCount.Text = "";
                return;
            }
        }

        /// <summary>
        /// 比对数据
        /// </summary>
        /// <returns></returns>
        private int DataCheck()
        {
            return 1;
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
            if (mainFormBLL.CaptureImgbll() > 0)
            {

                //弹框2秒后自动消失

                //DataGridView.HitTestInfo
            }
            else
            {
                MessageBox.Show("图片保存失败！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}