using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReading.Entity.MainForm
{
    class _1HNCL
    {

        /// <summary>
        /// 住院号
        /// </summary>
         
        public string HospitalizationNumber { get; set; }

        /// <summary>
        /// 床位
        /// </summary>
         
        public string Bed { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
         
        public string PatientName { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
         
        public string PatientAge { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
         
        public string PatientSex { get; set; }

        /// <summary>
        /// OR
        /// </summary>
         
        public string ORName { get; set; }

        /// <summary>
        /// 住院科室
        /// </summary>
         
        public string PatientDepartment { get; set; }

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
