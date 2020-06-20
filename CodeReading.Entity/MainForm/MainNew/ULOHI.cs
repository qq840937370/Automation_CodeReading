/*-------------------------------------------------------------------------------
* 系统名称  ：医院财务表单读取系统
* 功能模块名：医院财务表单读取系统主功能页
* 类名      ：ULOHI
* 概要      ：跟台人体植入物使用清单
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
    /// "跟台人体植入物使用清单"信息
    /// </summary>
    public class ULOHI
    {
        /// <summary>
        /// 表单标题
        /// </summary>
        public string FormsTitle { get; set; }
        /// <summary>
        /// 住院号
        /// </summary>
        public string InpatientNo { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 手术日期
        /// </summary>
        public string OperationDate { get; set; }

        /// <summary>
        /// 标签码
        /// </summary>
        public string TagCode { get; set; }
        /// <summary>
        /// 标签数
        /// </summary>
        public string NumberOfTagCode { get; set; }

        /// <summary>
        /// 手术医生
        /// </summary>
        public string Surgeon { get; set; }
        /// <summary>
        /// 手术护士
        /// </summary>
        public string Nurse { get; set; }
        /// <summary>
        /// SPD/交接人
        /// </summary>
        public string SPDHandoverPerson { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string Supplier { get; set; }
    }
}
