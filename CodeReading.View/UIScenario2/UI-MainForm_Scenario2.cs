using CodeReading.Entity;
using CodeReading.Entity.MainForm;
using CodeReading.View.BLL.HalconHelper;
using CodeReading.View.DAL;
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
        Thread camerarfsThread=null;

        // 相机句柄
        //HTuple hv_AcqHandle = null;
        // halcon控件-实时影像
        HTuple rtaHalconWin;
        // halcon控件-处理结果
        HTuple icsHalconWin;
        // 全局DbIdstr
        string DbIdstr = "";
        // 多的条形码
        string BadCodes = "";
        // 少的条形码
        string MissingCodes = "";
        // FPS整数部分
        int randomNumber=0;
        // FPS小数部分
        double randomdouble;
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

        // 实例化随机数方法
        Random random = new Random();
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

            ImgAuto.state = ImgAutoState.imgAutoTrue;
            AutoT.state = AutoTState.AT;
            // 注册窗体关闭事件
            this.FormClosing += new FormClosingEventHandler(MainForm_Closing);
        }
        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            // 终止数据处理Thread
            //dataProcessingThread.Abort();
            // 终止实时影像Thread
            //openThread.Abort();
            // 释放相机句柄
            HOperatorSet.CloseAllFramegrabbers();

            Application.Exit();                   // 退出应用
            // 有时终止进程会异常
            try {
                System.Environment.Exit(1);           // 终止此应用进程
            }
            catch { }
        }

        #region 实时显示内容
        /// <summary>
        /// 右下角时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Now_Tick(object sender, EventArgs e)
        {
            // 实时时间
            DateTime dtnow = System.DateTime.Now;
            tslbl_Time.Text = dtnow.ToString();

            // 假FPS
            if (CameraStatus.state==CameraRunStatus.CameraRunning)
            {
                // FPS小数部分赋值
                randomdouble = randomNumber + random.NextDouble();
                // 显示假FPS -format
                tssl_CameraFps.Text = "相机帧率：" + randomdouble;
            }
        }
        #endregion
        #region TSMI按钮
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

        #endregion

        #region 打开相机处理
        /// <summary>
        /// 打开相机按钮压下
        /// </summary>
        private void tsmi_OpenCamera_Click(object sender, EventArgs e)
        {
            // 当相机运行时，不可以再次运行
            if (CameraStatus.state == CameraRunStatus.CameraRunning)
            {
                return;
            }
            // 使其他线程可以访问窗体控件
            Control.CheckForIllegalCrossThreadCalls = false;
            // 相机线程
            openThread = new Thread(new ThreadStart(OpenThread));
            openThread.Start();

            // 数据处理
            dataProcessingThread = new Thread(new ThreadStart(DataProcessing));
            dataProcessingThread.Start();

            // 相机参数线程
            camerarfsThread =new Thread(new ThreadStart(Camerarfs));
            camerarfsThread.Start();
        }

        /// <summary>
        /// 相机Thread
        /// </summary>
        private void OpenThread()
        {
            try
            {
                // 识图
                if (AutoT.state == AutoTState.AT)
                {
                    // 记录相机状态
                    CameraStatus.state = CameraRunStatus.CameraRunning;
                    tssl_CameraStatus.Text = "相机已连接";
                    // 自动识图方法-返回
                    halconHelpers.AutomaticMapRecognitionMethod(rtaHalconWin, icsHalconWin, out UsedInfo usedInfo);
                }
            }
            catch (HalconException halExp)
            {
                // 记录相机状态
                CameraStatus.state = CameraRunStatus.CameraNotRunning;
                //MessageBox.Show("图像处理信息获取失败！" + halExp.GetErrorCode() +halExp.GetErrorMessage());
                MessageBox.Show("相机未连接或已打开！错误代码：" + halExp.GetErrorCode());
                tssl_CameraStatus.Text = "扫描信息异常";
            }
        }
        
        /// <summary>
        /// 相机参数线程
        /// </summary>
        private void Camerarfs()
        {
            while (true)
            {
                Thread.Sleep(1000);
                // FPS整数部分赋值
                randomNumber = halconHelpers.cameraFPS;
                // halconHelpers.cameraFPS重置
                halconHelpers.cameraFPS = 0;
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
                // 自动识图
                if (AutoT.state == AutoTState.AT)
                {
                    // 全局usedInfodata赋值
                    usedInfodata.DbId = halconHelpers.usedInfoDbId;             // 表类别
                    usedInfodata.OtherID = halconHelpers.usedInfoOtherID;       // 模拟主键
                    usedInfodata.Sign = halconHelpers.usedInfoSign;             // 签字
                    usedInfodata.TagCode = halconHelpers.usedInfoTagCode;       // 条形码
                    usedInfodata.HImg = halconHelpers.usedInfoHImg;             // HObject图片
                    usedInfodata.TagCodeNum= halconHelpers.usedInfoTagCodeNum;  // 条形码数
                    string ScanDate = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    usedInfodata.ScanDate = ScanDate;                           // 日期
                    usedInfodata.FileName = ScanDate + ".bmp";                  // 图片名
                    #region 清理用过的halconHelpers数据
                    halconHelpers.usedInfoDbId = "";        // 表类别
                    halconHelpers.usedInfoOtherID = "";     // 模拟主键
                    halconHelpers.usedInfoSign = "";        // 签字
                    halconHelpers.usedInfoTagCode = "";     // 条形码
                    halconHelpers.usedInfoTagCodeNum = "";  // 条形码数
                    #endregion
                    // 全局变量判断变量DbIdstr赋值
                    DbIdstr = usedInfodata.DbId;

                    // 重复扫描检查（0：不重复；1：“重复”但需要提示已扫描过；2：“重复”停止后续处理）
                    int repeatCheckint = RepeatCheck();
                    // 0：不重复
                    if (repeatCheckint == 0)
                    {
                        // 如果是1SHIL
                        if (DbIdstr == "1SHIL")
                        {
                            tssl_showDBID.Text = "识别到《跟台人体植入物使用清单》表单";
                            // 数据查询结果为0
                            if (SelectData() == 0) // 未检索到数据
                            {
                                usedInfodata.Pass = "0";
                                // 显示相机获取的数据-红色
                                dgv_CurrentData.Rows.Clear();
                                DataGridViewRow Row = new DataGridViewRow();
                                int RowCurindex = dgv_CurrentData.Rows.Add(Row);
                                dgv_CurrentData.Rows[RowCurindex].Cells["ScanDate"].Value = usedInfodata.ScanDate;
                                dgv_CurrentData.Rows[RowCurindex].Cells["DbId"].Value = usedInfodata.DbId;
                                dgv_CurrentData.Rows[RowCurindex].Cells["OtherID"].Value = usedInfodata.OtherID;
                                dgv_CurrentData.Rows[RowCurindex].Cells["TagCode"].Value = usedInfodata.TagCode;
                                dgv_CurrentData.Rows[RowCurindex].Cells["Sign"].Value = usedInfodata.Sign == "[1, 1, 1, 1]" ? "已签字" : "未签字";
                                dgv_CurrentData.Rows[RowCurindex].Cells["Pass"].Value = "不通过";
                                lbl_PassIS.ForeColor = Color.Red;
                                lbl_PassIS.Text = "不通过";
                                dgv_CurrentData.Rows[RowCurindex].Cells["FileName"].Value = usedInfodata.FileName;
                                dgv_CurrentData.Rows[RowCurindex].DefaultCellStyle.BackColor = Color.Red;  // 行
                                DataGridViewRow Rowshow = new DataGridViewRow();
                                int RowCurindexshow = dgv_CurrentData.Rows.Add(Rowshow);
                                dgv_CurrentData.Rows[RowCurindexshow].Cells["ScanDate"].Value = "未查询到此表单数据！";
                                dgv_CurrentData.Rows[RowCurindexshow].Cells["TagCode"].Value = "此表单数据在数据库里不存在！";
                                dgv_CurrentData.Rows[RowCurindexshow].DefaultCellStyle.ForeColor = Color.Red;  // 行
                                                                                                               // 已扫描文件个数
                                ImgNumber = ImgNumber + 1;  //已扫描文件：0个
                                tssl_ImgNumber.Text = "已扫描文件：" + ImgNumber + "个";
                            }
                            else  // 检索到数据
                            {
                                // 比对数据是否通过
                                int DataCheckint = DataCheck();
                                // 比对数据通过
                                if (DataCheckint == 1)
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
                                    dgv_CurrentData.Rows[RowCurindex].Cells["Sign"].Value = usedInfodata.Sign == "[1, 1, 1, 1]" ? "已签字" : "未签字";
                                    dgv_CurrentData.Rows[RowCurindex].Cells["Pass"].Value = "通过";
                                    lbl_PassIS.ForeColor =Color.Green;
                                    lbl_PassIS.Text = "通过";
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
                                    dgv_CumulativeData.Rows[RowCumindex].Cells["hisySign"].Value = usedInfodata.Sign == "[1, 1, 1, 1]" ? "已签字" : "未签字";
                                    dgv_CumulativeData.Rows[RowCumindex].Cells["hisyPass"].Value = "通过";
                                    dgv_CumulativeData.Rows[RowCumindex].Cells["hisyFileName"].Value = usedInfodata.FileName;
                                    #endregion
                                    // 清理usedInfodata数据
                                    ClearData_usedInfodata();
                                    // 已扫描文件个数
                                    ImgNumber = ImgNumber + 1;  //已扫描文件：0个

                                    tssl_ImgNumber.Text = "已扫描文件：" + ImgNumber + "个";
                                }

                                // 比对数据不通过
                                else if (DataCheckint == 0)
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
                                    dgv_CurrentData.Rows[RowCurindex].Cells["Sign"].Value = usedInfodata.Sign == "[1, 1, 1, 1]" ? "已签字" : "未签字";
                                    dgv_CurrentData.Rows[RowCurindex].Cells["Pass"].Value = "不通过";
                                    lbl_PassIS.ForeColor = Color.Red;
                                    lbl_PassIS.Text = "不通过";
                                    dgv_CurrentData.Rows[RowCurindex].Cells["FileName"].Value = usedInfodata.FileName;

                                    // 错误提示行
                                    DataGridViewRow Rowshow = new DataGridViewRow();
                                    int RowCurindexshow = dgv_CurrentData.Rows.Add(Rowshow);
                                    // 条形码不正确时标红
                                    if (BadCodes.Length>0 || MissingCodes.Length>0)
                                    {
                                        dgv_CurrentData.Rows[RowCurindex].Cells["TagCode"].Style.BackColor = Color.Red;  // 条形码的单元格标红          


                                        dgv_CurrentData.Rows[RowCurindexshow].Cells["ScanDate"].Value = "表单数据信息有误！";
                                        string TagCodeshowstr = "";
                                        // 表单“多的条形码”赋值
                                        if (BadCodes.Length>0)
                                        {
                                            TagCodeshowstr = TagCodeshowstr + "表单多了条形码：" + BadCodes + "原数据不存在此条形码";
                                        }
                                        // 添加“；”
                                        if (BadCodes.Length > 0 && MissingCodes.Length > 0)
                                        {
                                            TagCodeshowstr = TagCodeshowstr + "；";
                                        }
                                        // 表单“少了条形码”赋值
                                        if (MissingCodes.Length > 0)
                                        {
                                            TagCodeshowstr = TagCodeshowstr + "表单少了条形码：" + MissingCodes + "请查看表单是否污损";
                                        }
                                        TagCodeshowstr = TagCodeshowstr + "！";
                                        dgv_CurrentData.Rows[RowCurindexshow].Cells["TagCode"].Value = TagCodeshowstr;  // 第二行提示“多的条形码”和“少的条形码”
                                        dgv_CurrentData.Rows[RowCurindexshow].DefaultCellStyle.ForeColor = Color.Red;   // 行

                                        // 重置“多的条形码”和“少的条形码”
                                        BadCodes = "";
                                        MissingCodes = "";
                                        // 重置""
                                    }
                                    // 未签字时标红
                                    if (usedInfodata.Sign != "[1, 1, 1, 1]")
                                    {
                                        // Sign结果显示
                                        string SignResultStr = "";
                                        string[] SignNoArray = usedInfodata.Sign.Split(',');   // 拆分签名[1, 1, 1, 1]
                                        if (SignNoArray[3] == " 0]")
                                        {
                                            SignResultStr = SignResultStr + "手术医生 ";
                                        }
                                        if (SignNoArray[2] == " 0")
                                        {
                                            SignResultStr = SignResultStr + "手术护士 ";
                                        }
                                        if (SignNoArray[1] == " 0")
                                        {
                                            SignResultStr = SignResultStr + "SPD/交换 ";
                                        }
                                        if (SignNoArray[0]== "[0")
                                        {
                                            SignResultStr = SignResultStr + "供应商 ";
                                        }
                                        SignResultStr = SignResultStr + "未签名";
                                        // 签字单元格的提示信息
                                        dgv_CurrentData.Rows[RowCurindex].Cells["Sign"].Style.BackColor = Color.Red;     // 签字的单元格标红
                                        dgv_CurrentData.Rows[RowCurindexshow].Cells["Sign"].Value = SignResultStr;
                                        dgv_CurrentData.Rows[RowCurindexshow].DefaultCellStyle.ForeColor = Color.Red;   // 红字
                                    }
                                    dgv_CurrentData.Rows[RowCurindex].Cells["Pass"].Style.ForeColor = Color.Red;        // 不通过
                                    // 清理usedInfodata数据 
                                    ClearData_usedInfodata();

                                    // 已扫描文件个数
                                    ImgNumber = ImgNumber + 1;  //已扫描文件：ImgNumber个
                                    tssl_ImgNumber.Text = "已扫描文件：" + ImgNumber + "个";
                                    // 休眠-废弃
                                    //dataProcessingThread.Suspend();
                                }
                            }
                        }

                        // 如果是2HNCL
                        else if (DbIdstr == "2HNCL")
                        {
                            tssl_showDBID.Text = "识别到《高净值耗材使用清单》表单";
                            // 数据查询结果为0
                            if (SelectData() == 0) // 未检索到数据
                            {
                                usedInfodata.Pass = "0";
                                // 显示相机获取的数据-红色
                                dgv_CurrentData.Rows.Clear();
                                DataGridViewRow Row = new DataGridViewRow();
                                int RowCurindex = dgv_CurrentData.Rows.Add(Row);
                                dgv_CurrentData.Rows[RowCurindex].Cells["ScanDate"].Value = usedInfodata.ScanDate;
                                dgv_CurrentData.Rows[RowCurindex].Cells["DbId"].Value = usedInfodata.DbId;
                                dgv_CurrentData.Rows[RowCurindex].Cells["OtherID"].Value = usedInfodata.OtherID;
                                dgv_CurrentData.Rows[RowCurindex].Cells["TagCode"].Value = usedInfodata.TagCode;
                                dgv_CurrentData.Rows[RowCurindex].Cells["Sign"].Value = "该表单不需要验证签字";
                                dgv_CurrentData.Rows[RowCurindex].Cells["Pass"].Value = "不通过";
                                lbl_PassIS.ForeColor = Color.Red;
                                lbl_PassIS.Text = "不通过";
                                dgv_CurrentData.Rows[RowCurindex].Cells["FileName"].Value = usedInfodata.FileName;
                                dgv_CurrentData.Rows[RowCurindex].DefaultCellStyle.BackColor = Color.Red;  // 行
                                DataGridViewRow Rowshow = new DataGridViewRow();
                                int RowCurindexshow = dgv_CurrentData.Rows.Add(Rowshow);
                                dgv_CurrentData.Rows[RowCurindexshow].Cells["ScanDate"].Value = "未查询到此表单数据！";
                                dgv_CurrentData.Rows[RowCurindexshow].Cells["TagCode"].Value = "此表单数据在数据库里不存在！";
                                dgv_CurrentData.Rows[RowCurindexshow].DefaultCellStyle.ForeColor = Color.Red;  // 行
                                                                                                               // 已扫描文件个数
                                ImgNumber = ImgNumber + 1;  //已扫描文件：0个
                                tssl_ImgNumber.Text = "已扫描文件：" + ImgNumber + "个";
                            }
                            else  // 查询到数据
                            {
                                // 比对数据是否通过
                                int DataCheckint = DataCheck();
                                // 比对数据通过
                                if (DataCheckint == 1)
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
                                    dgv_CurrentData.Rows[RowCurindex].Cells["Sign"].Value = usedInfodata.Sign=="1" ? "已签字" : "未签字";
                                    dgv_CurrentData.Rows[RowCurindex].Cells["Pass"].Value = "通过";
                                    lbl_PassIS.ForeColor = Color.Green;
                                    lbl_PassIS.Text = "通过";
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
                                    dgv_CumulativeData.Rows[RowCumindex].Cells["hisySign"].Value = usedInfodata.Sign == "1" ? "已签字" : "未签字";
                                    dgv_CumulativeData.Rows[RowCumindex].Cells["hisyPass"].Value = "通过";
                                    dgv_CumulativeData.Rows[RowCumindex].Cells["hisyFileName"].Value = usedInfodata.FileName;
                                    #endregion

                                    // 已扫描文件个数
                                    ImgNumber = ImgNumber + 1;  //已扫描文件：0个

                                    tssl_ImgNumber.Text = "已扫描文件：" + ImgNumber + "个";
                                }
                                // 比对数据不通过
                                else if (DataCheckint == 0)
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
                                    dgv_CurrentData.Rows[RowCurindex].Cells["Sign"].Value = "该表单不需要验证签字";
                                    dgv_CurrentData.Rows[RowCurindex].Cells["Pass"].Value = "不通过";
                                    lbl_PassIS.ForeColor = Color.Red;
                                    lbl_PassIS.Text = "不通过";
                                    dgv_CurrentData.Rows[RowCurindex].Cells["FileName"].Value = usedInfodata.FileName;

                                    // 错误提示行
                                    DataGridViewRow Rowshow = new DataGridViewRow();
                                    int RowCurindexshow = dgv_CurrentData.Rows.Add(Rowshow);
                                    // 条形码不正确时标红
                                    if (BadCodes.Length > 0 || MissingCodes.Length > 0)
                                    {
                                        dgv_CurrentData.Rows[RowCurindex].Cells["TagCode"].Style.BackColor = Color.Red;  // 条形码的单元格标红          


                                        dgv_CurrentData.Rows[RowCurindexshow].Cells["ScanDate"].Value = "表单数据信息有误！";
                                        string TagCodeshowstr = "";
                                        // 表单“多的条形码”赋值
                                        if (BadCodes.Length > 0)
                                        {
                                            TagCodeshowstr = TagCodeshowstr + "表单多了条形码：" + BadCodes + "原数据不存在此条形码";
                                        }
                                        // 添加“；”
                                        if (BadCodes.Length > 0 && MissingCodes.Length > 0)
                                        {
                                            TagCodeshowstr = TagCodeshowstr + "；";
                                        }
                                        // 表单“少了条形码”赋值
                                        if (MissingCodes.Length > 0)
                                        {
                                            TagCodeshowstr = TagCodeshowstr + "表单少了条形码：" + MissingCodes + "请查看表单是否污损";
                                        }
                                        TagCodeshowstr = TagCodeshowstr + "！";
                                        dgv_CurrentData.Rows[RowCurindexshow].Cells["TagCode"].Value = TagCodeshowstr;  // 第二行提示“多的条形码”和“少的条形码”
                                        dgv_CurrentData.Rows[RowCurindexshow].DefaultCellStyle.ForeColor = Color.Red;   // 行

                                        // 重置“多的条形码”和“少的条形码”
                                        BadCodes = "";
                                        MissingCodes = "";
                                        // 重置""
                                    }

                                    // 不通过
                                    dgv_CurrentData.Rows[RowCurindex].Cells["Pass"].Style.ForeColor = Color.Red; 
                                    
                                    // 清理usedInfodata数据 
                                    ClearData_usedInfodata();

                                    // 已扫描文件个数
                                    ImgNumber = ImgNumber + 1;  //已扫描文件：ImgNumber个
                                    tssl_ImgNumber.Text = "已扫描文件：" + ImgNumber + "个";
                                    // 休眠
                                    //dataProcessingThread.Suspend();
                                }
                            }
                        }

                        // 如果是3CWDL
                        else if (DbIdstr == "3CWDL")
                        {
                            tssl_showDBID.Text = "识别到《耗材仓库配送出库单》表单";
                            // 数据查询结果为0
                            if (SelectData() == 0) // 未检索到数据
                            {
                                usedInfodata.Pass = "0";
                                // 显示相机获取的数据-红色
                                dgv_CurrentData.Rows.Clear();
                                DataGridViewRow Row = new DataGridViewRow();
                                int RowCurindex = dgv_CurrentData.Rows.Add(Row);
                                dgv_CurrentData.Rows[RowCurindex].Cells["ScanDate"].Value = usedInfodata.ScanDate;
                                dgv_CurrentData.Rows[RowCurindex].Cells["DbId"].Value = usedInfodata.DbId;
                                dgv_CurrentData.Rows[RowCurindex].Cells["OtherID"].Value = usedInfodata.OtherID;
                                dgv_CurrentData.Rows[RowCurindex].Cells["TagCode"].Value = usedInfodata.TagCode;
                                dgv_CurrentData.Rows[RowCurindex].Cells["Sign"].Value = usedInfodata.Sign== "[1, 1, 1, 1]" ? "已签字" : "未签字";
                                dgv_CurrentData.Rows[RowCurindex].Cells["Pass"].Value = "不通过";
                                lbl_PassIS.ForeColor = Color.Red;
                                lbl_PassIS.Text = "不通过";
                                dgv_CurrentData.Rows[RowCurindex].Cells["FileName"].Value = usedInfodata.FileName;
                                dgv_CurrentData.Rows[RowCurindex].DefaultCellStyle.BackColor = Color.Red;  // 行
                                DataGridViewRow Rowshow = new DataGridViewRow();
                                int RowCurindexshow = dgv_CurrentData.Rows.Add(Rowshow);
                                dgv_CurrentData.Rows[RowCurindexshow].Cells["ScanDate"].Value = "未查询到此表单数据！";
                                dgv_CurrentData.Rows[RowCurindexshow].Cells["TagCode"].Value = "此表单数据在数据库里不存在！";
                                dgv_CurrentData.Rows[RowCurindexshow].DefaultCellStyle.ForeColor = Color.Red;  // 行
                                                                                                               // 已扫描文件个数
                                ImgNumber = ImgNumber + 1;  //已扫描文件：0个
                                tssl_ImgNumber.Text = "已扫描文件：" + ImgNumber + "个";
                            }
                            else
                            {
                                // 比对数据是否通过
                                int DataCheckint = DataCheck();
                                // 比对数据通过
                                if (DataCheckint == 1)
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
                                    dgv_CurrentData.Rows[RowCurindex].Cells["TagCode"].Value = "此表单不需要条形码只要验证签字！";
                                    dgv_CurrentData.Rows[RowCurindex].Cells["Sign"].Value = usedInfodata.Sign == "[1, 1, 1, 1]" ? "已签字" : "未签字";
                                    dgv_CurrentData.Rows[RowCurindex].Cells["Pass"].Value = "通过";
                                    lbl_PassIS.ForeColor = Color.Green;
                                    lbl_PassIS.Text = "通过";
                                    dgv_CurrentData.Rows[RowCurindex].Cells["FileName"].Value = usedInfodata.FileName;
                                    dgv_CurrentData.Rows[RowCurindex].DefaultCellStyle.BackColor = Color.GreenYellow;       // 整行绿

                                    // 添加到记录栏-绿色
                                    DataGridViewRow CumRow = new DataGridViewRow();
                                    dgv_CumulativeData.Rows.Add(CumRow);
                                    int RowCumindex = dgv_CumulativeData.Rows.Count - 1;
                                    dgv_CumulativeData.Rows[RowCumindex].Cells["hisyScanDate"].Value = usedInfodata.ScanDate;
                                    dgv_CumulativeData.Rows[RowCumindex].Cells["hisyDbId"].Value = usedInfodata.DbId;
                                    dgv_CumulativeData.Rows[RowCumindex].Cells["hisyOtherID"].Value = usedInfodata.OtherID;
                                    dgv_CumulativeData.Rows[RowCumindex].Cells["hisyTagCode"].Value = "此表单不需要条形码只要验证签字！";
                                    dgv_CumulativeData.Rows[RowCumindex].Cells["hisySign"].Value = usedInfodata.Sign == "[1, 1, 1, 1]" ? "已签字" : "未签字";
                                    dgv_CumulativeData.Rows[RowCumindex].Cells["hisyPass"].Value = "通过";
                                    dgv_CumulativeData.Rows[RowCumindex].Cells["hisyFileName"].Value = usedInfodata.FileName;
                                    #endregion

                                    // 已扫描文件个数
                                    ImgNumber = ImgNumber + 1;  //已扫描文件：0个

                                    tssl_ImgNumber.Text = "已扫描文件：" + ImgNumber + "个";
                                }
                                // 比对数据不通过
                                else if (DataCheckint == 0)
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
                                    dgv_CurrentData.Rows[RowCurindex].Cells["TagCode"].Value = "此表单不需要验证条形码,只需要验证签字！";
                                    dgv_CurrentData.Rows[RowCurindex].Cells["Sign"].Value = usedInfodata.Sign == "[1, 1, 1, 1]" ? "已签字" : "未签字";
                                    dgv_CurrentData.Rows[RowCurindex].Cells["Pass"].Value = "不通过";
                                    lbl_PassIS.ForeColor = Color.Red;
                                    lbl_PassIS.Text = "不通过";
                                    dgv_CurrentData.Rows[RowCurindex].Cells["FileName"].Value = usedInfodata.FileName;

                                    // 错误提示行
                                    DataGridViewRow Rowshow = new DataGridViewRow();
                                    int RowCurindexshow = dgv_CurrentData.Rows.Add(Rowshow);
                                    // 未签字时标红
                                    if (usedInfodata.Sign != "[1, 1, 1, 1]")
                                    {
                                        // Sign结果显示
                                        string SignResultStr = "";
                                        string[] SignNoArray = usedInfodata.Sign.Split(',');   // 拆分签名[1, 1, 1, 1]
                                        if (SignNoArray[3] == " 0]")
                                        {
                                            SignResultStr = SignResultStr + "复核人 ";
                                        }
                                        if (SignNoArray[2] == " 0")
                                        {
                                            SignResultStr = SignResultStr + "配送人 ";
                                        }
                                        if (SignNoArray[1] == " 0")
                                        {
                                            SignResultStr = SignResultStr + "科室收货人 ";
                                        }
                                        if (SignNoArray[0] == "[0")
                                        {
                                            SignResultStr = SignResultStr + "送货地址 ";
                                        }
                                        SignResultStr = SignResultStr + "未签名";
                                        // 签字单元格的提示信息
                                        dgv_CurrentData.Rows[RowCurindex].Cells["Sign"].Style.BackColor = Color.Red;    // 签字的单元格标红
                                        dgv_CurrentData.Rows[RowCurindexshow].Cells["Sign"].Value = SignResultStr;
                                        dgv_CurrentData.Rows[RowCurindexshow].DefaultCellStyle.ForeColor = Color.Red;   // 红字
                                    }

                                    // 清理usedInfodata数据 
                                    ClearData_usedInfodata();

                                    // 已扫描文件个数
                                    ImgNumber = ImgNumber + 1;  //已扫描文件：ImgNumber个
                                    tssl_ImgNumber.Text = "已扫描文件：" + ImgNumber + "个";
                                    // 休眠
                                    //dataProcessingThread.Suspend();
                                }
                            }
                        }
                        else
                        {
                            tssl_showDBID.Text = "未识别到表单";
                            //清除表单
                            dgv_CurrentData.Rows.Clear();
                        }
                    }
                    // 1：“重复”但需要提示已扫描过
                    else if (repeatCheckint == 1)
                    {
                        usedInfodata.Pass = "0";
                        // 显示相机获取的数据-红色
                        dgv_CurrentData.Rows.Clear();
                        DataGridViewRow Row = new DataGridViewRow();
                        int RowCurindex = dgv_CurrentData.Rows.Add(Row);
                        dgv_CurrentData.Rows[RowCurindex].Cells["ScanDate"].Value = usedInfodata.ScanDate;
                        dgv_CurrentData.Rows[RowCurindex].Cells["DbId"].Value = usedInfodata.DbId;
                        dgv_CurrentData.Rows[RowCurindex].Cells["OtherID"].Value = usedInfodata.OtherID;
                        dgv_CurrentData.Rows[RowCurindex].Cells["TagCode"].Value = usedInfodata.TagCode;
                        dgv_CurrentData.Rows[RowCurindex].Cells["Sign"].Value = usedInfodata.Sign == "1" ? "已签字" : "未签字";
                        dgv_CurrentData.Rows[RowCurindex].Cells["Pass"].Value = "不通过";
                        lbl_PassIS.ForeColor = Color.Red;
                        lbl_PassIS.Text = "不通过";
                        dgv_CurrentData.Rows[RowCurindex].Cells["FileName"].Value = usedInfodata.FileName;
                        dgv_CurrentData.Rows[RowCurindex].DefaultCellStyle.BackColor = Color.Red;  // 行
                        DataGridViewRow Rowshow = new DataGridViewRow();
                        int RowCurindexshow = dgv_CurrentData.Rows.Add(Rowshow);
                        dgv_CurrentData.Rows[RowCurindexshow].Cells["ScanDate"].Value = "查询到此表单数据！";
                        dgv_CurrentData.Rows[RowCurindexshow].Cells["TagCode"].Value = "此表单数据在数据库已存在，请不要重复输入！";
                        dgv_CurrentData.Rows[RowCurindexshow].DefaultCellStyle.ForeColor = Color.YellowGreen;  // 行
                        // 已扫描文件个数
                        ImgNumber = ImgNumber + 1;  //已扫描文件：0个
                        tssl_ImgNumber.Text = "已扫描文件：" + ImgNumber + "个";
                    }
                    Thread.Sleep(2500);
                }
            }
        }
        /// <summary>
        /// 清理usedInfodata数据
        /// </summary>
        private void ClearData_usedInfodata()
        {
            usedInfodata.DbId = "";        // 表类别
            usedInfodata.OtherID = "";     // 模拟主键
            usedInfodata.Sign = "";        // 签字
            usedInfodata.TagCode = "";     // 条形码
            usedInfodata.TagCodeNum = "";  // 条形码数
            usedInfodata.ScanDate = "";    // 日期
            usedInfodata.FileName = "";    // 图片名
        }

        /// <summary>
        /// 重复扫描检查
        /// </summary>
        /// <returns>0：不重复；1：“重复”但需要提示已扫描过；2：“重复”停止后续处理</returns>
        private int RepeatCheck()
        {
            // 假设不存在
            int CheckResult = 0;
            #region 扫描数据统计表查重
            // 遍历扫描数据统计表的"虚拟主键" if= 扫描到的数据的"虚拟主键"
            int RowsCounts = dgv_CumulativeData.Rows.Count;
            //System.Diagnostics.Debug.WriteLine(RowsCounts);
            // 扫描到的数据值
            string usedInfodataOtherID = usedInfodata.OtherID;
            if (RowsCounts>0)
            {
                //除了最后一行以外的值
                for (int RowsCount = 0; RowsCount < RowsCounts-1; RowsCount++)
                {
                    string hisyOtherIDstr = dgv_CumulativeData.Rows[RowsCount].Cells["hisyOtherID"].Value.ToString();

                    // 未通过
                    if (hisyOtherIDstr == usedInfodataOtherID)
                    {
                        // 存在，停止后续处理并提示该表单刚扫描过
                        CheckResult = 1;
                        break;
                    }
                }
                // 最后一行
                if(CheckResult == 0)
                {
                    string hisyOtherIDstr = dgv_CumulativeData.Rows[RowsCounts-1].Cells["hisyOtherID"].Value.ToString();
                    if (hisyOtherIDstr == usedInfodataOtherID)
                    {
                        // 存在，但是上张扫描的一个；停止后续处理
                        CheckResult = 2;
                    }
                }
            }
            #endregion
            #region 数据库查重
            if (CheckResult==0) {
                // 数据库是否登过这条数据
                int DataRepeatCheckint = mainFormDAL.DataRepeatCheck(usedInfodataOtherID);
                // 数据库登过这条数据
                if (DataRepeatCheckint == 1)
                {
                    //存在，停止后续处理并提示该表单刚扫描过
                    CheckResult = 1;
                }
                // 数据库未登过这条数据
                if (DataRepeatCheckint == 0)
                {
                    //不存在
                    CheckResult = 0;
                }
            }
            #endregion
            return CheckResult;
        }

        /// <summary>
        /// 查数据
        /// </summary>
        /// <returns></returns>
        private int SelectData()
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
                    // 把扫描到的数据绘制到"当前扫描数据区域"并提示错误信息
                    return 0;
                }
                else
                {
                    // 绘制到"当前扫描数据区域"
                    CurrentDataSHIL = result.DataTable;
                    //bds_CumulativeData.DataSource = CurrentDataSHIL;
                    //dgv_CumulativeData.DataSource = bds_CumulativeData;
                    return 1;
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
                    // 把扫描到的数据绘制到"当前扫描数据区域"并提示错误信息
                    return 0;
                }
                else
                {
                    // 绘制到"当前扫描数据区域"
                    CurrentDataHNCL = result.DataTable;
                    return 1;
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
                    // 把扫描到的数据绘制到"当前扫描数据区域"并提示错误信息
                    return 0;
                }
                else
                {
                    // 绘制到"当前扫描数据区域"
                    CurrentDataCWDL = result.DataTable;
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 比对数据
        /// </summary>
        /// <returns>0-未通过/1-通过/2-不是表单</returns>
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
                // 模拟主键
                string HospitalizationNumberstr = CurrentDataSHIL.Rows[0]["HospitalizationNumber"].ToString();
                // 条形码
                string TagCodestr = CurrentDataSHIL.Rows[0]["TagCode"].ToString();
                //System.Diagnostics.Debug.Print("数据库" + TagCodestr);
                //System.Diagnostics.Debug.Print("扫描件" + usedInfodata.TagCode);
                #region 条形码处理
                string[] CurrentDataSHILArray = TagCodestr.Split(',');        // 数据库里
                string[] ScannedSHILArray = usedInfodata.TagCode.Split(',');  // 扫描到的表单

                // 是否添加到“多的条形码”，0-不添加；1-添加
                int BadCodescheck = 0;
                // 遍历对比
                for (int noo = 0; noo < ScannedSHILArray.Length; noo++)
                {
                    for (int not = 0; not < CurrentDataSHILArray.Length; not++)
                    {

                        if (ScannedSHILArray[noo] == CurrentDataSHILArray[not])
                        {

                            // 不添加
                            BadCodescheck = 0;
                            //System.Diagnostics.Debug.WriteLine("no2:  " + noo + " - " + not);
                            break;
                        }
                        else
                        {
                            //System.Diagnostics.Debug.WriteLine("找不到  " + noo);
                            // 添加
                            BadCodescheck = 1;
                        }
                    }
                    // 需要添加
                    if (BadCodescheck == 1)
                    {
                        // 添加到“多的条形码”
                        BadCodes = BadCodes + ScannedSHILArray[noo] + ',';
                    }
                }

                // [不存在“多的条形码”数] 或[扫描到的条形码条数 < 数据库有的条形码条数]
                if (BadCodes.Length > 0 || ScannedSHILArray.Length < CurrentDataSHILArray.Length)
                {
                    // 是否添加到“少的条形码”，0-不添加；1-添加
                    int MissingCodescheck = 0;
                    // 个数相同时
                    for (int noo = 0; noo < CurrentDataSHILArray.Length; noo++)
                    {
                        for (int not = 0; not < ScannedSHILArray.Length; not++)
                        {
                            if (CurrentDataSHILArray[noo] == ScannedSHILArray[not])
                            {
                                // 不添加
                                MissingCodescheck = 0;
                                break;
                            }
                            else
                            {
                                // 添加
                                MissingCodescheck = 1;
                            }
                        }
                        // 需要添加
                        if (MissingCodescheck == 1)
                        {
                            // 添加到“少的条形码”
                            MissingCodes = MissingCodes + CurrentDataSHILArray[noo] + ',';
                        }
                    }
                }
                #endregion

                // 对比
                if (usedInfodata.OtherID == HospitalizationNumberstr &&
                    BadCodes.Length<=0 && MissingCodes.Length <= 0 &&
                    usedInfodata.Sign == "[1, 1, 1, 1]"
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
                // 条形码
                string TagCodestr = CurrentDataHNCL.Rows[0]["TagCode"].ToString();
                //System.Diagnostics.Debug.Print("数据库"+ TagCodestr);
                //System.Diagnostics.Debug.Print("扫描件" + usedInfodata.TagCode);

                #region 条形码处理
                string[] CurrentDataSHILArray = TagCodestr.Split(',');        // 数据库里
                string[] ScannedSHILArray = usedInfodata.TagCode.Split(',');  // 扫描到的表单

                // 是否添加到“多的条形码”，0-不添加；1-添加
                int BadCodescheck = 0;
                // 遍历对比
                for (int noo = 0; noo < ScannedSHILArray.Length; noo++)
                {
                    for (int not = 0; not < CurrentDataSHILArray.Length; not++)
                    {

                        if (ScannedSHILArray[noo] == CurrentDataSHILArray[not])
                        {

                            // 不添加
                            BadCodescheck = 0;
                            //System.Diagnostics.Debug.WriteLine("no2:  " + noo + " - " + not);
                            break;
                        }
                        else
                        {
                            //System.Diagnostics.Debug.WriteLine("找不到  " + noo);
                            // 添加
                            BadCodescheck = 1;
                        }
                    }
                    // 需要添加
                    if (BadCodescheck == 1)
                    {
                        // 添加到“多的条形码”
                        BadCodes = BadCodes + ScannedSHILArray[noo] + ',';
                    }
                }

                // [不存在“多的条形码”数] 或[扫描到的条形码条数 < 数据库有的条形码条数]
                if (BadCodes.Length > 0 || ScannedSHILArray.Length < CurrentDataSHILArray.Length)
                {
                    // 是否添加到“少的条形码”，0-不添加；1-添加
                    int MissingCodescheck = 0;
                    // 个数相同时
                    for (int noo = 0; noo < CurrentDataSHILArray.Length; noo++)
                    {
                        for (int not = 0; not < ScannedSHILArray.Length; not++)
                        {
                            if (CurrentDataSHILArray[noo] == ScannedSHILArray[not])
                            {
                                // 不添加
                                MissingCodescheck = 0;
                                break;
                            }
                            else
                            {
                                // 添加
                                MissingCodescheck = 1;
                            }
                        }
                        // 需要添加
                        if (MissingCodescheck == 1)
                        {
                            // 添加到“少的条形码”
                            MissingCodes = MissingCodes + CurrentDataSHILArray[noo] + ',';
                        }
                    }
                }
                #endregion
                if (usedInfodata.OtherID == HospitalizationNumberstr &&
                    BadCodes.Length <= 0 && MissingCodes.Length <= 0)
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
                //System.Diagnostics.Debug.Print("数据库" + TagCodestr);
                //System.Diagnostics.Debug.Print("扫描件" + usedInfodata.TagCode);
                if (TagCodestr == usedInfodata.TagCode &&
                    usedInfodata.Sign == "[1, 1, 1, 1]"
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