/*-------------------------------------------------------------------------------
 * 系统名称  ：工业自动化系统
 * 子系统名称：工业相机识码子系统
 * 功能模块名：工业相机识码历史记录页
 * 类名      ：ICodeReadingService
 * 概要      ：工业相机识码历史记录页服务接口类
 * 
 * 改版履历
 * Ver----------日期---------单位・姓名--------------------概要------------------
 * 1.0.0.0      2020/05/18   Shandong_HuaShi ZhangSh       新建
 * 
 * ------------------------------------------------------------------------------
 */
using CodeReading.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CodeReading.Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ICodeReadingService”。
    /// <summary>
    /// 工业相机识码历史记录服务接口类
    /// </summary>
    [ServiceContract]
    public interface ICodeReadingService
    {

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <returns></returns>
        [OperationContract]
        InitializeResult Initialize(LoginInfo loginInfo);

        /// <summary>
        /// "检索"按钮按下处理
        /// </summary>
        /// <param name="searchConditions"></param>
        /// <returns></returns>
        [OperationContract]
        SearchResult Search(SearchConditions searchConditions);

    }
}
