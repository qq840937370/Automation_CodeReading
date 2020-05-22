/*-------------------------------------------------------------------------------
* 系统名称  ：工业自动化系统
* 子系统名称：工业相机识码子系统
* 功能模块名：工业相机识码主页
* 类名      ：DataCWDL
* 概要      ："耗材仓库配送出库单"信息
* 
* 改版履历
* Ver----------日期---------单位・姓名--------------------概要------------------
* 1.0.0.0      2020/05/18   Shandong_HuaShi ZhangSh       新建
* 
* ------------------------------------------------------------------------------
*/
using CodeReading.Entity.Comm;
using System.Runtime.Serialization;

namespace CodeReading.Entity.MainForm
{
    /// <summary>
    /// "耗材仓库配送出库单"信息
    /// </summary>
    [DataContract]
    public class DataCWDL
    {
        /// <summary>
        /// 取得或设定处理是否正常结束
        /// </summary>
        [DataMember]
        public bool Suceeded { get; set; }

        /// <summary>
        /// 获取或设置错误信息
        /// </summary>
        [DataMember]
        public ErrorInfo ErrorInfo { get; set; }

        /// <summary>
        /// 获取或设置检索的数据
        /// </summary>
        [DataMember]
        public MainFormDataSet.CWDLDataTable cWDLDataTable = new MainFormDataSet.CWDLDataTable();

        /// <summary>
        /// 领用科室
        /// </summary>
        [DataMember]
        public string ReceivingDepartment { get; set; }

        /// <summary>
        /// 配送部门
        /// </summary>
        [DataMember]
        public string DistributionDepartment { get; set; }

        /// <summary>
        /// 申领人
        /// </summary>
        [DataMember]
        public string Claimant { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remarks { get; set; }

        /// <summary>
        /// 打印日期
        /// </summary>
        [DataMember]
        public string PrintDate { get; set; }

        /// <summary>
        /// 出库日期
        /// </summary>
        [DataMember]
        public string IssueDate { get; set; }

        /// <summary>
        /// 出库单号
        /// </summary>
        [DataMember]
        public string DeliveryOrderNo { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        [DataMember]
        public string SerialNumber { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        [DataMember]
        public string NoNumber { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [DataMember]
        public string Type { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [DataMember]
        public string CommodityName { get; set; }

        /// <summary>
        /// 规格型
        /// </summary>
        [DataMember]
        public string SpecificationType { get; set; }

        /// <summary>
        /// 生产厂家
        /// </summary>
        [DataMember]
        public string Manufacturer { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [DataMember]
        public string Company { get; set; }

        /// <summary>
        /// 批号
        /// </summary>
        [DataMember]
        public string BatchNumbe { get; set; }

        /// <summary>
        /// 效期
        /// </summary>
        [DataMember]
        public string PeriodOfValidity { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        [DataMember]
        public string UnitPrice { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [DataMember]
        public string Number { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [DataMember]
        public string AmountOfMoney { get; set; }

        /// <summary>
        /// 本页合计
        /// </summary>
        [DataMember]
        public string TotalOfThisPage { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        [DataMember]
        public string TotalAmount { get; set; }

        /// <summary>
        /// 条形码
        /// </summary>
        [DataMember]
        public string TagCode { get; set; }

        /// <summary>
        /// 标签数
        /// </summary>
        [DataMember]
        public string TagCodeNumbers { get; set; }

    }
}
