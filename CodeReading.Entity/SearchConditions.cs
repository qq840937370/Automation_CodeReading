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

namespace CodeReading.Entity
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
        /// 工厂cd
        /// </summary>
        [DataMember]
        public string KojoCd { get; set; }

        /// <summary>
        /// 住院号
        /// </summary>
        [DataMember]
        public string HospitalizationNumber { get; set; }

        /// <summary>
        /// 捕捉时间From
        /// </summary>
        [DataMember]
        public string DtpFrom { get; set; }

        /// <summary>
        /// 捕捉时间To
        /// </summary>
        [DataMember]
        public string DtpTo { get; set; }
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