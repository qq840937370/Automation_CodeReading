/*-------------------------------------------------------------------------------
 * 系统名称  ：工业自动化系统
 * 子系统名称：工业相机识码子系统
 * 功能模块名：工业相机识码主页
 * 类名      ：MainFormService
 * 概要      ：工业相机识码主体Service
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
using CodeReading.Entity.MainForm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CodeReading.Service.MainForm
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“MainFormService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 MainFormService.svc 或 MainFormService.svc.cs，然后开始调试。
    public class MainFormService : IMainFormService
    {
        #region 常数
        // 数据取得
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStrings"].ConnectionString;
        #endregion

        #region 成员变量
        UsedInfo usedInfo = new UsedInfo();

        #endregion

        #region 构造器
        #endregion

        #region public方法
        #region 查SHIL数据
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
        /// <summary>
        /// 查HNCL数据
        /// </summary>
        /// <param name="usedInfo"></param>
        /// <returns>查询结果</returns>
        public DataHNCL dataHNCL(UsedInfo usedInfo)
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
                    var result = new DataHNCL();
                    result.Suceeded = true;
                    var errorInfo = new ErrorInfo();
                    result.ErrorInfo = errorInfo;

                    var dt = new MainFormDataSet.HNCLDataTable();
                    reader.Fill(dt);
                    result.DataTable = dt;
                    return result;
                }
            }
        }
        /// <summary>
        /// 查CWDL数据
        /// </summary>
        /// <param name="usedInfo"></param>
        /// <returns>查询结果</returns>
        public DataCWDL dataCWDL(UsedInfo usedInfo)
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
                    var result = new DataCWDL();
                    result.Suceeded = true;
                    var errorInfo = new ErrorInfo();
                    result.ErrorInfo = errorInfo;

                    var dt = new MainFormDataSet.CWDLDataTable();
                    reader.Fill(dt);
                    result.DataTable = dt;
                    return result;
                }
            }
        }
        #endregion
        #endregion
    }
}
