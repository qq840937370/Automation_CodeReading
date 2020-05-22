using CodeReading.Entity;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CodeReading.View.DAL
{
    public class MainFormDAL
    {
        /// <summary>
        /// 全局变量 Datatimenow
        /// </summary>
        string Datatimenow;


        // 接口调用
        public UsedInfo ConvertStruct(HTuple HospitalNo, HTuple TagCode, HTuple Sign)
        {
            UsedInfo usedInfo = new UsedInfo();
            Random rd = new Random();
            int TagCodeNum = 0;
            usedInfo.ScanDate = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            usedInfo.HospitalNo = HospitalNo;
            usedInfo.Name = "Patient";
            usedInfo.TagCode = "";
            for (; TagCodeNum < TagCode.Length; TagCodeNum++)
            {
                usedInfo.TagCode += TagCode[TagCodeNum].S + ",";
            }
            usedInfo.TagCodeNum = (TagCodeNum + 1).ToString();

            if (Sign[0] * Sign[1] * Sign[2] * Sign[3] == 1)
            {
                usedInfo.Sign = "1";
                usedInfo.Pass = "1";
            }
            else
            {
                usedInfo.Sign = "0";
                usedInfo.Pass = "0";
            }
            return usedInfo;
        }

        // 接口调用
        public UsedInfo SaveTemp(UsedInfo usedInfo, string ScanDate)
        {
            string sql1 = "INSERT INTO Used(DbId,HospitalNo,ScanDate,TagCode,Signed,Pass,FileName,ImgFile) VALUES(@dbId,@hospitalno,@scandate,@tagcode,@signed,@pass,@fileName,@imgFile)";
            SqlParameter[] ps = {
                                new SqlParameter("@dbId","1"),
                                new SqlParameter("@hospitalno",usedInfo.HospitalNo),
                                new SqlParameter("@tagcode",usedInfo.TagCode),
                                new SqlParameter("@scandate",ScanDate),
                                new SqlParameter("@signed",usedInfo.Sign),
                                new SqlParameter("@pass",usedInfo.Pass),
                                new SqlParameter("@fileName",ScanDate + ".bmp"),
                                new SqlParameter("@imgFile",ScanDate + ".bmp")//usedInfo.ImgFile
                                };
            SqlHelper.ExecuteNonQuery(sql1, ps);

            return usedInfo;
        }

        /// <summary>
        /// SaveNow按钮-数据库处理
        /// </summary>
        /// <returns></returns>
        public int SaveNow()
        {
            //string sql = "UPDATE Used SET DbId =@datetime WHERE DbID =@now";
            string sql = "UPDATE Used SET DbID =@datetime WHERE DbID =@now";

            Datatimenow = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            SqlParameter[] ps = {
                                new SqlParameter("@datetime",Datatimenow),
                                new SqlParameter("@now","1")
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
    }
}
