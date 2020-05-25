using CodeReading.Entity;
using CodeReading.Entity.History;
using CodeReading.View.DAL;
using CodeReading.View.HistoryServiceReference;
using System;
using System.Windows.Forms;

namespace CodeReading.View
{
    public partial class UI_History_Scenario2 : Form
    {
        #region 常量
        /// <summary>
        /// 检索结果
        /// </summary>
        public const string SearchResultsCount = "检索结果：{0}件";
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
        public UI_History_Scenario2()
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
        private void UI_History_Scenario2_Load(object sender, EventArgs e)
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
            // 
            systime = result.SysDate;
            // 获取检索结果最大行数
            maxLowCount = result.MaxRowsCount;

            // 测试
            label6.Text = "当前时间Test"+systime.ToLongTimeString();
            label7.Text = "最大结果数Test" + maxLowCount.ToString();
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

                // 检索结果表示
                dtDetail = result.SearchData;

                // 清空数据显示列表
                ClearGrid();

                // 绑定新数据
                detailBindingSource.DataSource = dtDetail;
                dgv_Historys.DataSource = detailBindingSource;
                // 检索结果数目显示
                lbl_ResultsCount.Text = String.Format(SearchResultsCount, dtDetail.Count);

                // 设定dgv_Historys的ReadOnly

                // 焦点转移到数据表的第一行
                dgv_Historys.Focus();
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
            dgv_Historys.DataSource=detailBindingSource;
            detailBindingSource.ResetBindings(true);
        }

        /// <summary>
        /// 画面检索条件的取得
        /// </summary>
        private void SetSerarchConditions()
        {
            searchConditions.KojoCd ="医院编号1";                                           // 工厂
            searchConditions.HospitalizationNumber =txt_HospitalNo.Text.ToString();         // 住院号
            searchConditions.DtpFrom = dtpDtp_From.Value.ToString("yyyyMMddHHmmssfff");     // 扫描开始时刻
            searchConditions.DtpTo = dtpDtp_To.Value.ToString("yyyyMMddHHmmssfff");         // 扫描结束时刻
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
        private void UI_History_Scenario2_Activated(object sender, EventArgs e)
        {
            // 焦点在"检索"按钮
            btn_Search.Focus();
        }
    }
}
