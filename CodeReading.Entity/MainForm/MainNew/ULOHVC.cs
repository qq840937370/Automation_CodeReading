/*-------------------------------------------------------------------------------
* 系统名称  ：医院财务表单读取系统
* 功能模块名：医院财务表单读取系统主功能页
* 类名      ：ULOHVC
* 概要      ：高值耗材使用清单
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
    /// "高值耗材使用清单"信息
    /// </summary>
    public class ULOHVC
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
        /// 姓名
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
        /// 当前合计总金额
        /// </summary>
        public string AmountOnThisPage { get; set; }
        /// <summary>
        /// 当前合计总数量
        /// </summary>
        public string NumberOnThisPage { get; set; }

        /// <summary>
        /// 手术医生
        /// </summary>
        public string Surgeon { get; set; }
        /// <summary>
        /// 护士
        /// </summary>
        public string Nurse { get; set; }
        /// <summary>
        /// 跟台人员
        /// </summary>
        public string Attendant { get; set; }

        /// <summary>
        /// 背面表单标题
        /// </summary>
        public string BackFormsTitle { get; set; }
        /// <summary>
        /// 背面住院号
        /// </summary>
        public string BackInpatientNo { get; set; }
        /// <summary>
        /// 背面姓名
        /// </summary>
        public string BackPatientName { get; set; }
        /// <summary>
        /// 背面标签码
        /// </summary>
        public string BackTagCode { get; set; }
    }
}
