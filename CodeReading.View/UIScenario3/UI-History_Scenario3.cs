using CodeReading.Entity;
using CodeReading.Entity.History;
using CodeReading.View.DAL;
using CodeReading.View.HistoryServiceReference;
using HalconDotNet;
using System;
using System.Windows.Forms;

namespace CodeReading.View
{
    public partial class UI_History_Scenario3 : Form
    {
        #region 常量
        /// <summary>
        /// 检索结果
        /// </summary>
        public const string SearchResultsCount = "查询结果：{0}件";
        /// <summary>
        /// 全局图像类型变量
        /// </summary>
        HObject ho_Image;
        #endregion

        #region 成员变量
        /// <summary>
        /// 检索条件的DataBinding用SearchConditions
        /// </summary>
        private SearchConditions searchConditions = new SearchConditions();

        /// <summary>
        /// 数据列表显示用 数据表
        /// </summary>
        private HistoryDataSet.SearchListDataTable dtDetail = new HistoryDataSet.SearchListDataTable();

        /// <summary>
        /// 検索結果最大表示件数
        /// </summary>
        private int maxLowCount = 0;

        /// <summary>
        /// 服务器系统时间
        /// </summary>
        private DateTime systime ;
        #endregion

        # region 默认构造器
        public UI_History_Scenario3()
        {
            InitializeComponent();
        }
        #endregion

        #region private方法
        /// <summary>
        /// 登陆处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_History_Scenario3_Load(object sender, EventArgs e)
        {
            // 検索条件初始化
            InitData();
        }

        /// <summary>
        /// 検索条件初始化处理
        /// </summary>
        private void InitData()
        {
            // 検索条件初始化
            searchConditions = new SearchConditions();

            // 数据取得
            var client = new HistoryServiceClient();
            LoginInfo loginInfo=new LoginInfo();
            var result = client.Initialize(loginInfo);
            // 系统时间
            systime = result.SysDate;
            // 获取检索结果最大行数
            maxLowCount = result.MaxRowsCount;

            dtpDtp_From.Value = systime;
            dtpDtp_To.Value = systime;
            cmb_DbId.SelectedItem = cmb_DbId.Items[0];  // “表单类别”默认选中全部
            cmb_Sign.SelectedItem = cmb_Sign.Items[0];  // “有无签字”默认选中全部
            cmb_Pass.SelectedItem = cmb_Pass.Items[0];  // “是否通过”默认选中全部
        }

        /// <summary>
        /// 检索按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                // 鼠标指针变为等待
                Cursor.Current = Cursors.WaitCursor;

                // 错误检查
                if (!SearchErrorCheck())
                {
                    return;
                };

                // 设定检索条件
                SetSerarchConditions();

                // 获取数据
                //var client = new HistoryServiceClient();
                //var result = client.Search(searchConditions);
                HistoryDAL historyDAL = new HistoryDAL();
                var result = historyDAL.Search(searchConditions); 
                // 検索結果件数判定
                if (result.SearchData.Rows.Count == 0)
                {
                    MessageBox.Show(" 未检索到任何数据！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    // 清空数据显示列表
                    ClearGrid();
                    // 隐藏检索结果数目
                    lbl_ResultsCount.Text = "";
                    return;
                }
                else if (result.SearchData.Rows.Count > maxLowCount)
                {
                    MessageBox.Show(" 检索结果超过最大表示件数（100）请改变条件重新检索！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    // 清空数据显示列表
                    ClearGrid();
                    // 隐藏检索结果数目
                    lbl_ResultsCount.Text = "";
                    return;
                }

                // 检索结果赋给本类数据列表显示用 数据表
                dtDetail = result.SearchData;

                // 清空数据显示列表
                ClearGrid();
                // 绑定新数据
                detailBindingSource.DataSource = dtDetail;
                dgv_HistoryTable.DataSource= detailBindingSource.DataSource;
                detailBindingSource.ResetBindings(true);

                // 检索结果数目显示
                lbl_ResultsCount.Text = String.Format(SearchResultsCount, dtDetail.Count);

                // 焦点转移到数据表的第一行
                dgv_HistoryTable.Focus();
            }
            finally
            {
                // 鼠标指针恢复默认
                Cursor = Cursors.Default;
            }
        }
        
        /// <summary>
        /// 清空数据显示列表
        /// </summary>
        private void ClearGrid()
        {
            detailBindingSource.DataSource = new HistoryDataSet.SearchListDataTable();
            dgv_HistoryTable.DataSource=detailBindingSource;
            detailBindingSource.ResetBindings(true);
        }

        /// <summary>
        /// 画面检索条件的取得
        /// </summary>
        private void SetSerarchConditions()
        {
            searchConditions.HsDtpFrom =dtpDtp_From.Value.ToString("yyyyMMddHHmmssfff");     // 扫描开始时刻
            searchConditions.HsDtpTo = dtpDtp_To.Value.ToString("yyyyMMddHHmmssfff");        // 扫描结束时刻

            //searchConditions.HsDbId = cmb_DbId.SelectedItem.ToString();                      // 表单类型
            switch (cmb_DbId.SelectedItem.ToString())
            {
                case "全部":
                    searchConditions.HsDbId = "";                      // 表单类型
                    break;
                case "跟台人体植入物使用清单":
                    searchConditions.HsDbId = "1SHIL";                 // 表单类型
                    break;
                case "高净值耗材使用清单":
                    searchConditions.HsDbId = "2HNCL";                 // 表单类型
                    break;
                case "耗材仓库配送出库单":
                    searchConditions.HsDbId = "3CWDL";                 // 表单类型
                    break;
            }
            searchConditions.HsOtherID = txt_HospitalizationNum.Text.ToString();             // 模拟主键
            // 签名确认
            switch (cmb_Sign.SelectedItem.ToString())
            {
                case "全部":
                    searchConditions.HsSigned = "";                // 全部
                    break;
                case "已签字":
                    searchConditions.HsSigned = "1";               // 已签字
                    break;
                case "未签字":
                    searchConditions.HsSigned = "0";               // 未签字
                    break;
            }
            // 是否通过
            switch (cmb_Pass.SelectedItem.ToString())
            {
                case "全部":
                    searchConditions.HsPass = "";                // 全部
                    break;
                case "通过":
                    searchConditions.HsPass = "1";               // 通过
                    break;
                case "未通过":
                    searchConditions.HsPass = "0";               // 未通过
                    break;
            }
            searchConditions.HsOther1 = txt_Other1.Text.ToString();                         // 模拟查询条件1
            searchConditions.HsOther2 = txt_Other2.Text.ToString();                         // 模拟查询条件2
        }

        /// <summary>
        /// 错误检查
        /// </summary>
        /// <returns>检测通过为true</returns>
        private bool SearchErrorCheck()
        {
            // 返回值
            bool ret = true;

            // 扫描开始时刻 or 扫描结束时刻 为空
            if (string.IsNullOrEmpty(dtpDtp_From.Text.ToString())||string.IsNullOrEmpty(dtpDtp_To.Text.ToString()))
            {
                MessageBox.Show("扫描开始时刻 or 扫描结束时刻 不可为空！", "提示", MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                ret = false;
            }
            // 扫描开始时刻 > 扫描结束时刻
            if (dtpDtp_From.Value.Date > dtpDtp_To.Value.Date)
            {
                MessageBox.Show("扫描开始时刻 不可大于 扫描结束时刻！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                ret = false;
            }
            return ret;
        }
        #endregion

        /// <summary>
        /// 焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_History_Scenario3_Activated(object sender, EventArgs e)
        {
            // 焦点在"检索"按钮
            btn_Search.Focus();
        }
        /// <summary>
        /// 单击单元格任意位置时，显示图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_HistoryTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 选中列头时，RowIndex是-1
            if (e.RowIndex > -1)
            {
                string SelectedCells = dgv_HistoryTable.Rows[e.RowIndex].Cells["FileName"].Value.ToString();
                try
                {
                    lbl_ShowimgIS.Visible = false;        // 初始化提示信息状态
                    #region 初始化图像变量
                    HOperatorSet.GenEmptyObj(out ho_Image);              // 初始化 图像类型变量
                    ho_Image.Dispose();                                  // 图像类型变量资源清空
                    HOperatorSet.ReadImage(out ho_Image, "C:/Users/Public/" + SelectedCells);    // 读入图像文件  readimage目录 C:\Users\Public\Documents\MVTec\HALCON - 18.11 - Steady\examples\images
                    #endregion

                    // 显示图像
                    hWinctl_HistoryBMP.HalconWindow.DispObj(ho_Image);
                    ho_Image.Dispose();
                }
                // HalconDotNet.HOperatorException
                catch (HOperatorException)
                {
                    lbl_ShowimgIS.Visible = true;         // 显示提示信息
                }
            }
        }
    }
}
