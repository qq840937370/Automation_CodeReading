/*-------------------------------------------------------------------------------
 * 系统名称  ：工业自动化系统
 * 子系统名称：工业相机识码子系统
 * 功能模块名：工业相机识码历史记录页
 * 类名      ：HistoryService
 * 概要      ：工业相机识码历史Service
 * 
 * 改版履历
 * Ver----------日期---------单位・姓名--------------------概要------------------
 * 1.0.0.0      2020/05/18   Shandong_HuaShi ZhangSh       新建
 * 
 * ------------------------------------------------------------------------------
 */
using CodeReading.Entity;
using CodeReading.Entity.Comm;
using CodeReading.Entity.History;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace CodeReading.Service.History
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“HistoryService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 HistoryService.svc 或 HistoryService.svc.cs，然后开始调试。
    public class HistoryService : IHistoryService
    {
        #region 常数
        /// <summary>
        /// 窗体ID
        /// </summary>
        private const string FORM_ID = "CodeReading01";
        /// <summary>
        /// 业务系统代码
        /// </summary>
        private const string BUSINESS_SYSTEM_CD = "PC";
        /// <summary>
        /// 最大表示件数设定
        /// </summary>
        private int maxRowsCount = 100;

        // 数据取得
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStrings"].ConnectionString;

        #endregion

        #region 成员变量
        #endregion

        #region 构造器
        #endregion

        #region public方法
        #region 初始化
        /// <summary>
        /// 获取初始处理所需的数据等
        /// </summary>
        /// <param name="loginInfo">Login用户简介信息</param>
        /// <returns>初始化处理DTO</returns>
        public InitializeResult Initialize(LoginInfo loginInfo)
        {
            // 返回值初始化
            var result = new InitializeResult();
            // 系统时间
            result.SysDate = DateTime.Now;
            // 最大表示件数
            result.MaxRowsCount = maxRowsCount;

            return result;
        }
        #endregion

        #region "检索"按钮按下处理
        /// <summary>
        /// "检索"按钮按下处理
        /// </summary>
        /// <param name="searchConditions">查询条件</param>
        /// <returns>查询结果</returns>
        public SearchResult Search(SearchConditions searchConditions)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                // SQL参数生成
                StringBuilder sql = new StringBuilder();
                // SELECT ScanDate,HospitalNo,TagCode,Signed,Pass,FileName FROM dbo.Used
                sql.AppendLine(" SELECT ");
                sql.AppendLine("    ScanDate");                  // 日期
                sql.AppendLine("    ,HospitalNo");               // 医院标识
                sql.AppendLine("    ,TagCode");                  // 条形码
                sql.AppendLine("    ,Signed");                   // 签名确认
                sql.AppendLine("    ,Pass");                     // 是否通过
                sql.AppendLine("    ,FileName");                 // 图片名
                sql.AppendLine("  FROM   ");
                sql.AppendLine("      dbo.Used ");               // Used表
                //cmd.Parameters.Add("",);

                // 数据取得
                cmd.CommandText = sql.ToString();
                using (SqlDataAdapter reader = new SqlDataAdapter(cmd))
                {
                    var result = new SearchResult();
                    result.Suceeded = true;
                    var errorInfo = new ErrorInfo();
                    result.ErrorInfo = errorInfo;

                    var dt = new HistoryDataSet.SearchListDataTable();
                    reader.Fill(dt);
                    result.SearchData = dt;
                    return result;
                }
            }
        }
        #endregion
        #endregion
    }
}
