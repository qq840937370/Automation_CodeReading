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
        /// SHIL数据表
        /// </summary>   
        public MainFormWanXuDataSet.SHILwxDataTable sHILwxData = new MainFormWanXuDataSet.SHILwxDataTable();
        // 当前页码
        int NumberOfPageNew_CWSL = 0;          // 
        /// <summary>
        /// 耗材仓库耗材入库单
        /// </summary>
        /// <param name="cWSL_id"></param>
        /// <param name="cWSL_TotalAmount"></param>
        /// <param name="cWSL_Sign"></param>
        /// <param name="cWSL_Pass"></param>
        internal void CWSLList(out string id, out string TotalAmount, out string Sign, out string Pass)
        {
            #region 数据获取和取可靠值检验
            for (int DATAPass; DATAPass= 0;)   // 校验不通过-循环"获取数据+校验"
            {
                #region 扫描到的信息-假
                // 扫描到的信息
                CWSL cWSL_ComparisonInformation = new CWSL();
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
                //    cWSLs[1].SupplierName = "济南鹏程医疗设备有限公司";  // 供应商
                //    cWSLs[1].ReceiptNo = "80462720";                     // 入库单号
                //    cWSLs[1].InboundDate = "2020-06-10";                 // 入库日期
                //    cWSLs[1].NumberOfPages = "1/3";                      // 页码
                //    cWSLs[1].TotalAmount = "977.5";                      // 表单总金额
                //    cWSLs[1].AcceptanceOfThePeople = "许欣伟";           // 验收人
                //    cWSLs[1].Supplier = "张楠林";                        // 供应商
                //    cWSLs[1].WarehouseOperator = "刘月";                 // 仓库员

                //    cWSLs[2].SupplierName = "济南程程医疗设备有限公司";  // 供应商
                //    cWSLs[2].ReceiptNo = "60462720";                     // 入库单号
                //    cWSLs[2].InboundDate = "1020-06-10";                 // 入库日期
                //    cWSLs[2].NumberOfPages = "3/3";                      // 页码
                //    cWSLs[2].TotalAmount = "677.5";                      // 表单总金额
                //    cWSLs[2].AcceptanceOfThePeople = "许欣两";           // 验收人
                //    cWSLs[2].Supplier = "墙楠林";                        // 供应商
                //    cWSLs[2].WarehouseOperator = "刘未";                 // 仓库员
                for (int rowscount = 0; rowscount < 3; rowscount++)
                {
                    DataRow dataRow_sHILwxData = sHILwxData.NewRow();
                    dataRow_sHILwxData["SupplierName"] = "济南鹏程医疗设备有限公司";  // 供应商
                    dataRow_sHILwxData["ReceiptNo"] = "80462720";                     // 入库单号
                    dataRow_sHILwxData["InboundDate"] = "2020-06-10";                 // 入库日期
                    dataRow_sHILwxData["NumberOfPages"] = "1/3";                      // 页码
                    dataRow_sHILwxData["TotalAmount"] = "977.5";                      // 表单总金额
                    dataRow_sHILwxData["AcceptanceOfThePeople"] = "许欣伟";           // 验收人
                    dataRow_sHILwxData["Supplier"] = "张楠林";                        // 供应商
                    dataRow_sHILwxData["WarehouseOperator"] = "刘月";                 // 仓库员
                    sHILwxData.Rows.Add(dataRow_sHILwxData);
                }
                //string ssda = sHILwxData.Rows[2][0].ToString();
                //System.Diagnostics.Debug.WriteLine(ssda);

                #endregion
                #endregion
                #region 多次扫描数据矫正
                DataReconciliation dataReconciliation = new DataReconciliation();
                // 校验结果
                //string[] se = new string[] { "小马", "小马", "小狗" };
                //string dataReconciliationResult = dataReconciliation.DataReconciliationMethod(se);
                //System.Diagnostics.Debug.WriteLine(dataReconciliationResult);
                cWSL_ComparisonInformation = dataReconciliation.DataReconciliation_CWSL(sHILwxData, out int DATAPass_CWSL);  // 扫描+校验处理后到的信息
                DATAPass = DATAPass_CWSL;
                #endregion
            }
            #endregion
            #region 页码处理
            // 页码截取处理
            PageNumber pageNumber = new PageNumber();
            pageNumber.PageNumberProcessing(cWSL_ComparisonInformation.NumberOfPages, out int NumberOfPage_CWSL, out int NumberOfPages_CWSL);
            NumberOfPageNew_CWSL = NumberOfPage_CWSL;
            // 页码判断
            int i = 0; // 0-未读取过 ；1-读取过
            int pageNumberpass = pageNumber.PageOrder(i, NumberOfPage_CWSL, NumberOfPages_CWSL, out int numberOfPageshow);
            // 0-读取并初始一些数据变量，1-读取，2-请放入第" + numberOfPageshow + "页，3-请从第1/" + numberOfPages + "页开始读取
            switch (pageNumberpass)
            {
                case 0:
                    // 0-读取并初始一些数据变量
                    break;
                case 1:
                    // 1-读取
                    break;
                case 2:
                    // 2-请放入第" + numberOfPageshow + "页
                    break;
                case 3:
                    // 3-请从第1/" + numberOfPages + "页开始读取
                    break;
                default:
                    break;
            }
            #endregion

            id = "";
            TotalAmount = "";
            Sign = "";
            Pass = "";
        }
        // 耗材仓库配送出库单
        internal void CWDLList(out string cWDL_id, out string cWDL_TotalAmount, out string cWDL_Sign, out string cWDL_Seal, out string cWDL_Pass)
        {
            throw new NotImplementedException();
        }
    }
}
