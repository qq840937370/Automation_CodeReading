/*  
 *  扫描到的信息
 *  扫描到的值 - ComparisonInformation
 *  cWSL_ComparisonInformation.SupplierName = "济南鹏程医疗设备有限公司";  // 供应商
 *  cWSL_ComparisonInformation.ReceiptNo = "80462720";                     // 入库单号
 *  cWSL_ComparisonInformation.InboundDate = "2020-06-10";                 // 入库日期
 *
 *  cWSL_ComparisonInformation.NumberOfPages = "1/3";                      // 页码
 *  cWSL_ComparisonInformation.TotalAmount = "977.5";                      // 表单总金额
 *
 *  cWSL_ComparisonInformation.AcceptanceOfThePeople = "许欣伟";           // 验收人
 *  cWSL_ComparisonInformation.Supplier = "张楠林";                        // 供应商
 *  cWSL_ComparisonInformation.WarehouseOperator = "刘月";                 // 仓库员
 */
using CodeReading.Entity;
using CodeReading.Entity.MainForm.MainNew;
using System;

namespace CodeReading.View.BLL.MainFormNew
{

    public class DataReconciliation
    {
        /// <summary>
        /// 数据校验/传3条数据
        /// </summary>
        /// <param name="nums"></param>
        /// <returns>满足条件返回检验后的值，不满足（三次都不一样）返回“DataRFalse”</returns>
        private string DataReconciliationMethod(string[] nums)
        {
            int cnt = 1;
            string res = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                //也可直接遍历数组for(int num:nums)
                if (cnt == 0)
                {
                    res = nums[i];
                }
                if (res == nums[i]) ++cnt;
                else --cnt;
            }
            // 不能得出众数验证
            int resNumber = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (res == nums[i])
                {
                    resNumber++;
                }
            }
            if (resNumber > nums.Length / 2)
            {
                return res;
            }
            else
            {
                return "DataRFalse";
            }
        }
        /// <summary>
        /// 数据校验模板
        /// </summary>
        public void DataReconciliationModel()
        {
            //校验结果
            string[] se = new string[] { "小马", "小马", "小狗" };
            string dataReconciliationResult = DataReconciliationMethod(se);
            System.Diagnostics.Debug.WriteLine(dataReconciliationResult);
        }

        /// <summary>
        /// 数据校验_耗材仓库耗材入库单
        /// </summary>
        /// <param name="cWSLs">cWSLs数据</param>
        /// <param name="DATAPass_CWSL">是否通过</param>
        /// <returns>CWSL数据</returns>
        public CWSL DataReconciliation_CWSL(MainFormWanXuDataSet.CWSLwxDataTable cWSLs,out int DATAPass_CWSL)
        {
            /*
             *  数据校验
             */
            CWSL cWSL_ComparisonInformation = new CWSL();
            #region SupplierName 例子
            //string[] Array_SupplierName = new string[] { cWSLs.Rows[0]["SupplierName"].ToString(), cWSLs.Rows[1]["SupplierName"].ToString(), cWSLs.Rows[2]["SupplierName"].ToString() };
            //string dataReconciliationResult_SupplierName = DataReconciliationMethod(Array_SupplierName);

            //// dataReconciliationResult是DataRFalse
            //if (String.Equals(dataReconciliationResult_SupplierName, "DataRFalse"))
            //{

            //}
            //// dataReconciliationResult不是DataRFalse
            //else
            //{
            //    cWSL_ComparisonInformation.SupplierName = dataReconciliationResult_SupplierName;
            //}
            #endregion
            #region 总方法
            // 行数
            //int RowsCount = cWSLs.Rows.Count;
            // 列数
            int ColumnsCount = cWSLs.Columns.Count;
            System.Diagnostics.Debug.WriteLine(cWSLs.Rows[0][7].ToString());  //输出值
            // 接受数据的数组
            string[] dataReconciliationResult = new string[8] {"","","","","","","",""};
            // 列
            for (int columnCount = 0; columnCount < ColumnsCount; ++columnCount)
            {
                string[] Array = new string[] { cWSLs.Rows[0][columnCount].ToString(), cWSLs.Rows[1][columnCount].ToString(), cWSLs.Rows[2][columnCount].ToString() };
                dataReconciliationResult[columnCount] = DataReconciliationMethod(Array);
            }
            // 验证是否通过
            int checkDataPass = 0;  // 通过验证值
            for (int columnCount = 0; columnCount < ColumnsCount; columnCount++)
            {
                //if (dataReconciliationResult[columnCount] == "DataRFalse")
                if(!String.Equals(dataReconciliationResult[columnCount], "DataRFalse"))
                {
                    checkDataPass++;
                }
            }
            if (checkDataPass == ColumnsCount)  // 当“通过验证值=列数”时，即通过
            {
                cWSL_ComparisonInformation.SupplierName = dataReconciliationResult[0];                // 供应商
                cWSL_ComparisonInformation.ReceiptNo = dataReconciliationResult[1];                   // 入库单号
                cWSL_ComparisonInformation.InboundDate = dataReconciliationResult[2];                 // 入库日期

                cWSL_ComparisonInformation.NumberOfPages = dataReconciliationResult[3];               // 页码
                cWSL_ComparisonInformation.TotalAmount = dataReconciliationResult[4];                 // 表单总金额

                cWSL_ComparisonInformation.AcceptanceOfThePeople = dataReconciliationResult[5];       // 验收人
                cWSL_ComparisonInformation.Supplier = dataReconciliationResult[6];                    // 供应商
                cWSL_ComparisonInformation.WarehouseOperator = dataReconciliationResult[7];           // 仓库员

                DATAPass_CWSL = 1;   // 通过
            }
            else
            {
                DATAPass_CWSL = 0;   // 不通过
            }
            return cWSL_ComparisonInformation;
            #endregion
        }
        /// <summary>
        /// 数据校验_耗材仓库配送出库单
        /// </summary>
        /// <param name="cWDLs"></param>
        /// <param name="DATAPass_CWDL"></param>
        /// <returns></returns>
        public CWDL DataReconciliation_CWDL(MainFormWanXuDataSet.CWDLwxDataTable cWDLs, out int DATAPass_CWDL)
        {
            /*
             *  数据校验
             */
            CWDL cWDL_ComparisonInformation = new CWDL();
            #region 总方法
            // 行数
            //int RowsCount = cWDLs.Rows.Count;
            // 列数
            int ColumnsCount = cWDLs.Columns.Count;
            System.Diagnostics.Debug.WriteLine(cWDLs.Rows[0][7].ToString());  //输出值
            // 接受数据的数组
            string[] dataReconciliationResult = new string[11] { "", "", "", "", "", "", "", "", "", "", "" };
            // 列
            for (int columnCount = 0; columnCount < ColumnsCount; ++columnCount)
            {
                string[] Array = new string[] { cWDLs.Rows[0][columnCount].ToString(), cWDLs.Rows[1][columnCount].ToString(), cWDLs.Rows[2][columnCount].ToString() };
                dataReconciliationResult[columnCount] = DataReconciliationMethod(Array);
            }
            // 验证是否通过
            int checkDataPass = 0;  // 通过验证值
            for (int columnCount = 0; columnCount < ColumnsCount; columnCount++)
            {
                //if (dataReconciliationResult[columnCount] == "DataRFalse")
                if (!String.Equals(dataReconciliationResult[columnCount], "DataRFalse"))
                {
                    checkDataPass++;
                }
            }
            if (checkDataPass == ColumnsCount)  // 当“通过验证值=列数”时，即通过
            {
                cWDL_ComparisonInformation.NameOfCollectingDepartment = dataReconciliationResult[0];       // 领用科室名称
                cWDL_ComparisonInformation.DataOfOutbound = dataReconciliationResult[1];                   // 出库日期
                cWDL_ComparisonInformation.OutboundOrderNo = dataReconciliationResult[2];                  // 出库单号
                cWDL_ComparisonInformation.SerialNumber = dataReconciliationResult[3];                     // 流水号

                cWDL_ComparisonInformation.NumberOfPages = dataReconciliationResult[4];                    // 页码
                cWDL_ComparisonInformation.AmountOnThisPage = dataReconciliationResult[5];                 // 本页合计
                cWDL_ComparisonInformation.TotalAmount = dataReconciliationResult[6];                      // 总金额

                cWDL_ComparisonInformation.Auditor = dataReconciliationResult[7];                          // 复核人
                cWDL_ComparisonInformation.Distributor = dataReconciliationResult[8];                      // 配送人
                cWDL_ComparisonInformation.DepartmentConsignee = dataReconciliationResult[9];              // 科室收货人
                cWDL_ComparisonInformation.DepartmentSeal = dataReconciliationResult[10];                  // 科室盖章

                DATAPass_CWDL = 1;   // 通过
            }
            else
            {
                DATAPass_CWDL = 0;   // 不通过
            }
            return cWDL_ComparisonInformation;
            #endregion
        }
    }
}
