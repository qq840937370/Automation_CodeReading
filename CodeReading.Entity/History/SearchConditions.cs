/*-------------------------------------------------------------------------------
* 系统名称  ：工业自动化系统
* 子系统名称：工业相机识码子系统
* 功能模块名：工业相机识码历史记录页
* 类名      ：SearchResult
* 概要      ：工业相机识码首页“检索按钮”结果信息
* 
* 改版履历
* Ver----------日期---------单位・姓名--------------------概要------------------
* 1.0.0.0      2020/05/18   Shandong_HuaShi ZhangSh       新建
* 
* ------------------------------------------------------------------------------
*/
using System;
using System.Runtime.Serialization;

namespace CodeReading.Entity.History
{
    /// <summary>
    /// 检索条件
    /// </summary>
    [DataContract]
    public class SearchConditions
    {
        #region 常数
        #endregion

        #region 成员变量
        #endregion

        #region 构造器
        #endregion

        #region 属性

        /// <summary>
        /// 捕捉时间From
        /// </summary>
        [DataMember]
        public string HsDtpFrom { get; set; }

        /// <summary>
        /// 捕捉时间To
        /// </summary>
        [DataMember]
        public string HsDtpTo { get; set; }

        /// <summary>
        /// 表单类型
        /// </summary>
        [DataMember]
        public string HsDbId { get; set; }

        /// <summary>
        /// 模拟主键
        /// </summary>
        [DataMember]
        public string HsOtherID { get; set; }

        /// <summary>
        /// 签名确认
        /// </summary>
        [DataMember]
        public string HsSigned { get; set; }

        /// <summary>
        /// 是否通过
        /// </summary>
        [DataMember]
        public string HsPass { get; set; }

        /// <summary>
        /// 模拟查询条件1
        /// </summary>
        [DataMember]
        public string HsOther1 { get; set; }

        /// <summary>
        /// 模拟查询条件2
        /// </summary>
        [DataMember]
        public string HsOther2 { get; set; }
        #endregion
        #region public方法
        #endregion

        #region protected方法
        #endregion

        #region internal方法
        #endregion

        #region protected internal方法
        #endregion

        #region private方法
        #endregion
    }
}