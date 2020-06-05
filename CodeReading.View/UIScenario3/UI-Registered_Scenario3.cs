using System;
using System.Windows.Forms;

namespace CodeReading.View
{
    public partial class UI_Registered_Scenario3 : Form
    {
        public UI_Registered_Scenario3()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string SoftKeyStr = txt_SoftKey.Text; //获取页面机器码

            string SoftKey = "成功";              //去数据库检索，检索到返回成功

            if (SoftKey == "成功")
            {
                try
                {
                    // 修改本地用户信息内容，不用每次都输入机器码

                    // 在服务器下载一个文件（用户信息）放到一个隐秘位置，在后面功能代码里验证文件是否存在，在用来防破解。
                }
                catch { }
                finally
                {

                }

                MessageBox.Show("注册成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("注册失败,请输入有效机器码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
