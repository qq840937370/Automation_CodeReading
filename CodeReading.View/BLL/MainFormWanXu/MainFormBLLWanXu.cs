using CodeReading.Entity;
using CodeReading.Entity.MainForm.MainNew;
using CodeReading.View.BLL.MainFormNew;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReading.View.BLL.MainFormWanXu
{
    public class MainFormBLLWanXu
    {
        /// <summary>
        /// SHIL数据表_获取扫描数据用
        /// </summary>   
        public MainFormWanXuDataSet.CWSLwxDataTable cWSLwxData = new MainFormWanXuDataSet.CWSLwxDataTable();
        /// <summary>
        /// SHIL数据表_临时记录表数据
        /// </summary>   
        public MainFormWanXuDataSet.CWSLhistoryDataTable cWSLHistoryData = new MainFormWanXuDataSet.CWSLhistoryDataTable();
        /// <summary>
        /// CWDL数据表_获取扫描数据用
        /// </summary>   
        public MainFormWanXuDataSet.CWDLwxDataTable cWDLwxData = new MainFormWanXuDataSet.CWDLwxDataTable();
        /// <summary>
        /// CWDL数据表_临时记录表数据
        /// </summary>   
        public MainFormWanXuDataSet.CWDLhistoryDataTable cWDLHistoryData = new MainFormWanXuDataSet.CWDLhistoryDataTable();

        // 当前页码
        int NumberOfPageNew = 0;          // 
        /// <summary>
        /// 耗材仓库耗材入库单
        /// </summary>
        /// <param name="cWSL_id"></param>
        /// <param name="cWSL_TotalAmount"></param>
        /// <param name="cWSL_Sign"></param>
        /// <param name="cWSL_Pass"></param>
        internal void CWSLList(out string id, out string TotalAmount, out string Sign, out string Pass, out string Information)
        {
            CWSL cWSL_ComparisonInformation = new CWSL();  // 扫描到的值-数据矫正完的数据
            #region 数据获取和取可靠值检验
            for (int DATAPass=0; DATAPass <1;)   // 校验不通过-循环"获取数据+校验"
            {
                #region 扫描到的信息-假
                // 扫描到的信息
                #region 一维值
                // 扫描到的值-ComparisonInformation
                //cWSL_ComparisonInformation.SupplierName = "济南鹏程医疗设备有限公司";  // 供应商
                //cWSL_ComparisonInformation.ReceiptNo = "80462720";                     // 入库单号
                //cWSL_ComparisonInformation.InboundDate = "2020-06-10";                 // 入库日期

                //cWSL_ComparisonInformation.NumberOfPages = "1/3";                      // 页码
                //cWSL_ComparisonInformation.TotalAmount = "977.5";                      // 表单总金额

                //cWSL_ComparisonInformation.AcceptanceOfThePeople = "许欣伟";           // 验收人
                //cWSL_ComparisonInformation.Supplier = "张楠林";                        // 供应商
                //cWSL_ComparisonInformation.WarehouseOperator = "刘月";                 // 仓库员
                #endregion
                #region 二维值
                //    cWSLs[1].SupplierName = "济南鹏程医疗设备有限公司";  // 供应商名字
                //    cWSLs[1].ReceiptNo = "80462720";                     // 入库单号
                //    cWSLs[1].InboundDate = "2020-06-10";                 // 入库日期
                //    cWSLs[1].NumberOfPages = "1/3";                      // 页码
                //    cWSLs[1].TotalAmount = "977.5";                      // 表单总金额
                //    cWSLs[1].AcceptanceOfThePeople = "许欣伟";           // 验收人
                //    cWSLs[1].Supplier = "张楠林";                        // 供应商
                //    cWSLs[1].WarehouseOperator = "刘月";                 // 仓库员

                //    cWSLs[2].SupplierName = "济南程程医疗设备有限公司";  // 供应商名字
                //    cWSLs[2].ReceiptNo = "60462720";                     // 入库单号
                //    cWSLs[2].InboundDate = "1020-06-10";                 // 入库日期
                //    cWSLs[2].NumberOfPages = "3/3";                      // 页码
                //    cWSLs[2].TotalAmount = "677.5";                      // 表单总金额
                //    cWSLs[2].AcceptanceOfThePeople = "许欣两";           // 验收人
                //    cWSLs[2].Supplier = "墙楠林";                        // 供应商
                //    cWSLs[2].WarehouseOperator = "刘未";                 // 仓库员
                for (int rowscount = 0; rowscount < 3; rowscount++)
                {
                    DataRow dataRow_cWSLwxData = cWSLwxData.NewRow();
                    dataRow_cWSLwxData["FormsTitle"] = "耗材仓库耗材入库单";          // 表单标题
                    dataRow_cWSLwxData["SupplierName"] = "济南鹏程医疗设备有限公司";  // 供应商名字
                    dataRow_cWSLwxData["ReceiptNo"] = "80462720";                     // 入库单号
                    dataRow_cWSLwxData["InboundDate"] = "2020-06-10";                 // 入库日期
                    dataRow_cWSLwxData["NumberOfPages"] = "1/3";                      // 页码
                    dataRow_cWSLwxData["TotalAmount"] = "977.5";                      // 表单总金额
                    dataRow_cWSLwxData["AcceptanceOfThePeople"] = "许欣伟";           // 验收人
                    dataRow_cWSLwxData["Supplier"] = "张楠林";                        // 供应商
                    dataRow_cWSLwxData["WarehouseOperator"] = "刘月";                 // 仓库员
                    cWSLwxData.Rows.Add(dataRow_cWSLwxData);
                }
                //string ssda = cWSLwxData.Rows[2][0].ToString();
                //System.Diagnostics.Debug.WriteLine(ssda);

                #endregion
                #endregion

                #region 多次扫描数据矫正
                DataReconciliation dataReconciliation = new DataReconciliation();
                // 校验结果
                //string[] se = new string[] { "小马", "小马", "小狗" };
                //string dataReconciliationResult = dataReconciliation.DataReconciliationMethod(se);
                //System.Diagnostics.Debug.WriteLine(dataReconciliationResult);

                /// <summary>
                /// 数据校验_耗材仓库耗材入库单
                /// </summary>
                /// <param name="cWSLs">cWSLs数据</param>
                /// <param name="DATAPass_CWSL">是否通过</param>
                /// <returns>CWSL数据</returns>
                cWSL_ComparisonInformation = dataReconciliation.DataReconciliation_CWSL(cWSLwxData, out int DATAPass_CWSL);  // 扫描+校验处理后到的信息
                DATAPass = DATAPass_CWSL;
                #endregion
            }
            #endregion

            #region 判断是否保存过
            // 是否保存过 判断
            int i = 0; // 0-未读取过 ；1-读取过
            int cWSLHistoryrowscount = cWSLHistoryData.Rows.Count;
            if (cWSLHistoryrowscount > 0)
            {
                int rowcheck = 0;
                // 拿当前扫描到的信息与刚刚记录去比较(供应商名称,入库日期,入库单号,页码)
                for (int cWSLhrcount = 0; cWSLhrcount < cWSLHistoryrowscount; cWSLhrcount++)
                {
                    if (cWSL_ComparisonInformation.SupplierName == cWSLHistoryData.Rows[cWSLhrcount]["SupplierName"].ToString()      // 供应商
                        && cWSL_ComparisonInformation.InboundDate == cWSLHistoryData.Rows[cWSLhrcount]["SupplierName"].ToString()    // 入库日期
                        && cWSL_ComparisonInformation.ReceiptNo == cWSLHistoryData.Rows[cWSLhrcount]["SupplierName"].ToString()      // 入库单号
                        && cWSL_ComparisonInformation.NumberOfPages == cWSLHistoryData.Rows[cWSLhrcount]["SupplierName"].ToString()  // 页码
                        )
                    {
                        rowcheck++;
                    }
                }
                if (rowcheck>0)
                {
                    i = 1;
                }
            }
            #endregion

            #region 页码处理
            // 页码截取处理
            PageNumber pageNumber = new PageNumber();
            pageNumber.PageNumberProcessing(cWSL_ComparisonInformation.NumberOfPages, out int NumberOfPage_CWSL, out int NumberOfPages_CWSL);  // PageNumberProcessing(原值,当前页值,总页值)
            NumberOfPageNew = NumberOfPage_CWSL;
            // 页码判断
            int pageNumberpass = pageNumber.PageOrder(i, NumberOfPage_CWSL, NumberOfPages_CWSL, out int numberOfPageshow);   // PageOrder(是否读取过,当前页数,总页数,请放入第" + numberOfPageshow + "页)
            #endregion

            #region 签字判断
            // 全部签字判断
            if (cWSL_ComparisonInformation.AcceptanceOfThePeople.Length > 0 && cWSL_ComparisonInformation.Supplier.Length > 0 && cWSL_ComparisonInformation.WarehouseOperator.Length > 0)
            {
                Sign = "已签字";
            }
            else
            {
                // Sign结果显示
                string SignResultStr = "";
                if (cWSL_ComparisonInformation.AcceptanceOfThePeople.Length > 0)
                {
                    SignResultStr = SignResultStr + "验收人 ";
                }
                if (cWSL_ComparisonInformation.Supplier.Length > 0)
                {
                    SignResultStr = SignResultStr + "供应商 ";
                }
                if (cWSL_ComparisonInformation.WarehouseOperator.Length > 0)
                {
                    SignResultStr = SignResultStr + "仓库员 ";
                }
                SignResultStr = SignResultStr + "未签名";
                // 签字提示
                Sign = SignResultStr;
            }
            #endregion

            // 0-读取并初始一些数据变量，1-读取，2-请放入第" + numberOfPageshow + "页，3-请从第1/" + numberOfPages + "页开始读取
            switch (pageNumberpass)
            {
                case 0:
                    // 0-读取并初始一些数据变量
                    id = "耗材仓库耗材入库单 - " + cWSL_ComparisonInformation.NumberOfPages;
                    TotalAmount= cWSL_ComparisonInformation.TotalAmount;
                    // 存储下来
                    DataRow dataRow_cWSLHistoryDataLast = cWSLHistoryData.NewRow();
                    dataRow_cWSLHistoryDataLast["SupplierName"] = "济南鹏程医疗设备有限公司";  // 供应商名字
                    dataRow_cWSLHistoryDataLast["ReceiptNo"] = "80462720";                     // 入库单号
                    dataRow_cWSLHistoryDataLast["InboundDate"] = "2020-06-10";                 // 入库日期
                    dataRow_cWSLHistoryDataLast["NumberOfPages"] = "1/3";                      // 页码
                    dataRow_cWSLHistoryDataLast["TotalAmount"] = "977.5";                      // 表单总金额
                    dataRow_cWSLHistoryDataLast["Sign"] = Sign;                                // 签字
                    cWSLwxData.Rows.Add(dataRow_cWSLHistoryDataLast);
                    Information = "读取成功";
                    #region 存储到的各张表单对比
                    // 各张金额对比
                    int cWSLHisDataRowCountResult = 0; // 
                    for (int cWSLHisDataRowcount = 1; cWSLHisDataRowcount < cWSLHistoryData.Rows.Count; cWSLHisDataRowcount++)
                    {
                        if (cWSLHistoryData.Rows[cWSLHisDataRowcount]["TotalAmount"].ToString() == cWSLHistoryData.Rows[cWSLHisDataRowcount - 1]["TotalAmount"].ToString())
                        {
                            cWSLHisDataRowCountResult++;
                        }
                    }
                    if (cWSLHisDataRowCountResult == cWSLHistoryData.Rows.Count-1) // 各张表单对比通过
                    {
                        // 调用万序比对接口
                        // 显示万序处理后的结果信息
                        if (true) // 万旭处理结果 + 签字
                        {
                            Pass = "通过";
                        }
                        else { Pass = "不通过"; }
                    }
                    else
                    {
                        TotalAmount = "各张表单存在金额不一致情况";
                        Pass = "请重新扫描此份表单";
                    }
                    #endregion
                    //初始化。。

                    break;
                case 1:
                    // 1-读取
                    id = "耗材仓库耗材入库单 - " + cWSL_ComparisonInformation.NumberOfPages;
                    Information = "读取成功";
                    TotalAmount = cWSL_ComparisonInformation.TotalAmount;
                    Pass = "";
                    // 存储下来
                    DataRow dataRow_cWSLHistoryData = cWSLHistoryData.NewRow();
                    dataRow_cWSLHistoryData["SupplierName"] = "济南鹏程医疗设备有限公司";  // 供应商名字
                    dataRow_cWSLHistoryData["ReceiptNo"] = "80462720";                     // 入库单号
                    dataRow_cWSLHistoryData["InboundDate"] = "2020-06-10";                 // 入库日期
                    dataRow_cWSLHistoryData["NumberOfPages"] = "1/3";                      // 页码
                    dataRow_cWSLHistoryData["TotalAmount"] = "977.5";                      // 表单总金额
                    dataRow_cWSLHistoryData["Sign"] = Sign;                                // 签字
                    cWSLwxData.Rows.Add(dataRow_cWSLHistoryData);
                    break;           
                case 2:
                    // 2-请放入第" + numberOfPageshow + "页
                    id = "耗材仓库耗材入库单 - " + cWSL_ComparisonInformation.NumberOfPages;
                    Information = "请放入第" + numberOfPageshow + "页";
                    TotalAmount = "";
                    Pass = "";
                    break;
                case 3:
                    // 3-请从第1/" + numberOfPages + "页开始读取
                    id = "耗材仓库耗材入库单 - " + cWSL_ComparisonInformation.NumberOfPages;
                    Information = "请从第1/" + NumberOfPages_CWSL + "页开始读取";
                    TotalAmount = "";
                    Pass = "";
                    break;
                default:
                    id = "";
                    TotalAmount = "";
                    Pass = "";
                    Information = "";
                    break;
            }

        }

        /// <summary>
        /// 耗材仓库配送出库单
        /// </summary>
        /// <param name="cWDL_id"></param>
        /// <param name="cWDL_TotalAmount"></param>
        /// <param name="cWDL_Sign"></param>
        /// <param name="cWDL_Pass"></param>
        /// <param name="cWDL_Seal"></param>
        /// <param name="Information"></param>
        internal void CWDLList(out string cWDL_id, out string cWDL_TotalAmount, out string cWDL_Sign, out string cWDL_Pass,out string cWDL_Seal, out string cWDL_Information)
        {
            CWDL cWDL_ComparisonInformation = new CWDL(); // 扫描到的值-数据矫正完的数据
            #region 数据获取和取可靠值检验
            for (int DATAPass = 0; DATAPass < 1;)   // 校验不通过-循环"获取数据+校验"
            {
                #region 扫描到的信息-假
                // 扫描到的信息
                #region 一维值
                // 扫描到的值-ComparisonInformation
                //cWDL_ComparisonInformation.FormsTitle = "耗材仓库配送出库单";                        // 表单标题
                //cWDL_ComparisonInformation.NameOfCollectingDepartment = "介入诊疗科";                // 领用科室名称
                //cWDL_ComparisonInformation.DataOfOutbound = "2020-06-12";                            // 出库日期
                //cWDL_ComparisonInformation.OutboundOrderNo = "957546";                               // 出库单号
                //cWDL_ComparisonInformation.SerialNumber = "ZYHOUTHV2020061000772";                   // 流水号

                //cWDL_ComparisonInformation.AmountOnThisPage = "42731.00";                            // 本页合计
                //cWDL_ComparisonInformation.TotalAmount = "162408.47";                                // 总金额
                //cWDL_ComparisonInformation.NumberOfPages = "1/3";                                    // 页码

                //cWDL_ComparisonInformation.Auditor = "王桂彭";                                       // 复核人
                //cWDL_ComparisonInformation.Distributor = "王桂彭";                                   // 配送人
                //cWDL_ComparisonInformation.DepartmentConsignee = "刘二";                             // 科室收货人
                //cWDL_ComparisonInformation.DepartmentSeal = "已盖章";                                // 科室盖章
                #endregion
                #region 二维值
                for (int rowscount = 0; rowscount < 3; rowscount++)
                {
                    DataRow dataRow_cWDLwxData = cWDLwxData.NewRow();
                    dataRow_cWDLwxData["FormsTitle"] = "耗材仓库配送出库单";           // 表单标题
                    dataRow_cWDLwxData["NameOfCollectingDepartment"] = "介入诊疗科";   // 领用科室名称
                    dataRow_cWDLwxData["DataOfOutbound"] = "2020-06-12";               // 出库日期
                    dataRow_cWDLwxData["OutboundOrderNo"] = "957546";                  // 出库单号
                    dataRow_cWDLwxData["SerialNumber"] = "ZYHOUTHV2020061000772";      // 流水号
                    dataRow_cWDLwxData["AmountOnThisPage"] = "42731.00";               // 本页合计
                    dataRow_cWDLwxData["TotalAmount"] = "162408.47";                   // 总金额
                    dataRow_cWDLwxData["NumberOfPages"] = "1/3"; ;                     // 页码
                    dataRow_cWDLwxData["Auditor"] = "王桂彭";                          // 复核人
                    dataRow_cWDLwxData["Distributor"] = "王桂彭";                      // 配送人
                    dataRow_cWDLwxData["DepartmentConsignee"] = "刘月";                // 科室收货人
                    dataRow_cWDLwxData["DepartmentSeal"] = "已盖章";                   // 科室盖章
                    cWDLwxData.Rows.Add(dataRow_cWDLwxData);
                }
                //string ssda = cWDLwxData.Rows[2][0].ToString();
                //System.Diagnostics.Debug.WriteLine(ssda);

                #endregion
                #endregion

                #region 多次扫描数据矫正
                DataReconciliation dataReconciliation = new DataReconciliation();
                // 校验结果
                //string[] se = new string[] { "小马", "小马", "小狗" };
                //string dataReconciliationResult = dataReconciliation.DataReconciliationMethod(se);
                //System.Diagnostics.Debug.WriteLine(dataReconciliationResult);

                /// <summary>
                /// 数据校验_耗材仓库配送出库单
                /// </summary>
                /// <param name="CWDLwxData">CWDLs数据</param>
                /// <param name="DATAPass_CWDL">是否通过</param>
                /// <returns>CWDL数据</returns>
                cWDL_ComparisonInformation = dataReconciliation.DataReconciliation_CWDL(cWDLwxData, out int DATAPass_CWDL);  // 扫描+校验处理后到的信息
                DATAPass = DATAPass_CWDL;
                #endregion
            }
            #endregion

            #region 判断是否保存过
            // 是否保存过 判断
            int i = 0; // 0-未读取过 ；1-读取过
            int cWDLHistoryrowscount = cWDLHistoryData.Rows.Count;
            if (cWDLHistoryrowscount > 0)
            {
                int rowcheck = 0;
                // 拿当前扫描到的信息与刚刚记录去比较
                for (int cWDLhrcount = 0; cWDLhrcount < cWDLHistoryrowscount; cWDLhrcount++)
                {
                    if (cWDL_ComparisonInformation.NameOfCollectingDepartment == cWDLHistoryData.Rows[cWDLhrcount]["NameOfCollectingDepartment"].ToString()  // 领用科室名称
                        && cWDL_ComparisonInformation.DataOfOutbound == cWDLHistoryData.Rows[cWDLhrcount]["DataOfOutbound"].ToString()                       // 出库日期
                        && cWDL_ComparisonInformation.OutboundOrderNo == cWDLHistoryData.Rows[cWDLhrcount]["OutboundOrderNo"].ToString()                     // 出库单号
                        && cWDL_ComparisonInformation.SerialNumber == cWDLHistoryData.Rows[cWDLhrcount]["SerialNumber"].ToString()                           // 流水号
                        && cWDL_ComparisonInformation.NumberOfPages == cWDLHistoryData.Rows[cWDLhrcount]["NumberOfPages"].ToString()                         // 页码
                        )
                    {
                        rowcheck++;
                    }
                }
                if (rowcheck > 0)
                {
                    i = 1;
                }
            }
            #endregion

            #region 页码处理
            // 页码截取处理
            PageNumber pageNumber = new PageNumber();
            pageNumber.PageNumberProcessing(cWDL_ComparisonInformation.NumberOfPages, out int NumberOfPage_CWDL, out int NumberOfPages_CWDL);  // PageNumberProcessing(原值,当前页值,总页值)
            NumberOfPageNew = NumberOfPage_CWDL;  // 记录当前页
            // 页码判断
            int pageNumberpass = pageNumber.PageOrder(i, NumberOfPage_CWDL, NumberOfPages_CWDL, out int numberOfPageshow);   // PageOrder(是否读取过,当前页数,总页数,请放入第" + numberOfPageshow + "页)
            #endregion

            #region 签字判断
            // 全部签字判断
            if (cWDL_ComparisonInformation.Auditor.Length > 0 && cWDL_ComparisonInformation.Distributor.Length > 0 && cWDL_ComparisonInformation.DepartmentConsignee.Length > 0)
            {
                cWDL_Sign = "已签字";
            }
            else
            {
                // Sign结果显示
                string SignResultStr = "";
                if (cWDL_ComparisonInformation.Auditor.Length > 0)
                {
                    SignResultStr = SignResultStr + "复核人 ";
                }
                if (cWDL_ComparisonInformation.Distributor.Length > 0)
                {
                    SignResultStr = SignResultStr + "配送人 ";
                }
                if (cWDL_ComparisonInformation.DepartmentConsignee.Length > 0)
                {
                    SignResultStr = SignResultStr + "科室收货人 ";
                }
                SignResultStr = SignResultStr + "未签名";
                // 签字提示
                cWDL_Sign = SignResultStr;
            }
            #endregion

            #region 盖章判断
            cWDL_Seal = cWDL_ComparisonInformation.DepartmentSeal;
            #endregion
            // 0-读取并初始一些数据变量，1-读取，2-请放入第" + numberOfPageshow + "页，3-请从第1/" + numberOfPages + "页开始读取
            switch (pageNumberpass)
            {
                case 0:
                    // 0-读取并初始一些数据变量
                    cWDL_id = "耗材仓库配送出库单 - " + cWDL_ComparisonInformation.NumberOfPages;
                    cWDL_TotalAmount = cWDL_ComparisonInformation.TotalAmount;
                    // 存储下来
                    DataRow dataRow_cWSLHistoryDataLast = cWSLHistoryData.NewRow();
                    dataRow_cWSLHistoryDataLast["SupplierName"] = "济南鹏程医疗设备有限公司";  // 供应商名字
                    dataRow_cWSLHistoryDataLast["ReceiptNo"] = "80462720";                     // 入库单号
                    dataRow_cWSLHistoryDataLast["InboundDate"] = "2020-06-10";                 // 入库日期
                    dataRow_cWSLHistoryDataLast["NumberOfPages"] = "1/3";                      // 页码
                    dataRow_cWSLHistoryDataLast["TotalAmount"] = "977.5";                      // 表单总金额
                    dataRow_cWSLHistoryDataLast["Sign"] = cWDL_Sign;                                // 签字
                    cWSLwxData.Rows.Add(dataRow_cWSLHistoryDataLast);
                    cWDL_Information = "读取成功";
                    #region 存储到的各张表单对比
                    // 各张金额对比
                    int sHILHisDataRowCountResult = 0; // 
                    for (int sHILHisDataRowcount = 1; sHILHisDataRowcount < cWSLHistoryData.Rows.Count; sHILHisDataRowcount++)
                    {
                        if (cWSLHistoryData.Rows[sHILHisDataRowcount]["TotalAmount"].ToString() == cWSLHistoryData.Rows[sHILHisDataRowcount - 1]["TotalAmount"].ToString())
                        {
                            sHILHisDataRowCountResult++;
                        }
                    }
                    if (sHILHisDataRowCountResult == cWSLHistoryData.Rows.Count - 1) // 各张表单对比通过
                    {
                        // 调用万序比对接口
                        // 显示万序处理后的结果信息
                        if (true) // 万旭处理结果 + 签字 + 盖章
                        {
                            cWDL_Pass = "通过";
                        }
                        else { cWDL_Pass = "不通过"; }
                    }
                    else
                    {
                        cWDL_TotalAmount = "各张表单存在金额不一致情况";
                        cWDL_Pass = "请重新扫描此份表单";
                    }
                    #endregion
                    //初始化。。

                    break;
                case 1:
                    // 1-读取
                    cWDL_id = "耗材仓库配送出库单 - " + cWDL_ComparisonInformation.NumberOfPages;
                    cWDL_Information = "读取成功";
                    cWDL_TotalAmount = cWDL_ComparisonInformation.TotalAmount;
                    cWDL_Pass = "";
                    // 存储下来
                    DataRow dataRow_cWSLHistoryData = cWSLHistoryData.NewRow();
                    dataRow_cWSLHistoryData["SupplierName"] = "济南鹏程医疗设备有限公司";  // 供应商名字
                    dataRow_cWSLHistoryData["ReceiptNo"] = "80462720";                     // 入库单号
                    dataRow_cWSLHistoryData["InboundDate"] = "2020-06-10";                 // 入库日期
                    dataRow_cWSLHistoryData["NumberOfPages"] = "1/3";                      // 页码
                    dataRow_cWSLHistoryData["TotalAmount"] = "977.5";                      // 表单总金额
                    dataRow_cWSLHistoryData["Sign"] = cWDL_Sign;                                // 签字
                    cWSLwxData.Rows.Add(dataRow_cWSLHistoryData);
                    break;
                case 2:
                    // 2-请放入第" + numberOfPageshow + "页
                    cWDL_id = "耗材仓库配送出库单 - " + cWDL_ComparisonInformation.NumberOfPages;
                    cWDL_Information = "请放入第" + numberOfPageshow + "页";
                    cWDL_TotalAmount = "";
                    cWDL_Pass = "";
                    break;
                case 3:
                    // 3-请从第1/" + numberOfPages + "页开始读取
                    cWDL_id = "耗材仓库配送出库单 - " + cWDL_ComparisonInformation.NumberOfPages;
                    cWDL_Information = "请从第1/" + NumberOfPages_CWDL + "页开始读取";
                    cWDL_TotalAmount = "";
                    cWDL_Pass = "";
                    break;
                default:
                    cWDL_id = "";
                    cWDL_TotalAmount = "";
                    cWDL_Pass = "";
                    cWDL_Information = "";
                    break;
            }
        }
    }
}
