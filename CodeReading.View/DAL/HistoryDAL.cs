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
    }
}
