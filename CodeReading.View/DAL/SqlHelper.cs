using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CodeReading.View.DAL
{
    public class SqlHelper
    {
        //连接字符串
        private static readonly string str = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;


        //返回的是受影响的行数
        public static int ExecuteNonQuery(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (ps != null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }


        public static object ExecuteScalar(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (ps != null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }
                    con.Open();//打开数据库
                    return cmd.ExecuteScalar();
                }
            }
        }
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] ps)
        {
            SqlConnection con = new SqlConnection(str);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (ps != null)
                {
                    cmd.Parameters.AddRange(ps);
                }
                try
                {
                    con.Open();
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);//关闭关联的connection
                }
                catch (Exception ex)
                {
                    con.Close();
                    con.Dispose();
                    throw ex;
                }

            }

        }
        public static DataSet SqlDataSet(string sql, DataSet ds, string tableName, params SqlParameter[] ps)
        {
            using (SqlConnection con = new SqlConnection(str))
            {

                using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                {
                    if (ps != null)
                    {
                        da.SelectCommand.Parameters.AddRange(ps);
                    }
                    con.Open();
                    ds.Clear();
                    
                    da.Fill(ds,tableName);

                    return ds;
                }
            }
        }
        //SqlHelper  
        public static int SqlDataAdapter(string sql, DataSet ds, string tableName, params SqlParameter[] ps)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                using (SqlDataAdapter sa = new SqlDataAdapter(sql, con))
                {
                    SqlCommandBuilder builder = new SqlCommandBuilder(sa);

                    return sa.Update(ds, tableName);
                }
            }
        }
    }
}
      