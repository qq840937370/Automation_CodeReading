/*-------------------------------------------------------------------------------
 * 系统名称  ：工业自动化系统
 * 子系统名称：工业相机识码子系统
 * 功能模块名：工业相机识码主页
 * 类名      ：IMainFormService
 * 概要      ：工业相机识码主体服务接口类
 * 
 * 改版履历
 * Ver----------日期---------单位・姓名--------------------概要------------------
 * 1.0.0.0      2020/05/18   Shandong_HuaShi ZhangSh       新建
 * 
 * ------------------------------------------------------------------------------
 */
using CodeReading.Entity.MainForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CodeReading.Service.MainForm
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IMainFormService”。
    [ServiceContract]
    public interface IMainFormService
    {
        /// <summary>
        /// 查SHIL数据
        /// </summary>
        /// <param name="usedInfo">查询条件</param>
        /// <returns>查询结果</returns>
        [OperationContract]
        DataSHIL dataSHIL(UsedInfo usedInfo);

        /// <summary>
        /// 查HNCL数据
        /// </summary>
        /// <param name="usedInfo">查询条件</param>
        /// <returns>查询结果</returns>
        [OperationContract]
        DataHNCL dataHNCL(UsedInfo usedInfo);

        /// <summary>
        /// 查CWDL数据
        /// </summary>
        /// <param name="usedInfo">查询条件</param>
        /// <returns>查询结果</returns>
        [OperationContract]
        DataCWDL dataCWDL(UsedInfo usedInfo);
    }
}
