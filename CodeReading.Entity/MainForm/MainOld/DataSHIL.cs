/*-------------------------------------------------------------------------------
* 系统名称  ：工业自动化系统
* 子系统名称：工业相机识码子系统
* 功能模块名：工业相机识码主页
* 类名      ：DataSHIL
* 概要      ："跟台人体植入物使用清单"信息
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
    /// "跟台人体植入物使用清单"信息
    /// </summary>
    [DataContract]
    public class DataSHIL
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
        public MainFormDataSet.SHILDataTable DataTable = new MainFormDataSet.SHILDataTable();
    }
}
