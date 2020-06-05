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

        /* 返回的是受影响的行数
         * ExecuteNonQuery()通常情况下为数据库事务处理的首选，当需要执行插入，删除，修改等操作时，首选ExecuteNonQuery(),不适用于Selete语句，返回永远是-1
         * ExecuteNonQuery()执行成功返回的是一受影响的行数，对于"Create Table"和"Drop Table"语句，返回值是0，
         * 而对于其他类型的语句，返回值是-1，ExecuteNonQuery()操作数据时，可以不使用DataSet直接更改数据库中的数据。
         */
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

        /* ExecuteScalar()方法也可以用来执行SQL语句，但是executescalar()执行SQL语句后返回值与ExecuteNonQuery()并不相同，
         * ExecuteNonQuery()操作后返回的是一个值，而executescalar()操作后则会返回一个对象（object），
         * 如果执行的SQL语句是查询语句，则返回结果是查询后的第一行第一列，
         * 如果执行的SQL语句不是一个查询语句，则会返回一个未实例化的对象，必须通过类型装换来显示。
         *
         * executescalar()经常使用当需要返回单一值时的情况。例如当插入一条数据信息时，
         * 需要马上知道刚才插入的值，则可以使用executescalar()方法。
         */
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

        /* 快速查询
         * ExecuteReader比DataSet而言，DataReader具有较快的访问能力，并且能够使用较少的服务器资源。
         * DataReader对象提供了游标形式的读取方式，当从结果行中读取了一行，则游标会继续读取到下一行。
         * 通过read方法可以判断数据是否还有下一行，如果存在数据，则继续运行返回true，如果没有数据，则返回false。
         */
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

        /* 使用DataSet数据集插入记录，更新数据
         * 为了将数据库的数据填充到dataset中，则必须先使用adapter对象的方法实现填充，当数据填充完成后，
         * 开发人员可以将记录添加到dataset对象中，然后使用update方法将数据插入到数据库中。
         */
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

                    da.Fill(ds, tableName);

                    return ds;
                }
            }
        }

        /* 为了将数据库的数据填充到dataset中，则必须先使用adapter对象的方法实现填充，
         */
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
      