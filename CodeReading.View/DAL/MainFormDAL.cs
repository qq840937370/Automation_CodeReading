using CodeReading.Entity;
using CodeReading.Entity.Comm;
using CodeReading.Entity.MainForm;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CodeReading.View.DAL
{
    public class MainFormDAL
    {
        /// <summary>
        /// 全局变量 Datatimenow
        /// </summary>
        string Datatimenow;

        // 接口调用
        //public UsedInfo SaveTemp(UsedInfo usedInfo)
        public void SaveTemp(UsedInfo usedInfo)
        {
            // 赋值
            //usedInfodata.DbId = halconHelpers.usedInfoDbId;         // 表类别
            //usedInfodata.OtherID = halconHelpers.usedInfoOtherID;   // 模拟主键
            //usedInfodata.Sign = halconHelpers.usedInfoSign;         // 签字
            //usedInfodata.TagCode = halconHelpers.usedInfoTagCode;   // 条形码
            //usedInfomain.ScanDate = ScanDate;                       // 日期
            //usedInfomain.FileName = ScanDate + ".bmp";              // 图片名
            //usedInfodata.Pass = "1";                                // 通过

            string sql1 = "INSERT INTO Used(DbId,OtherID,Signed,TagCode,ScanDate,Pass,FileName,ImgFile) VALUES(@dbId,@otherID,@signed,@tagcode,@scandate,@pass,@fileName,@imgFile)";
            SqlParameter[] ps = {
                                new SqlParameter("@dbId",usedInfo.DbId),
                                new SqlParameter("@otherID",usedInfo.OtherID),
                                new SqlParameter("@signed",usedInfo.Sign),
                                new SqlParameter("@tagcode",usedInfo.TagCode),
                                new SqlParameter("@scandate",usedInfo.ScanDate),
                                new SqlParameter("@pass",usedInfo.Pass),
                                new SqlParameter("@fileName",usedInfo.FileName),
                                new SqlParameter("@imgFile",usedInfo.FileName) //usedInfo.ImgFile
                                };
            SqlHelper.ExecuteNonQuery(sql1, ps);

            //return usedInfo;
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
        #region
        // 数据取得
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStrings"].ConnectionString;
        /// <summary>
        /// 查SHIL数据
        /// </summary>
        /// <param name="usedInfo">查询条件</param>
        /// <returns>查询结果</returns>
        public DataSHIL dataSHIL(UsedInfo usedInfo)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                // SQL参数生成
                StringBuilder sql = new StringBuilder();
                // SELECT ScanDate,HospitalNo,TagCode,Signed,Pass,FileName FROM dbo.Used
                sql.AppendLine(" SELECT ");
                sql.AppendLine("    HospitalizationNumber");         // 住院号
                sql.AppendLine("    ,PatientName");                  // 患者姓名
                sql.AppendLine("    ,PatientSex");                   // 性别
                sql.AppendLine("    ,PatientAge");                   // 年龄
                sql.AppendLine("    ,PatientDepartment");            // 患者科室
                sql.AppendLine("    ,OperationOrderNo");             // 手术医嘱号
                sql.AppendLine("    ,OperationDate");                // 手术日期
                sql.AppendLine("    ,OperationRoom");                // 手术室
                sql.AppendLine("    ,Bed");                          // 床位
                sql.AppendLine("    ,OperationName");                // 手术名称
                sql.AppendLine("    ,Doctor");                       // 医生
                sql.AppendLine("    ,TagCodeNumbers");               // 标签数
                sql.AppendLine("    ,TagCode");                      // 条形码
                sql.AppendLine("    ,Remarks");                      // 备注
                sql.AppendLine("  FROM   ");
                sql.AppendLine("      dbo.FormDataone ");            // 跟台人体植入物使用清单表
                sql.AppendLine("  Where   ");
                sql.AppendLine("      HospitalizationNumber = @hospitalizationNumber ");  // Used表
                cmd.Parameters.Add("@hospitalizationNumber", usedInfo.OtherID);

                // 数据取得
                cmd.CommandText = sql.ToString();
                using (SqlDataAdapter reader = new SqlDataAdapter(cmd))
                {
                    var result = new DataSHIL();
                    result.Suceeded = true;
                    var errorInfo = new ErrorInfo();
                    result.ErrorInfo = errorInfo;

                    var dt = new MainFormDataSet.SHILDataTable();
                    reader.Fill(dt);
                    result.DataTable = dt;
                    return result;
                }
            }
        }
        #endregion
    }
}
