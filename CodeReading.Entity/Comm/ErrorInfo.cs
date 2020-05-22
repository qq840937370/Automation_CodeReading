/*-------------------------------------------------------------------------------
* 系统名称  ：工业自动化系统
* 子系统名称：工业相机识码子系统
* 功能模块名：工业相机识码历史记录页
* 类名      ：ErrorInfo
* 概要      ：Error信息
* 
* 改版履历
* Ver----------日期---------单位・姓名--------------------概要------------------
* 1.0.0.0      2020/05/18   Shandong_HuaShi ZhangSh       新建
* 
* ------------------------------------------------------------------------------
*/
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CodeReading.Entity.Comm
{
    /// <summary>
    /// 获取或设置错误信息
    /// </summary>
    [DataContract]
    public class ErrorInfo
    {
        /// <summary>
        /// 错误Item
        /// </summary>
        [DataMember]
        public Dictionary<string, string> ItemErrors
        {
            get;
            set;
        }
        /// <summary>
        /// 错误文
        /// </summary>
        [DataMember]
        public string ErrorText
        {
            get;
            set;
        }
        /// <summary>
        /// 错误ID
        /// </summary>
        [DataMember]
        public string ErrorId
        {
            get;
            set;
        }
        /// <summary>
        /// 详细错误
        /// </summary>
        [DataMember]
        public Dictionary<string, List<DetailErrorInfo>> DetailErrors
        {
            get;
            set;
        }
        /// <summary>
        /// 错误Info
        /// </summary>
        public ErrorInfo()
        {
            ItemErrors = new Dictionary<string, string>();
            DetailErrors = new Dictionary<string, List<DetailErrorInfo>>();
        }
    }
    /// <summary>
    /// Row
    /// ItemName
    /// ErrorText
    /// </summary>
    [DataContract]
    public class DetailErrorInfo
    {
        [DataMember]
        public int Row
        {
            get;
            set;
        }
        [DataMember]
        public string ItemName
        {
            get;
            set;
        }
        [DataMember]
        public string ErrorText
        {
            get;
            set;
        }
    }
}
