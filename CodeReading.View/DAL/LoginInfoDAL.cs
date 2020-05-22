using System.Data.SqlClient;

namespace CodeReading.View.DAL
{
    public class LoginInfoDAL
    {
        public object LoginByUnameUpwd(string uname, string upwd)
        {
            string sql = "select * from user_Users where userName=@uname and userPassword=@upwd";

            SqlParameter[] ps ={
                                 new SqlParameter("@uname",uname),
                                 new SqlParameter("@upwd",upwd)
                             };
            return SqlHelper.ExecuteScalar(sql, ps) != null;
        }
    }
}
