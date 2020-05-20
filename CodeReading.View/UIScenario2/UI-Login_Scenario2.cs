////using Automation_CodeReadingBLL;
////using Automation_CodeReadingModel;
//using System;
//using System.Windows.Forms;

//namespace CodeReading.View
//{
//    public partial class UI_Login_Scenario2 : Form
//    {
//        /// <summary>
//        /// WinForm加载事件
//        /// </summary>
//        public UI_Login_Scenario2()
//        {
//            InitializeComponent();
//        }
//        LoginInfoBLL loginInfoBLL = new LoginInfoBLL();  // 实例化bll对象
//        private void UI_Login_Scenario2_Load(object sender, EventArgs e)
//        {
//        }
//        /// <summary>
//        /// “登录”按钮
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void btnLogin_Click(object sender, EventArgs e)
//        {
//            // 获取用户信息
//            string uname = txtUName.Text.Trim();
//            string upwd = txtUPwd.Text.Trim();
//            if (string.IsNullOrEmpty(uname)|| string.IsNullOrEmpty(upwd))
//            {
//                MessageBox.Show("账户与密码皆不可为空！");
//            }
//            else
//            {
//                // 传给bll层
//                LoginState state = loginInfoBLL.LoginByUnameUpwd(uname, upwd);
//                if (state == LoginState.登录)
//                {
//                    LoginInfo.state = LoginState.登录;  // 修改成登录状态
//                    UI_MainForm_Scenario2 uI_MainForm_Scenario2 = new UI_MainForm_Scenario2(uname);
//                    this.Hide();
//                    uI_MainForm_Scenario2.Show();
//                }
//                else
//                {
//                    MessageBox.Show("信息有误！请检验账户和密码重新登录！");
//                }
//            }
//        }
//        /// <summary>
//        /// “离开”按钮
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void btnClose_Click(object sender, EventArgs e)
//        {
//            Application.Exit();          // 退出应用
//        }
//    }
//}
