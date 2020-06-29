using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CodeReading.Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ISendRecv1”。
    [ServiceContract]
    public interface ISendRecv1
    {
        /// <summary>
        /// 万序SendRecv接口
        /// </summary>
        /// <param name="userCode">接口客户编码</param>
        /// <param name="safeCode">接口客户授权数字令牌</param>
        /// <param name="orgCode">机构代码，当前医疗机构代码，固定值</param>
        /// <param name="dataNo">接口调用序号，用于日志追踪查询，可用时间序列生成</param>
        /// <param name="dataMethod">接口类型编码。当次调用要执行的操作</param>
        /// <param name="dataType">接口交互数据格式 XML/ JSON，接口支持XML/ JSON两种格式</param>
        /// <param name="insData">各个机构报送的的消息内容，传入数据XML/ JSON字符串，与dataType对应</param>
        /// <param name="insDataCheck">消息校验，使用SHA1（安全哈希算法）对insData进行计算得到的校验码,校验数据完整性</param>
        /// <returns>返回消息：返回报文内容，数据格式XML/ JSON字符串，与传入dataType对应</returns>
        [OperationContract]
        string SendRecv(string userCode, string safeCode, string orgCode, string dataNo, string dataMethod, string dataType, string insData, string insDataCheck);

    }
}
