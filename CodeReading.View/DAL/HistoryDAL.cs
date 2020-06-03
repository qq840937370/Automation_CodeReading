using CodeReading.Entity;
using CodeReading.Entity.Comm;
using CodeReading.Entity.History;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReading.View.DAL
{
    public class HistoryDAL
    {
        // 数据取得
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStrings"].ConnectionString;

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
                // SELECT DbId,OtherID,Signed,TagCode,ScanDate,Pass,FileName FROM dbo.Used
                sql.AppendLine(" SELECT ");
                sql.AppendLine("    ScanDate");                                                          // 日期
                sql.AppendLine("    ,DbId");                                                             // 表单类型
                sql.AppendLine("    ,OtherID");                                                          // 模拟主键
                sql.AppendLine("    ,TagCode");                                                          // 条形码
                sql.AppendLine("    ,case when Signed='1' then '已签名' else '未签名' END as Signed");   // 签名确认
                sql.AppendLine("    ,case when Pass='1' then '通过' else '未通过' END as Pass");         // 是否通过
                sql.AppendLine("    ,FileName");                                                         // 图片名
                sql.AppendLine("  FROM   ");
                sql.AppendLine("      dbo.Used ");                                                       // Used表
                sql.AppendLine("  Where   ");
                sql.AppendLine("       ScanDate >= @hsDtpFrom ");                  // 扫描开始时刻
                sql.AppendLine("   And ScanDate <= @hsDtpTo ");                    // 扫描结束时刻
                cmd.Parameters.Add("@hsDtpFrom", searchConditions.HsDtpFrom);         // 扫描开始时刻 赋值
                cmd.Parameters.Add("@hsDtpTo", searchConditions.HsDtpTo);             // 扫描结束时刻 赋值
                // "表单类型"有值时
                if (!string.IsNullOrEmpty(searchConditions.HsDbId))
                {
                    sql.AppendLine("   And  DbId = @hsDbId ");                      // 表单类型
                    cmd.Parameters.Add("@hsDbId", searchConditions.HsDbId);           // 表单类型 赋值
                }
                // "模拟主键"有值时
                if (!string.IsNullOrEmpty(searchConditions.HsOtherID))
                {
                    sql.AppendLine("   And OtherID = @hsOtherID ");                 // 模拟主键
                    cmd.Parameters.Add("@hsOtherID", searchConditions.HsOtherID);     // 模拟主键 赋值
                }
                // "签名确认"有值时
                if (!string.IsNullOrEmpty(searchConditions.HsSigned))
                {
                    sql.AppendLine("   And Signed = @hsSigned ");                   // 签名确认
                    cmd.Parameters.Add("@hsSigned", searchConditions.HsSigned);       // 签名确认 赋值
                }
                // "是否通过"有值时
                if (!string.IsNullOrEmpty(searchConditions.HsPass))
                {
                    sql.AppendLine("   And Pass = @hsPass ");                       // 是否通过
                    cmd.Parameters.Add("@hsPass", searchConditions.HsPass);           // 是否通过 赋值
                }
                //// "模拟查询条件1"有值时
                //if (string.IsNullOrEmpty(searchConditions.HsOtherID))
                //{
                //    sql.AppendLine("       hsOther1 = @hsOther1 ");                // 模拟查询条件1
                //    cmd.Parameters.Add("@hsOther1", searchConditions.HsOther1);       // 模拟查询条件1 赋值
                //}
                //// "模拟查询条件2"有值时
                //if (string.IsNullOrEmpty(searchConditions.HsOtherID))
                //{
                //    sql.AppendLine("       hsOther2 = @hsOther2 ");                // 模拟查询条件2
                //    cmd.Parameters.Add("@hsOther2", searchConditions.HsOther2);       // 模拟查询条件2 赋值
                //}

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
    }
}
