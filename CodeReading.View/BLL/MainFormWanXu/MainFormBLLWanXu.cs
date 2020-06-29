using CodeReading.Entity.MainForm.MainNew;
using CodeReading.View.BLL.MainFormNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReading.View.BLL.MainFormWanXu
{
    public class MainFormBLLWanXu
    {
        // 当前页码
        int NumberOfPageNew_CWSL = 0;          // 
        /// <summary>
        /// 仓库
        /// </summary>
        /// <param name="cWSL_id"></param>
        /// <param name="cWSL_TotalAmount"></param>
        /// <param name="cWSL_Sign"></param>
        /// <param name="cWSL_Pass"></param>
        internal void CWSLList(out string id, out string TotalAmount, out string Sign, out string Pass)
        {
            #region 扫描到的信息-假
            // 扫描到的信息
            // 扫描到的值-ComparisonInformation
            CWSL cWSL_ComparisonInformation = new CWSL();
            cWSL_ComparisonInformation.SupplierName = "济南鹏程医疗设备有限公司";  // 供应商
            cWSL_ComparisonInformation.ReceiptNo = "80462720";                     // 入库单号
            cWSL_ComparisonInformation.InboundDate = "2020-06-10";                 // 入库日期

            cWSL_ComparisonInformation.NumberOfPages = "1/3";                      // 页码
            cWSL_ComparisonInformation.TotalAmount = "977.5";                      // 表单总金额

            cWSL_ComparisonInformation.AcceptanceOfThePeople = "许欣伟";           // 验收人
            cWSL_ComparisonInformation.Supplier = "张楠林";                        // 供应商
            cWSL_ComparisonInformation.WarehouseOperator = "刘月";                 // 仓库员
            #endregion
            #region 多次扫描数据矫正

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
        }

        internal void CWDLList(out string cWDL_id, out string cWDL_TotalAmount, out string cWDL_Sign, out string cWDL_Seal, out string cWDL_Pass)
        {
            throw new NotImplementedException();
        }
    }
}
