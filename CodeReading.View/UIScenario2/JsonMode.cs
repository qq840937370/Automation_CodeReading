using CodeReading.Entity.MainForm.MainNew;
using CodeReading.View.BLL.MainFormNew;
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
        CWSLList cWSLList = new CWSLList();
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
            #region 扫描到的信息-假
            // 扫描到的信息
            //供应商
            //入库日期
            //入库单号
            //本页合计金额
            //表单总金额
            //验收人
            //供应商
            //仓库员
            // 扫描到的值-cWSL_ComparisonInformation
            CWSL cWSL_ComparisonInformation = new CWSL();
            cWSL_ComparisonInformation.SupplierName = "济南鹏程医疗设备有限公司";
            cWSL_ComparisonInformation.InboundDate = "2020-06-10";
            cWSL_ComparisonInformation.ReceiptNo = "80462720";

            cWSL_ComparisonInformation.NumberOfPages = "1/1";
            cWSL_ComparisonInformation.TotalAmount = "977.5";

            cWSL_ComparisonInformation.AcceptanceOfThePeople = "许欣伟";
            cWSL_ComparisonInformation.Supplier = "张楠林";
            cWSL_ComparisonInformation.WarehouseOperator = "刘月";
            #endregion

            #region 向服务器请求数据-假
            // 请求条件-略
            // 请求到的值-cWSL_ComparisonInformationSource
            CWSL cWSL_ComparisonInformationSource = new CWSL();
            cWSL_ComparisonInformationSource=cWSLList.Readjson();
            //System.Diagnostics.Debug.WriteLine(cWSL_ComparisonInformationSource.SupplierName.ToString());
            #endregion

            #region 对比
            // 表单总金额=JSON文件：表单总金额
            {
                if (cWSL_ComparisonInformation.TotalAmount == cWSL_ComparisonInformationSource.TotalAmount &&
                    cWSL_ComparisonInformation.AcceptanceOfThePeople.Length > 0 &&
                    cWSL_ComparisonInformation.Supplier.Length > 0 &&
                    cWSL_ComparisonInformation.WarehouseOperator.Length > 0)
                {
                    lbl_JinQian.Text = "金钱数一致";
                    lbl_QianZi.Text = "已签字";
                    lbl_Pass.Text = "已通过";
                }
                else
                {
                    if (cWSL_ComparisonInformation.TotalAmount != cWSL_ComparisonInformationSource.TotalAmount)
                    {
                        lbl_JinQian.Text = "金钱数不一致";
                    }
                    // 验收人
                    string QianZistr = "";
                    // 验收人
                    if (cWSL_ComparisonInformation.AcceptanceOfThePeople.Length <= 0)
                    {
                        QianZistr += "'验收人' ";
                    }
                    // 供应商
                    if (cWSL_ComparisonInformation.Supplier.Length <= 0)
                    {
                        QianZistr += "'供应商' ";
                    }
                    // 仓库员
                    if (cWSL_ComparisonInformation.WarehouseOperator.Length <= 0)
                    {
                        QianZistr += "'仓库员' ";
                    }
                    if (QianZistr.Length > 0)
                    {
                        QianZistr += "未签字";
                        lbl_QianZi.Text = QianZistr;
                    }
                    lbl_Pass.Text = "未通过";
                }
            }
            #endregion


        }
    }
}
