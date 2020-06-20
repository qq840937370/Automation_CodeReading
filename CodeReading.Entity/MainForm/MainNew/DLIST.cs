/*-------------------------------------------------------------------------------
* 系统名称  ：医院财务表单读取系统
* 功能模块名：医院财务表单读取系统主功能页
* 类名      ：DLIST
* 概要      ：高值日清单
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
    /// "高值日清单"信息
    /// </summary>
    public class DLIST
    {
        /// <summary>
        /// 表单标题
        /// </summary>
        public string FormsTitle { get; set; }
        /// <summary>
        /// 查询日期
        /// </summary>
        public string QueryDate { get; set; }

        /// <summary>
        /// 计费科室
        /// </summary>
        public string BillingDepartment { get; set; }
        /// <summary>
        /// 本页合计金额
        /// </summary>
        public string AmountOnThisPage { get; set; }
        /// <summary>
        /// 表单总金额
        /// </summary>
        public string TotalAmount { get; set; }

        /// <summary>
        /// 科室签字
        /// </summary>
        public string DepartmentSignature { get; set; }
        /// <summary>
        /// 科室盖章
        /// </summary>
        public string DepartmentSeal { get; set; }
    }
}
