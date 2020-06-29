using CodeReading.Entity.MainForm.MainNew;

namespace CodeReading.View.BLL.MainFormNew
{
    public class MainFormBLLNew
    {
        #region 全局变量
        #region 耗材仓库耗材入库单处理方法使用
        string SupplierNameold_CWSL ="";      // 供应商old
        string ReceiptNoNameold_CWSL ="";     // 入库单号old
        string InboundDateold_CWSL="";        // 入库日期old
        int NumberOfPageOld_CWSL =0;          // 
        int NumberOfPageNew_CWSL =0;          // 
        #endregion
        #endregion

        // 初始化
        ReadJson readJson = new ReadJson();

        /// <summary>
        /// 耗材仓库耗材入库单处理方法
        /// </summary>
        public void CWSLList(out string id, out string TotalAmount,out string Sign,out string Pass)
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
            #region 页码处理
            // 页码截取处理
            PageNumber pageNumber = new PageNumber();
            pageNumber.PageNumberProcessing(cWSL_ComparisonInformation.NumberOfPages, out int NumberOfPage_CWSL, out int NumberOfPages_CWSL);

            NumberOfPageNew_CWSL = NumberOfPage_CWSL;
            // 页码判断
            int i=1;
            pageNumber.PageOrder( i, NumberOfPage_CWSL, NumberOfPages_CWSL, out int numberOfPageshow);
            #endregion

            #region
            #region 向服务器请求数据-假
             // 请求条件-略
             // 请求到的值-ComparisonInformationSource
             CWSL cWSL_ComparisonInformationSource = new CWSL();
            cWSL_ComparisonInformationSource = readJson.Readjson_CWSL();
            //System.Diagnostics.Debug.WriteLine(cWSL_ComparisonInformationSource.SupplierName.ToString());
            #endregion

            #region 对比
            // 表单总金额=JSON文件：表单总金额
            {
                if (cWSL_ComparisonInformation.TotalAmount == cWSL_ComparisonInformationSource.TotalAmount &&    // 金钱数一致
                    cWSL_ComparisonInformation.AcceptanceOfThePeople.Length > 0 &&                               // 签字
                    cWSL_ComparisonInformation.Supplier.Length > 0 &&                                            // 签字
                    cWSL_ComparisonInformation.WarehouseOperator.Length > 0)                                     // 签字
                {
                    id = "耗材仓库耗材入库单" + cWSL_ComparisonInformation.NumberOfPages;
                    TotalAmount = "金钱数一致";
                    Sign = "已签字";
                    Pass = "已通过";
                }
                else
                {
                    id = "耗材仓库耗材入库单" + cWSL_ComparisonInformation.NumberOfPages;
                    if (cWSL_ComparisonInformation.TotalAmount != cWSL_ComparisonInformationSource.TotalAmount)
                    {
                        TotalAmount = "金钱数不一致";
                    }
                    else { TotalAmount = "金钱一致"; }
                    // 签字
                    string QianZistr = "";
                    // 验收人
                    if (cWSL_ComparisonInformation.AcceptanceOfThePeople.Length <= 0)
                    {
                        QianZistr += "'验收人' ";
                    }
                    // 供应商
                    if (cWSL_ComparisonInformation.Supplier.Length <= 0)
                    {
                        QianZistr += "'供应商' ";
                    }
                    // 仓库员
                    if (cWSL_ComparisonInformation.WarehouseOperator.Length <= 0)
                    {
                        QianZistr += "'仓库员' ";
                    }
                    if (QianZistr.Length > 0)
                    {
                        QianZistr += "未签字";
                        Sign = QianZistr;
                    }
                    else { Sign = "已签字"; }
                    Pass = "未通过";
                }
            }
            #endregion
            #endregion
        }
        /// <summary>
        /// 耗材仓库配送出库单处理类
        /// </summary>
        /// <param name="TotalAmount"></param>
        /// <param name="Sign"></param>
        /// <param name="Pass"></param>
        public void CWDLList(out string id, out string TotalAmount, out string Sign, out string Seal, out string Pass)
        {
            #region 扫描到的信息-假
            // 扫描到的值-ComparisonInformation
            CWDL cWDL_ComparisonInformation = new CWDL();
            cWDL_ComparisonInformation.NameOfCollectingDepartment = "儿外泌外病房";  // 领用科室名称
            cWDL_ComparisonInformation.DataOfOutbound = "2020-06-10";                // 出库日期
            cWDL_ComparisonInformation.OutboundOrderNo = "952267";                   // 出库单号
            cWDL_ComparisonInformation.SerialNumber = "ZYHOUT2020061000568";         // 流水号

            cWDL_ComparisonInformation.NumberOfPages = "1/3";                        // 页码
            cWDL_ComparisonInformation.AmountOnThisPage = "30800.00";                // 本页合计
            cWDL_ComparisonInformation.TotalAmount = "30800.00";                     // 总金额

            cWDL_ComparisonInformation.Auditor = "魏洋洋";                           // 复核人
            cWDL_ComparisonInformation.Distributor = "张洋";                         // 配送人
            cWDL_ComparisonInformation.DepartmentConsignee = "王志东";               // 科室收货人
            cWDL_ComparisonInformation.DepartmentSeal = true;                        // 科室盖章
            #endregion

            #region 向服务器请求数据-假
            // 请求条件-略
            // 请求到的值-ComparisonInformationSource
            CWDL cWDL_ComparisonInformationSource = new CWDL();
            cWDL_ComparisonInformationSource = readJson.Readjson_CWDL();
            //System.Diagnostics.Debug.WriteLine(cWSL_ComparisonInformationSource.SupplierName.ToString());
            #endregion

            #region 对比
            // 表单总金额=JSON文件：表单总金额
            {
                if (1==1  &&                                                                                   // 各页金额之和 = 表单总金额
                    cWDL_ComparisonInformation.TotalAmount == cWDL_ComparisonInformationSource.TotalAmount &&  // 金钱数一致
                    cWDL_ComparisonInformation.Auditor.Length > 0 &&                                           // 签字
                    cWDL_ComparisonInformation.Distributor.Length > 0 &&                                       // 签字
                    cWDL_ComparisonInformation.DepartmentConsignee.Length > 0 &&                               // 签字
                    cWDL_ComparisonInformation.DepartmentSeal==true)                                           // 盖章
                {
                    id= "耗材仓库配送出库单 " + cWDL_ComparisonInformation.NumberOfPages;
                    TotalAmount = "金钱数一致";
                    Sign = "已签字";
                    Seal = "已盖章";
                    Pass = "已通过";
                }
                else
                {
                    id= "耗材仓库配送出库单 " + cWDL_ComparisonInformation.NumberOfPages;
                    // 各页金额之和 != 表单总金额
                    if (1 != 1)
                    { }
                    // 金钱数一致
                    if (cWDL_ComparisonInformation.TotalAmount != cWDL_ComparisonInformationSource.TotalAmount)
                    {
                        TotalAmount = "金钱数不一致";
                    }
                    else { TotalAmount = "金钱一致"; }
                    // 签字
                    string QianZistr = "";
                    // 复核人
                    if (cWDL_ComparisonInformation.Auditor.Length <= 0)
                    {
                        QianZistr += "'验收人' ";
                    }
                    // 配送人
                    if (cWDL_ComparisonInformation.Distributor.Length <= 0)
                    {
                        QianZistr += "'供应商' ";
                    }
                    // 科室收货人
                    if (cWDL_ComparisonInformation.Distributor.Length <= 0)
                    {
                        QianZistr += "'仓库员' ";
                    }
                    if (QianZistr.Length > 0)
                    {
                        QianZistr += "未签字";
                        Sign = QianZistr;
                    }
                    else { Sign = "已签字"; }
                    // 科室盖章
                    if (cWDL_ComparisonInformation.DepartmentSeal == false)
                    {
                        Seal = "未盖章";
                    }
                    else { Seal = "已盖章"; }
                    Pass = "未通过";
                }
            }
            #endregion
        }
    }
}
