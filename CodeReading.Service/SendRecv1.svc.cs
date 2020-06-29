using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CodeReading.Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“SendRecv1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 SendRecv1.svc 或 SendRecv1.svc.cs，然后开始调试。
    public class SendRecv1 : ISendRecv1
    {
        public string SendRecv(string userCode, string safeCode, string orgCode, string dataNo, string dataMethod, string dataType, string insData, string insDataCheck)
        {
            System.Diagnostics.Debug.WriteLine("userCode " + userCode + " \t orgCode " + orgCode + " \t dataNo " + dataNo + " \t dataMethod " + dataMethod + " \t dataType " + dataType + " \t insData " + insData + " \t insDataCheck "+ insDataCheck);
            return "通过";
        }
    }
}
