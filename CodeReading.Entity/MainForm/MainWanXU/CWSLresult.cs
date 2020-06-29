/*-------------------------------------------------------------------------------
* 系统名称  ：医院财务表单读取系统
* 功能模块名：医院财务表单读取系统主功能页
* 类名      ：CWSLresult
* 概要      ：耗材仓库耗材入库单结果返回
* 
* 改版履历
* Ver----------日期---------单位・姓名--------------------概要------------------
* 1.0.0.0      2020/06/24   Shandong_HuaShi ZhangSh       新建
* 
* ------------------------------------------------------------------------------
*/

namespace CodeReading.Entity.MainForm.MainWanXU
{
    /// <summary>
    /// "耗材仓库耗材入库单"信息
    /// </summary>
    public class CWSLresult
    {
        /// <summary>
        /// 表单标题
        /// </summary>
        public string SUCCEED { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string MESSAGE  { get; set; }
        /// <summary>
        /// 明细行数
        /// </summary>
        public string TOTAL_RECORDS { get; set; }
        /// <summary>
        /// 入库单号
        /// </summary>
        public string INSOUTNO { get; set; }
        /// <summary>
        /// 单据页序号
        /// </summary>
        public string PAGENO { get; set; }
        /// <summary>
        /// 明细状态
        /// </summary>
        public string DLSUCCEED { get; set; }
        /// <summary>
        /// 明细返回消息
        /// </summary>
        public string DLMESSAGE { get; set; }
    }
}
