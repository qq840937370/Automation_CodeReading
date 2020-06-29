using CodeReading.Entity.MainForm.MainNew;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace CodeReading.View.BLL.MainFormNew
{
    public class ReadJson
    {
        /// <summary>
        ///  耗材仓库耗材入库单Readjson
        /// </summary>
        CWSL cWSL = new CWSL();
        public CWSL Readjson_CWSL()
        {
            StreamReader reader = File.OpenText(@"C:\Users\zhang-sh\source\repos\qq840937370\Automation_CodeReading\CodeReading.Entity\MainForm\MainNew_Json\CWSL.json");  // 读取文件
            JsonTextReader jsonTextReader = new JsonTextReader(reader);                 // 文件浏览
            JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);              // 解读JSON文件
            cWSL.SupplierName = jsonObject["SupplierName"].ToString();                    // 供应商 
            cWSL.InboundDate = jsonObject["InboundDate"].ToString();                      // 入库日期
            cWSL.ReceiptNo = jsonObject["ReceiptNo"].ToString();                          // 入库单号

            cWSL.TotalAmount = jsonObject["TotalAmount"].ToString();                      // 表单总金额

            reader.Close();

            return cWSL;
        }

        /// <summary>
        ///  耗材仓库配送出库单Readjson
        /// </summary>
        CWDL cWDL = new CWDL();
        public CWDL Readjson_CWDL()
        {
            StreamReader reader = File.OpenText(@"C:\Users\zhang-sh\source\repos\qq840937370\Automation_CodeReading\CodeReading.Entity\MainForm\MainNew_Json\CWDL1_1.json");  // 读取文件
            JsonTextReader jsonTextReader = new JsonTextReader(reader);                 // 文件浏览
            JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);              // 解读JSON文件
            cWDL.NameOfCollectingDepartment = jsonObject["NameOfCollectingDepartment"].ToString();  // 领用科室名称
            cWDL.DataOfOutbound = jsonObject["DataOfOutbound"].ToString();                          // 领用科室名称

            cWDL.OutboundOrderNo = jsonObject["OutboundOrderNo"].ToString();                        // 出库单号
            cWDL.SerialNumber = jsonObject["SerialNumber"].ToString();                              // 流水号

            cWDL.TotalAmount = jsonObject["TotalAmount"].ToString();                                // 总金额
            reader.Close();

            return cWDL;
        }

    }
}
