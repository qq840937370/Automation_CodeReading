/*-------------------------------------------------------------------------------
* 系统名称  ：医院财务表单读取系统
* 功能模块名：医院财务表单读取系统主功能页
* 类名      ：CWDL
* 概要      ：耗材仓库配送出库单
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
    /// "耗材仓库配送出库单"信息
    /// </summary>
    public class CWDL
    {
        /// <summary>
        /// 表单标题
        /// </summary>
        public string FormsTitle { get; set; }
        /// <summary>
        /// 领用科室名称
        /// </summary>
        public string NameOfCollectingDepartment { get; set; }
        /// <summary>
        /// 出库日期
        /// </summary>
        public string DataOfOutbound { get; set; }
        /// <summary>
        /// 出库单号
        /// </summary>
        public string OutboundOrderNo { get; set; }
        /// <summary>
        /// 流水号
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public string NumberOfPages { get; set; }
        /// <summary>
        /// 本页合计
        /// </summary>
        public string AmountOnThisPage { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public string TotalAmount { get; set; }

        /// <summary>
        /// 复核人
        /// </summary>
        public string Auditor { get; set; }
        /// <summary>
        /// 配送人
        /// </summary>
        public string Distributor { get; set; }
        /// <summary>
        /// 科室收货人
        /// </summary>
        public string DepartmentConsignee { get; set; }
        /// <summary>
        /// 科室盖章
        /// </summary>
        public bool DepartmentSeal { get; set; }

    }
}
