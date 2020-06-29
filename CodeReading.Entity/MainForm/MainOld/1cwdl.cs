using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CodeReading.Entity.MainForm
{
    class _1cwdl
    {
        /// <summary>
        /// 领用科室
        /// </summary>
        public string ReceivingDepartment { get; set; }

        /// <summary>
        /// 配送部门
        /// </summary>
        public string DistributionDepartment { get; set; }

        /// <summary>
        /// 申领人
        /// </summary>
        public string Claimant { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 打印日期
        /// </summary>
        public string PrintDate { get; set; }

        /// <summary>
        /// 出库日期
        /// </summary>
        public string IssueDate { get; set; }

        /// <summary>
        /// 出库单号
        /// </summary>
        public string DeliveryOrderNo { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public string NoNumber { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string CommodityName { get; set; }

        /// <summary>
        /// 规格型
        /// </summary>
        public string SpecificationType { get; set; }

        /// <summary>
        /// 生产厂家
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 批号
        /// </summary>
        public string BatchNumbe { get; set; }

        /// <summary>
        /// 效期
        /// </summary>
        public string PeriodOfValidity { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public string UnitPrice { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public string AmountOfMoney { get; set; }

        /// <summary>
        /// 本页合计
        /// </summary>
        public string TotalOfThisPage { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        public string TotalAmount { get; set; }

        /// <summary>
        /// 条形码
        /// </summary>
        public string TagCode { get; set; }

        /// <summary>
        /// 标签数
        /// </summary>
        public string TagCodeNumbers { get; set; }
    }
}
