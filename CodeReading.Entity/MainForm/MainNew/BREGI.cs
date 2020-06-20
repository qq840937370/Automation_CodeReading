/*-------------------------------------------------------------------------------
* 系统名称  ：医院财务表单读取系统
* 功能模块名：医院财务表单读取系统主功能页
* 类名      ：BREGI
* 概要      ：手术中使用高值耗材及植入物计费登记单
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
    /// "手术中使用高值耗材及植入物计费登记单"信息
    /// </summary>
    public class BREGI
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
        /// 病房自带耗材条形码
        /// </summary>
        public string TagCodeOfWard { get; set; }
        /// <summary>
        /// 麻醉手术科耗材条形码
        /// </summary>
        public string TagCodeOfAOD { get; set; }
        /// <summary>
        /// 手术时间
        /// </summary>
        public string OperationTime { get; set; }
        /// <summary>
        /// 手术间
        /// </summary>
        public string OperatingRoom { get; set; }
        /// <summary>
        /// 手术名称
        /// </summary>
        public string OperationName { get; set; }
        /// <summary>
        /// 手术医生
        /// </summary>
        public string Surgeon { get; set; }
        /// <summary>
        /// 手术医生联系电话
        /// </summary>
        public string PhoneOfSurgeon { get; set; }

        /// <summary>
        /// 医生
        /// </summary>
        public string Doctor { get; set; }
        /// <summary>
        /// 护士
        /// </summary>
        public string Nurse { get; set; }
    }
}
