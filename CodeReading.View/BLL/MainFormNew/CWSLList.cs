using System.IO;
using CodeReading.Entity.MainForm.MainNew;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CodeReading.View.BLL.MainFormNew
{

    public class CWSLList
    {
        CWSL cWSL = new CWSL();
        public CWSL Readjson()
        {
            StreamReader reader = File.OpenText(@"C:\Users\zhang-sh\source\repos\qq840937370\Automation_CodeReading\CodeReading.Entity\MainForm\MainNew_Json\CWSL.json");  // 读取文件
            JsonTextReader jsonTextReader = new JsonTextReader(reader);     // 文件浏览
            JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);  // 解读JSON文件
            cWSL.SupplierName = jsonObject["SupplierName"].ToString();      // 
            cWSL.InboundDate = jsonObject["InboundDate"].ToString();        // 
            cWSL.ReceiptNo = jsonObject["ReceiptNo"].ToString();            // 
            cWSL.TotalAmount = jsonObject["TotalAmount"].ToString();        // 
            cWSL.AcceptanceOfThePeople = jsonObject["AcceptanceOfThePeople"].ToString();  // 
            cWSL.Supplier = jsonObject["Supplier"].ToString();                            // 
            cWSL.WarehouseOperator = jsonObject["WarehouseOperator"].ToString();          // 
            reader.Close();

            return cWSL;
        }
    }
}
