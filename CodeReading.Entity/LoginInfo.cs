/*-------------------------------------------------------------------------------
* 系统名称  ：工业自动化系统
* 子系统名称：工业相机识码子系统
* 功能模块名：工业相机识码历史记录页
* 类名      ：LoginInfo
* 概要      ：Login用户简介信息
* 
* 改版履历
* Ver----------日期---------单位・姓名--------------------概要------------------
* 1.0.0.0      2020/05/18   Shandong_HuaShi ZhangSh       新建
* 
* ------------------------------------------------------------------------------
*/
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CodeReading.Entity
{
    /// <summary>
    /// Login用户简介信息
    /// </summary>
    [DataContract]
    public class LoginInfo
    {
        /// <summary>
        /// 系统名
        /// </summary>
        [DataMember]
        public string SystemName
        {
            get;
            set;
        }

        /// <summary>
        /// 窗体名
        /// </summary>
        [DataMember]
        public string ApplicationName
        {
            get;
            set;
        }

        /// <summary>
        /// 工厂cd
        /// </summary>
        [DataMember]
        public string KojoCd
        {
            get;
            set;
        }

        /// <summary>
        /// 工厂名称
        /// </summary>
        [DataMember]
        public string KojoName
        {
            get;
            set;
        }

        /// <summary>
        /// 部门Cd
        /// </summary>
        [DataMember]
        public string SoshikiCd
        {
            get;
            set;
        }

        /// <summary>
        /// 部门名称
        /// </summary>
        [DataMember]
        public string SoshikiName
        {
            get;
            set;
        }

        /// <summary>
        /// 用户Cd
        /// </summary>
        [DataMember]
        public string UserCd
        {
            get;
            set;
        }

        /// <summary>
        /// 用户名
        /// </summary>
        [DataMember]
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// 杂类项
        /// </summary>
        [DataMember]
        public string MiscField
        {
            get;
            set;
        }

        /// <summary>
        /// 参数
        /// </summary>
        [DataMember]
        public Dictionary<string, string> Parameters
        {
            get;
            set;
        }
    }
}
