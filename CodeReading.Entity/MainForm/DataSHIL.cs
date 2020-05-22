/*-------------------------------------------------------------------------------
* 系统名称  ：工业自动化系统
* 子系统名称：工业相机识码子系统
* 功能模块名：工业相机识码主页
* 类名      ：DataSHIL
* 概要      ："跟台人体植入物使用清单"信息
* 
* 改版履历
* Ver----------日期---------单位・姓名--------------------概要------------------
* 1.0.0.0      2020/05/18   Shandong_HuaShi ZhangSh       新建
* 
* ------------------------------------------------------------------------------
*/
using CodeReading.Entity.Comm;
using System.Runtime.Serialization;

namespace CodeReading.Entity.MainForm
{
    /// <summary>
    /// "跟台人体植入物使用清单"信息
    /// </summary>
    [DataContract]
    public class DataSHIL
    {
        /// <summary>
        /// 取得或设定处理是否正常结束
        /// </summary>
        [DataMember]
        public bool Suceeded { get; set; }

        /// <summary>
        /// 获取或设置错误信息
        /// </summary>
        [DataMember]
        public ErrorInfo ErrorInfo { get; set; }

        /// <summary>
        /// 获取或设置检索的数据
        /// </summary>
        [DataMember]
        public MainFormDataSet.SHILDataTable sHILDataTable = new MainFormDataSet.SHILDataTable();

        /// <summary>
        /// 住院号
        /// </summary>
        [DataMember]
        public string HospitalizationNumber { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        [DataMember]
        public string PatientName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [DataMember]
        public string PatientSex { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [DataMember]
        public string PatientAge { get; set; }

        /// <summary>
        /// 患者科室
        /// </summary>
        [DataMember]
        public string PatientDepartment { get; set; }

        /// <summary>
        /// 手术医嘱号
        /// </summary>
        [DataMember]
        public string OperationOrderNo { get; set; }

        /// <summary>
        /// 手术日期
        /// </summary>
        [DataMember]
        public string OperationDate { get; set; }

        /// <summary>
        /// 手术室
        /// </summary>
        [DataMember]
        public string OperationRoom { get; set; }

        /// <summary>
        /// 床位
        /// </summary>
        [DataMember]
        public string Bed { get; set; }

        /// <summary>
        /// 手术名称
        /// </summary>
        [DataMember]
        public string OperationName { get; set; }

        /// <summary>
        /// 医生
        /// </summary>
        [DataMember]
        public string Docto { get; set; }

        /// <summary>
        /// 标签数
        /// </summary>
        public string TagCodeNumbers { get; set; }

        /// <summary>
        /// 条形码
        /// </summary>
        public string TagCode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }
}
