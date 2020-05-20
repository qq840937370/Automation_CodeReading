namespace CodeReading.View
{
    partial class UI_MainForm_Scenario2
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_MainForm_Scenario2));
            this.openProjectFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveProjectFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer_Now = new System.Windows.Forms.Timer(this.components);
            this.panelMain = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_OpenCamera1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Auto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.清除异常ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_History = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.帧率ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.曝光ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.对焦ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.灰度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.通信设定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_About = new System.Windows.Forms.ToolStripMenuItem();
            this.更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Login = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Logout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsCuurrentProject = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_ImgNumber = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_CameraStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Mean = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Deviation = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsErrMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslbl_Time = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_radpnl = new System.Windows.Forms.Panel();
            this.rad_HNCL = new System.Windows.Forms.RadioButton();
            this.rad_CWDL = new System.Windows.Forms.RadioButton();
            this.rad_CaptureImg = new System.Windows.Forms.RadioButton();
            this.grp2 = new System.Windows.Forms.GroupBox();
            this.hWinctl_ICS = new HalconDotNet.HWindowControl();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.tsmi_OpenCamera = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_CaptureImg = new System.Windows.Forms.ToolStripMenuItem();
            this.grp1 = new System.Windows.Forms.GroupBox();
            this.hWinctl_RTA = new HalconDotNet.HWindowControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_Showdata = new System.Windows.Forms.DataGridView();
            this.panelMain.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_radpnl.SuspendLayout();
            this.grp2.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.grp1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Showdata)).BeginInit();
            this.SuspendLayout();
            // 
            // openProjectFileDialog
            // 
            this.openProjectFileDialog.Filter = "工程文件|*.prj";
            // 
            // saveProjectFileDialog
            // 
            this.saveProjectFileDialog.Filter = "工程文件|*.prj";
            this.saveProjectFileDialog.RestoreDirectory = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "bmp|*.bmp|All files|*.*";
            this.saveFileDialog1.RestoreDirectory = true;
            // 
            // timer_Now
            // 
            this.timer_Now.Tick += new System.EventHandler(this.timer_Now_Tick);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelMain.Controls.Add(this.menuStrip1);
            this.panelMain.Controls.Add(this.statusStrip1);
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1920, 1080);
            this.panelMain.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gray;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7,
            this.系统ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.tsmi_Help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(20, 0, 0, 20);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1920, 25);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_OpenCamera1,
            this.toolStripSeparator5,
            this.tsmi_Auto,
            this.toolStripSeparator6,
            this.清除异常ToolStripMenuItem});
            this.toolStripMenuItem7.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripMenuItem7.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem7.Image = global::CodeReading.View.Properties.Resources.saveAs;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(60, 21);
            this.toolStripMenuItem7.Text = "设备";
            // 
            // tsmi_OpenCamera1
            // 
            this.tsmi_OpenCamera1.Name = "tsmi_OpenCamera1";
            this.tsmi_OpenCamera1.Size = new System.Drawing.Size(180, 22);
            this.tsmi_OpenCamera1.Text = "打开相机";
            this.tsmi_OpenCamera1.Click += new System.EventHandler(this.tsmi_OpenCamera_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmi_Auto
            // 
            this.tsmi_Auto.Name = "tsmi_Auto";
            this.tsmi_Auto.Size = new System.Drawing.Size(180, 22);
            this.tsmi_Auto.Text = "自动捕捉";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(177, 6);
            // 
            // 清除异常ToolStripMenuItem
            // 
            this.清除异常ToolStripMenuItem.Name = "清除异常ToolStripMenuItem";
            this.清除异常ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.清除异常ToolStripMenuItem.Text = "清除异常";
            // 
            // 系统ToolStripMenuItem
            // 
            this.系统ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_History});
            this.系统ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.系统ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.系统ToolStripMenuItem.Image = global::CodeReading.View.Properties.Resources.openImg;
            this.系统ToolStripMenuItem.Name = "系统ToolStripMenuItem";
            this.系统ToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.系统ToolStripMenuItem.Text = "文件";
            // 
            // tsmi_History
            // 
            this.tsmi_History.Name = "tsmi_History";
            this.tsmi_History.Size = new System.Drawing.Size(180, 22);
            this.tsmi_History.Text = "扫描记录";
            this.tsmi_History.Click += new System.EventHandler(this.tsmi_History_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.通信设定ToolStripMenuItem});
            this.设置ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.设置ToolStripMenuItem.Image = global::CodeReading.View.Properties.Resources.Setting;
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帧率ToolStripMenuItem,
            this.曝光ToolStripMenuItem,
            this.对焦ToolStripMenuItem,
            this.灰度ToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "相机设置";
            // 
            // 帧率ToolStripMenuItem
            // 
            this.帧率ToolStripMenuItem.Name = "帧率ToolStripMenuItem";
            this.帧率ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.帧率ToolStripMenuItem.Text = "帧率";
            // 
            // 曝光ToolStripMenuItem
            // 
            this.曝光ToolStripMenuItem.Name = "曝光ToolStripMenuItem";
            this.曝光ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.曝光ToolStripMenuItem.Text = "曝光";
            // 
            // 对焦ToolStripMenuItem
            // 
            this.对焦ToolStripMenuItem.Name = "对焦ToolStripMenuItem";
            this.对焦ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.对焦ToolStripMenuItem.Text = "对焦";
            // 
            // 灰度ToolStripMenuItem
            // 
            this.灰度ToolStripMenuItem.Name = "灰度ToolStripMenuItem";
            this.灰度ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.灰度ToolStripMenuItem.Text = "灰度";
            // 
            // 通信设定ToolStripMenuItem
            // 
            this.通信设定ToolStripMenuItem.Name = "通信设定ToolStripMenuItem";
            this.通信设定ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.通信设定ToolStripMenuItem.Text = "通信设置";
            // 
            // tsmi_Help
            // 
            this.tsmi_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripSeparator4,
            this.tsmi_About,
            this.更新ToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripMenuItem6,
            this.tsmi_Login,
            this.tsmi_Logout});
            this.tsmi_Help.ForeColor = System.Drawing.Color.Black;
            this.tsmi_Help.Image = global::CodeReading.View.Properties.Resources.help;
            this.tsmi_Help.Name = "tsmi_Help";
            this.tsmi_Help.Size = new System.Drawing.Size(60, 21);
            this.tsmi_Help.Text = "帮助";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem3.Text = "产品帮助";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem4.Text = "产品教程";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem5.Text = "产品反馈";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmi_About
            // 
            this.tsmi_About.Name = "tsmi_About";
            this.tsmi_About.Size = new System.Drawing.Size(180, 22);
            this.tsmi_About.Text = "系统信息";
            this.tsmi_About.Click += new System.EventHandler(this.tsmi_About_Click);
            // 
            // 更新ToolStripMenuItem
            // 
            this.更新ToolStripMenuItem.Name = "更新ToolStripMenuItem";
            this.更新ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.更新ToolStripMenuItem.Text = "软件更新";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem6.Text = "管理我的账户";
            // 
            // tsmi_Login
            // 
            this.tsmi_Login.Enabled = false;
            this.tsmi_Login.Name = "tsmi_Login";
            this.tsmi_Login.Size = new System.Drawing.Size(180, 22);
            this.tsmi_Login.Text = "登陆";
            // 
            // tsmi_Logout
            // 
            this.tsmi_Logout.Name = "tsmi_Logout";
            this.tsmi_Logout.Size = new System.Drawing.Size(180, 22);
            this.tsmi_Logout.Text = "注销";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCuurrentProject,
            this.tssl_ImgNumber,
            this.tssl_CameraStatus,
            this.toolStripStatusLabel2,
            this.tssl_Mean,
            this.tssl_Deviation,
            this.tsErrMessage,
            this.tslbl_Time});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1058);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1920, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsCuurrentProject
            // 
            this.tsCuurrentProject.Name = "tsCuurrentProject";
            this.tsCuurrentProject.Size = new System.Drawing.Size(0, 17);
            // 
            // tssl_ImgNumber
            // 
            this.tssl_ImgNumber.ForeColor = System.Drawing.Color.Black;
            this.tssl_ImgNumber.Name = "tssl_ImgNumber";
            this.tssl_ImgNumber.Size = new System.Drawing.Size(99, 17);
            this.tssl_ImgNumber.Text = "已扫描文件：0个";
            // 
            // tssl_CameraStatus
            // 
            this.tssl_CameraStatus.ForeColor = System.Drawing.Color.Black;
            this.tssl_CameraStatus.Margin = new System.Windows.Forms.Padding(40, 3, 0, 2);
            this.tssl_CameraStatus.Name = "tssl_CameraStatus";
            this.tssl_CameraStatus.Size = new System.Drawing.Size(92, 17);
            this.tssl_CameraStatus.Text = "扫描相机未连接";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(40, 3, 0, 2);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel2.Text = "相机帧率：";
            // 
            // tssl_Mean
            // 
            this.tssl_Mean.ForeColor = System.Drawing.Color.Black;
            this.tssl_Mean.Margin = new System.Windows.Forms.Padding(40, 3, 0, 2);
            this.tssl_Mean.Name = "tssl_Mean";
            this.tssl_Mean.Size = new System.Drawing.Size(80, 17);
            this.tssl_Mean.Text = "图片平均值：";
            // 
            // tssl_Deviation
            // 
            this.tssl_Deviation.ForeColor = System.Drawing.Color.Black;
            this.tssl_Deviation.Margin = new System.Windows.Forms.Padding(40, 3, 0, 2);
            this.tssl_Deviation.Name = "tssl_Deviation";
            this.tssl_Deviation.Size = new System.Drawing.Size(68, 17);
            this.tssl_Deviation.Text = "图片方差：";
            // 
            // tsErrMessage
            // 
            this.tsErrMessage.Name = "tsErrMessage";
            this.tsErrMessage.Size = new System.Drawing.Size(1306, 17);
            this.tsErrMessage.Spring = true;
            // 
            // tslbl_Time
            // 
            this.tslbl_Time.ForeColor = System.Drawing.Color.Black;
            this.tslbl_Time.Name = "tslbl_Time";
            this.tslbl_Time.Size = new System.Drawing.Size(32, 17);
            this.tslbl_Time.Text = "时间";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.pnl_radpnl);
            this.panel1.Controls.Add(this.grp2);
            this.panel1.Controls.Add(this.menuStrip2);
            this.panel1.Controls.Add(this.grp1);
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 1034);
            this.panel1.TabIndex = 11;
            // 
            // pnl_radpnl
            // 
            this.pnl_radpnl.Controls.Add(this.rad_HNCL);
            this.pnl_radpnl.Controls.Add(this.rad_CWDL);
            this.pnl_radpnl.Controls.Add(this.rad_CaptureImg);
            this.pnl_radpnl.Location = new System.Drawing.Point(318, 1);
            this.pnl_radpnl.Name = "pnl_radpnl";
            this.pnl_radpnl.Size = new System.Drawing.Size(598, 25);
            this.pnl_radpnl.TabIndex = 14;
            // 
            // rad_HNCL
            // 
            this.rad_HNCL.AutoSize = true;
            this.rad_HNCL.ForeColor = System.Drawing.Color.Black;
            this.rad_HNCL.Location = new System.Drawing.Point(389, 6);
            this.rad_HNCL.Name = "rad_HNCL";
            this.rad_HNCL.Size = new System.Drawing.Size(131, 16);
            this.rad_HNCL.TabIndex = 2;
            this.rad_HNCL.Text = "高净值耗材使用清单";
            this.rad_HNCL.UseVisualStyleBackColor = true;
            this.rad_HNCL.Click += new System.EventHandler(this.rad_HNCL_Click);
            // 
            // rad_CWDL
            // 
            this.rad_CWDL.AutoSize = true;
            this.rad_CWDL.ForeColor = System.Drawing.Color.Black;
            this.rad_CWDL.Location = new System.Drawing.Point(180, 6);
            this.rad_CWDL.Name = "rad_CWDL";
            this.rad_CWDL.Size = new System.Drawing.Size(131, 16);
            this.rad_CWDL.TabIndex = 1;
            this.rad_CWDL.Text = "耗材仓库配送出库单";
            this.rad_CWDL.UseVisualStyleBackColor = true;
            this.rad_CWDL.Click += new System.EventHandler(this.rad_CWDL_Click);
            // 
            // rad_CaptureImg
            // 
            this.rad_CaptureImg.AutoSize = true;
            this.rad_CaptureImg.BackColor = System.Drawing.Color.Transparent;
            this.rad_CaptureImg.Checked = true;
            this.rad_CaptureImg.ForeColor = System.Drawing.Color.Black;
            this.rad_CaptureImg.Location = new System.Drawing.Point(3, 6);
            this.rad_CaptureImg.Name = "rad_CaptureImg";
            this.rad_CaptureImg.Size = new System.Drawing.Size(107, 16);
            this.rad_CaptureImg.TabIndex = 0;
            this.rad_CaptureImg.TabStop = true;
            this.rad_CaptureImg.Text = "植入物使用清单";
            this.rad_CaptureImg.UseVisualStyleBackColor = false;
            this.rad_CaptureImg.Click += new System.EventHandler(this.rad_CaptureImg_Click);
            // 
            // grp2
            // 
            this.grp2.Controls.Add(this.hWinctl_ICS);
            this.grp2.ForeColor = System.Drawing.Color.Black;
            this.grp2.Location = new System.Drawing.Point(742, 34);
            this.grp2.Name = "grp2";
            this.grp2.Size = new System.Drawing.Size(717, 983);
            this.grp2.TabIndex = 2;
            this.grp2.TabStop = false;
            this.grp2.Text = "实时捕捉";
            // 
            // hWinctl_ICS
            // 
            this.hWinctl_ICS.BackColor = System.Drawing.Color.Black;
            this.hWinctl_ICS.BorderColor = System.Drawing.Color.Black;
            this.hWinctl_ICS.ImagePart = new System.Drawing.Rectangle(0, 0, 3020, 3850);
            this.hWinctl_ICS.Location = new System.Drawing.Point(9, 17);
            this.hWinctl_ICS.Name = "hWinctl_ICS";
            this.hWinctl_ICS.Size = new System.Drawing.Size(700, 957);
            this.hWinctl_ICS.TabIndex = 1;
            this.hWinctl_ICS.WindowSize = new System.Drawing.Size(700, 957);
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_OpenCamera,
            this.tsmi_CaptureImg});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1920, 25);
            this.menuStrip2.TabIndex = 12;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // tsmi_OpenCamera
            // 
            this.tsmi_OpenCamera.ForeColor = System.Drawing.Color.Black;
            this.tsmi_OpenCamera.Image = global::CodeReading.View.Properties.Resources.video;
            this.tsmi_OpenCamera.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tsmi_OpenCamera.Name = "tsmi_OpenCamera";
            this.tsmi_OpenCamera.Size = new System.Drawing.Size(84, 21);
            this.tsmi_OpenCamera.Text = "打开相机";
            this.tsmi_OpenCamera.Click += new System.EventHandler(this.tsmi_OpenCamera_Click);
            // 
            // tsmi_CaptureImg
            // 
            this.tsmi_CaptureImg.ForeColor = System.Drawing.Color.Black;
            this.tsmi_CaptureImg.Image = global::CodeReading.View.Properties.Resources.saveProject;
            this.tsmi_CaptureImg.Name = "tsmi_CaptureImg";
            this.tsmi_CaptureImg.Size = new System.Drawing.Size(84, 21);
            this.tsmi_CaptureImg.Text = "捕捉图像";
            this.tsmi_CaptureImg.Click += new System.EventHandler(this.tsmi_CaptureImg_Click);
            // 
            // grp1
            // 
            this.grp1.Controls.Add(this.hWinctl_RTA);
            this.grp1.ForeColor = System.Drawing.Color.Black;
            this.grp1.Location = new System.Drawing.Point(21, 34);
            this.grp1.Name = "grp1";
            this.grp1.Size = new System.Drawing.Size(715, 983);
            this.grp1.TabIndex = 1;
            this.grp1.TabStop = false;
            this.grp1.Text = "实时影像";
            // 
            // hWinctl_RTA
            // 
            this.hWinctl_RTA.BackColor = System.Drawing.Color.Black;
            this.hWinctl_RTA.BorderColor = System.Drawing.Color.Black;
            this.hWinctl_RTA.ImagePart = new System.Drawing.Rectangle(16, 0, 3020, 3850);
            this.hWinctl_RTA.Location = new System.Drawing.Point(7, 17);
            this.hWinctl_RTA.Name = "hWinctl_RTA";
            this.hWinctl_RTA.Size = new System.Drawing.Size(700, 957);
            this.hWinctl_RTA.TabIndex = 0;
            this.hWinctl_RTA.WindowSize = new System.Drawing.Size(700, 957);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_Showdata);
            this.groupBox1.Location = new System.Drawing.Point(1466, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 983);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据显示";
            // 
            // dgv_Showdata
            // 
            this.dgv_Showdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Showdata.Location = new System.Drawing.Point(7, 17);
            this.dgv_Showdata.Name = "dgv_Showdata";
            this.dgv_Showdata.RowTemplate.Height = 23;
            this.dgv_Showdata.Size = new System.Drawing.Size(429, 957);
            this.dgv_Showdata.TabIndex = 17;
            // 
            // UI_MainForm_Scenario2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "UI_MainForm_Scenario2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "华时数字工业相机读码_内测版_V1.0";
            this.Load += new System.EventHandler(this.UI_MainForm_Scenario2_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_radpnl.ResumeLayout(false);
            this.pnl_radpnl.PerformLayout();
            this.grp2.ResumeLayout(false);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.grp1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Showdata)).EndInit();
            this.ResumeLayout(false);

        }



        #endregion
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.OpenFileDialog openProjectFileDialog;
        private System.Windows.Forms.SaveFileDialog saveProjectFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer timer_Now;
        private System.Windows.Forms.GroupBox grp2;
        private HalconDotNet.HWindowControl hWinctl_ICS;
        private System.Windows.Forms.GroupBox grp1;
        private HalconDotNet.HWindowControl hWinctl_RTA;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_OpenCamera;
        private System.Windows.Forms.ToolStripMenuItem tsmi_CaptureImg;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsCuurrentProject;
        private System.Windows.Forms.ToolStripStatusLabel tssl_ImgNumber;
        private System.Windows.Forms.ToolStripStatusLabel tssl_CameraStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsErrMessage;
        private System.Windows.Forms.ToolStripStatusLabel tslbl_Time;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Mean;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Deviation;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem tsmi_OpenCamera1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Auto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem 清除异常ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_History;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 帧率ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 曝光ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 对焦ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 灰度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 通信设定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Help;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmi_About;
        private System.Windows.Forms.ToolStripMenuItem 更新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Login;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Logout;
        private System.Windows.Forms.Panel pnl_radpnl;
        private System.Windows.Forms.RadioButton rad_HNCL;
        private System.Windows.Forms.RadioButton rad_CWDL;
        private System.Windows.Forms.RadioButton rad_CaptureImg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_Showdata;
    }
}