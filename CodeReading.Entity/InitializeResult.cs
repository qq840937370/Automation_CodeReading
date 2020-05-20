/*-------------------------------------------------------------------------------
* 系统名称  ：工业自动化系统
* 子系统名称：工业相机识码子系统
* 功能模块名：工业相机识码历史记录
* 类名      ：InitializeResult
* 概要      ：初始化结果
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
    /// 初始化结果
    /// </summary>
    [DataContract]
    public class InitializeResult
    {
        #region 常数
        #endregion

        #region 成员变量
        #endregion

        #region 构造器
        #endregion

        #region 属性
        /// <summary>
        /// 最大表示件数
        /// </summary>
        ///
        [DataMember]
        public int MaxRowsCount { get; set; }

        /// <summary>
        /// 系统时间
        /// </summary>
        [DataMember]
        public DateTime SysDate { get; set; }
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
