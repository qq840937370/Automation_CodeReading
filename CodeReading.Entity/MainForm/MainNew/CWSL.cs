/*-------------------------------------------------------------------------------
* 系统名称  ：医院财务表单读取系统
* 功能模块名：医院财务表单读取系统主功能页
* 类名      ：CWSL
* 概要      ：耗材仓库耗材入库单
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
    /// "耗材仓库耗材入库单"信息
    /// </summary>
    public class CWSL
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
        /// 入库日期
        /// </summary>
        public string InboundDate { get; set; }
        /// <summary>
        /// 入库单号
        /// </summary>
        public string ReceiptNo { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public string NumberOfPages { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public string TotalAmount { get; set; }

        /// <summary>
        /// 验收人
        /// </summary>
        public string AcceptanceOfThePeople { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string Supplier { get; set; }
        /// <summary>
        /// 仓管员
        /// </summary>
        public string WarehouseOperator { get; set; }
    }
}
