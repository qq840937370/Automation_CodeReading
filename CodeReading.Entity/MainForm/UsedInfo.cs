/*-------------------------------------------------------------------------------
* 系统名称  ：工业自动化系统
* 子系统名称：工业相机识码子系统
* 功能模块名：工业相机识码主页
* 类名      ：UsedInfo
* 概要      ：获取的信息
* 
* 改版履历
* Ver----------日期---------单位・姓名--------------------概要------------------
* 1.0.0.0      2020/05/18   Shandong_HuaShi ZhangSh       新建
* 
* ------------------------------------------------------------------------------
*/
using HalconDotNet;
using System.Runtime.Serialization;

namespace CodeReading.Entity.MainForm
{
    /// <summary>
    /// 获取的信息
    /// </summary>
    [DataContract]
    public class UsedInfo
    {
        /// <summary>
        /// 表类别
        /// </summary>
        [DataMember]
        public string DbId { get; set; }

        /// <summary>
        /// 模拟主键
        /// </summary>
        [DataMember]
        public string OtherID { get; set; }

        /// <summary>
        /// 医院标识
        /// </summary>
        [DataMember]
        public string HospitalNo { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        [DataMember]
        public string ScanDate { get; set; }

        /// <summary>
        /// 条形码1
        /// </summary>
        [DataMember]
        public string TagCode { get; set; }

        /// <summary>
        /// 条形码数
        /// </summary>
        [DataMember]
        public string TagCodeNum { get; set; }

        /// <summary>
        /// 坏的条形码
        /// </summary>
        [DataMember]
        public string BedNo { get; set; }

        /// <summary>
        /// 签名确认
        /// </summary>
        [DataMember]
        public string Sign { get; set; }

        /// <summary>
        /// 是否通过
        /// </summary>
        [DataMember]
        public string Pass { get; set; }

        /// <summary>
        /// 图片名
        /// </summary>
        [DataMember]
        public string FileName { get; set; }

        /// <summary>
        /// 图片文件
        /// </summary>
        [DataMember]
        public string ImgFile { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 图片张数private
        /// </summary>
        private int imgCount;   // deviation

        /// <summary>
        /// 图片张数
        /// </summary>
        [DataMember]
        public int ImgCount { get { return imgCount != 0 ? imgCount : 0; } set{ imgCount = value; } }

        /// <summary>
        /// HObject图片
        /// </summary>
        [DataMember]
        public HObject HImg { get ;set;}

        /// <summary>
        /// HObject图片
        /// </summary>
        [DataMember]
        public string HImgstr { get; set; }
    }
}
