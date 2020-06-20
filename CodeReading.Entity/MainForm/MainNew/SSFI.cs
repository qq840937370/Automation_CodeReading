/*-------------------------------------------------------------------------------
* 系统名称  ：医院财务表单读取系统
* 功能模块名：医院财务表单读取系统主功能页
* 类名      ：SSFI
* 概要      ：供应商服务费发票
* 
* 改版履历
* Ver----------日期---------单位・姓名--------------------概要------------------
* 1.0.0.0      2020/06/17   Shandong_HuaShi ZhangSh       新建
* 
* ------------------------------------------------------------------------------
*/

namespace CodeReading.Entity.MainForm.MainNew
{
    /// <summary>
    /// "供应商服务费发票"信息
    /// </summary>
    public class SSFI
    {
        /// <summary>
        /// 表单标题
        /// </summary>
        public string FormsTitle { get; set; }
        /// <summary>
        /// 发票代码
        /// </summary>
        public string InvoiceCode { get; set; }
        /// <summary>
        /// 发票号
        /// </summary>
        public string InvoiceNo { get; set; }
        /// <summary>
        /// 发票联名称
        /// </summary>
        public string InvoiceCategory { get; set; }

        /// <summary>
        /// 发票金额
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// 发票章
        /// </summary>
        public bool Seal { get; set; }
    }
}
