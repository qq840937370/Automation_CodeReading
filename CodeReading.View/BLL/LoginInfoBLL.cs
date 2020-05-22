using CodeReading.Entity;
using CodeReading.View.DAL;
using System;

namespace CodeReading.View
{
    public class LoginInfoBLL
    {
        // bll层获取数据方法
        LoginInfoDAL dal = new LoginInfoDAL();// 实例化类对象
        public LoginState LoginByUnameUpwd(string uname, string upwd)
        {
            if(!string.IsNullOrEmpty(uname)&&!string.IsNullOrEmpty(upwd))
            {
                if(Convert.ToInt32(dal.LoginByUnameUpwd(uname,upwd))>0)
                {
                    //登录成功
                    return LoginState.登录;
                }
                else
                {
                    return LoginState.未登录;
                }
            }
            else
            {
                return LoginState.未登录;
            }
        }
    }
}
