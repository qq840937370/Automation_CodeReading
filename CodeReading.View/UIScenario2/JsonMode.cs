using CodeReading.Entity.MainForm.MainNew;
using CodeReading.View.BLL.MainFormNew;
using CodeReading.View.BLL.MainFormWanXu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeReading.View.UIScenario2
{
    public partial class JsonMode : Form
    {
        // 新-有逻辑
        MainFormBLLNew mainFormBLLNew = new MainFormBLLNew();
        // 万旭有返回值
        MainFormBLLWanXu mainFormBLLWanXu = new MainFormBLLWanXu();
        public JsonMode()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string DBid = "CWSL";

            switch (DBid)
            {
                // 耗材仓库耗材入库单
                case "CWSL":
                    //mainFormBLLNew.CWSLList(out string CWSL_id, out string CWSL_TotalAmount, out string CWSL_Sign, out string CWSL_Pass);
                    mainFormBLLWanXu.CWSLList(out string CWSL_id, out string CWSL_TotalAmount, out string CWSL_Sign, out string CWSL_Pass,out string Information);
                    lbl_Page.Text = CWSL_id;
                    lbl_JinQian.Text = CWSL_TotalAmount;
                    lbl_QianZi.Text = CWSL_Sign;
                    lbl_Seal.Visible = false;
                    lbl_Pass.Text = CWSL_Pass;
                    lbl_Infomation.Text = Information;
                    break;
                // 耗材仓库配送出库单
                case "CWDL":
                    //mainFormBLLNew.CWDLList(out string CWDL_id, out string CWDL_TotalAmount, out string CWDL_Sign, out string CWDL_Seal, out string CWDL_Pass);
                    mainFormBLLWanXu.CWDLList(out string CWDL_id, out string CWDL_TotalAmount, out string CWDL_Sign, out string CWDL_Seal, out string CWDL_Pass);
                    lbl_Page.Text = CWDL_id;
                    lbl_JinQian.Text = CWDL_TotalAmount;
                    lbl_QianZi.Text = CWDL_Sign;
                    lbl_Seal.Visible = true;
                    lbl_Seal.Text = CWDL_Seal;
                    lbl_Pass.Text = CWDL_Pass;
                    break;
                // 


                // 其他
                case "":
                    break;
            }
        }
    }
}
