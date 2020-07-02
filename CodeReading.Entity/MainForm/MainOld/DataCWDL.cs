﻿/*-------------------------------------------------------------------------------
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
        public MainFormDataSet.CWDLDataTable DataTable = new MainFormDataSet.CWDLDataTable();
    }
}