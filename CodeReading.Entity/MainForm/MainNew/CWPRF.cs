/*-------------------------------------------------------------------------------
* 系统名称  ：医院财务表单读取系统
* 功能模块名：医院财务表单读取系统主功能页
* 类名      ：CWPRF
* 概要      ：耗材仓库采购退货单
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
    /// "耗材仓库采购退货单"信息
    /// </summary>
    public class CWPRF
    {
        /// <summary>
        /// 表单标题
        /// </summary>
        public string FormsTitle { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName { get; set; }
        /// <summary>
        /// 退货时间
        /// </summary>
        public string ReturnTime { get; set; }
        /// <summary>
        /// 退货单号
        /// </summary>
        public string ReturnOrderNo { get; set; }

        /// <summary>
        /// 本页总金额
        /// </summary>
        public string AmountOnThisPage { get; set; }
        /// <summary>
        /// 表单总金额
        /// </summary>
        public string TotalAmount { get; set; }

        /// <summary>
        /// 仓管员
        /// </summary>
        public string WarehouseOperator { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string Supplier { get; set; }
    }
}
