/*-------------------------------------------------------------------------------
* 系统名称  ：医院财务表单读取系统
* 功能模块名：医院财务表单读取系统工具类
* 类名      ：JSONTool
* 概要      ：JSON工具类
* 
* 改版履历
* Ver----------日期---------单位・姓名--------------------概要------------------
* 1.0.0.0      2020/07/07   Shandong_HuaShi ZhangSh       新建
* 
* ------------------------------------------------------------------------------
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReading.View.JSONTOOLs.BLL
{
    public class JSONTool
    {
        #region Json文件流处理_耗材仓库耗材入库单
        // Json字节流拼接_耗材仓库耗材入库单
        public void JSONbytesSplicing_CWSL()
        {
            /*
            {
//MAIN
"INSOUTNO":"1",
"SERIALNO":"1",
"INSOUTDATE":"1",
"SUPNAME":"1",
"TAXAMT":"1",
"TOTAL_RECORDS":"1",
//DETAIL
"PAGENO":"1",
"PAGETAXAMT":"1",
"PICFILEID":"1"
            }
             */
        }
        // Json字节流拆分_耗材仓库耗材入库单
        public void JSONbytesSplitting_CWSL()
        {

        }
        #endregion

        #region Json文件流处理_耗材仓库配送出库单
        // Json字节流拼接_耗材仓库配送出库单
        public void JSONbytesSplicing_CWDL()
        {

        }
        // Json字节流拆分_耗材仓库配送出库单
        public void JSONbytesSplitting_CWDL()
        {

        }
        #endregion
    }
}
