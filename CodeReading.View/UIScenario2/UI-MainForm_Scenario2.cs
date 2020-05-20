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
        // halcon控件-窗口句柄
        HTuple rtaHalconWin;
        HTuple icsHalconWin;

        // 图像宽高变量,平均值，方差
        HTuple hv_Mean = null, hv_Deviation = null;
        #endregion

        #region 实例化对象
        // 实例化MainFormBLL对象
        MainFormBLL mainFormBLL = new MainFormBLL();
        // 实例化CaptureImg对象
        CaptureImg capimg = new CaptureImg();
        // 实例化CWDL对象
        CWDL cWDL = new CWDL();
        // 实例化HNCL对象
        HNCL hNCL = new HNCL();
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
            //释放相机句柄
            HOperatorSet.CloseAllFramegrabbers();
            try
            {
                if (hv_AcqHandle != null) { return; }
                //连接相机
                HOperatorSet.OpenFramegrabber("GigEVision2", 0, 0, 0, 0, 0, 0, "progressive",
            -1, "default", -1, "false", "default", "c42f90f2b7fa_Hikvision_MVCE12010GM",
            0, -1, out hv_AcqHandle);
                tssl_CameraStatus.Text = "扫描相机连接成功";

            }
            catch (HOperatorException)
            {
                MessageBox.Show("相机连接失败！");
                tssl_CameraStatus.Text = "扫描相机未连接";
            }

            if (hv_AcqHandle == null)
            {
                return;
            }
            // 实时影像Thread
            openThread = new Thread(OpenThread);
            openThread.Start();

            // 相机参数Thread
            //camerarfsThread = new Thread(Camerarfs);
            //camerarfsThread.Start();
        }
        /// <summary>
        /// 实时影像Thread
        /// </summary>
        private void OpenThread()
        {
            try
            {
                // 植入物使用清单
                if (rad_CaptureImg.Checked == true)
                {
                    capimg.RunHalcon_CaptureImg(hv_AcqHandle, icsHalconWin, rtaHalconWin);
                }
                // 耗材仓库配送出库单
                else if (rad_CWDL.Checked == true)
                {
                    cWDL.RunHalcon_CWDL(hv_AcqHandle, icsHalconWin, rtaHalconWin);
                }
                // 高净值耗材使用清单
                else if (rad_HNCL.Checked == true)
                {
                    hNCL.RunHalcon_HNCL(hv_AcqHandle, icsHalconWin, rtaHalconWin);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("图像处理信息获取失败！");
                tssl_CameraStatus.Text = "扫描信息异常";
            }
        }
        /// <summary>
        /// 相机参数Thread
        /// </summary>
        private void Camerarfs()
        {
            HObject ho_Image = null;
            int i = 1;

            try
            {
                while (i != 0)
                {
                    HOperatorSet.GrabImage(out ho_Image, hv_AcqHandle);
                    if (ho_Image != null)
                    {
                        HOperatorSet.Intensity(ho_Image, ho_Image, out hv_Mean, out hv_Deviation); // 求图片平均值和方差
                        tssl_Mean.Text = "图片平均值：" + hv_Mean.ToString();
                        tssl_Deviation.Text = "图片方差：" + hv_Deviation.ToString();
                        //显示玩之后释放图片
                        ho_Image.Dispose();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("相机参数获取失败！");
                tssl_Mean.Text = "相机参数获取失败!";
                tssl_Deviation.Text = "无法自动捕捉图像";
            }
        }
        /// <summary>
        /// 选择“植入物使用清单”时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rad_CaptureImg_Click(object sender, EventArgs e)
        {
            //if (openThread.ToString() == "null")
            //{
            //    return;
            //}
            //else
            //{
            //    openThread.Abort();
            //    openThread.Start();
            //}
        }
        /// <summary>
        /// 选择“耗材仓库配送出库单”时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rad_CWDL_Click(object sender, EventArgs e)
        {
            ////try
            ////{
            //    openThread.Abort();
            //    Thread openThread1 = new Thread(OpenThread);
            //openThread1.Start();
            ////}
            ////catch { return; }
        }

        /// <summary>
        /// 选择“高净值耗材使用清单”时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rad_HNCL_Click(object sender, EventArgs e)
        {
            //if (openThread.ToString() == "null")
            //{
            //    return;
            //}
            //else
            //{
            //    openThread.Abort();
            //    openThread.Start();
            //}
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