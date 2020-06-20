/*-------------------------------------------------------------------------------
* 系统名称  ：医院财务表单读取系统
* 功能模块名：医院财务表单读取系统主功能页
* 类名      ：ASLIST
* 概要      ：麻醉记账单
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
    /// "麻醉记账单"信息
    /// </summary>
    public class ASLIST
    {
        /// <summary>
        /// 表单标题
        /// </summary>
        public string FormsTitle { get; set; }
        /// <summary>
        /// 左框条形码
        /// </summary>
        public string TagCodeOfUpperLeftCorner { get; set; }
        /// <summary>
        /// 手术日期
        /// </summary>
        public string OperationDate { get; set; }
        /// <summary>
        /// 住院号
        /// </summary>
        public string InpatientNo { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string PatientName { get; set; }

        /// <summary>
        /// 主麻医生
        /// </summary>
        public string Anesthetist { get; set; }
        /// <summary>
        /// 接班医生
        /// </summary>
        public string SuccessionDoctor { get; set; }
        /// <summary>
        /// 下级医生
        /// </summary>
        public string JuniorDoctor { get; set; }
    }
}
