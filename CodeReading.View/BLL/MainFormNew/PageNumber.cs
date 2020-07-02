/*-------------------------------------------------------------------------------
* 系统名称  ：工业自动化系统
* 子系统名称：工业相机识码子系统
* 功能模块名：工业相机识码主页
* 类名      ：PageNumber
* 概要      ：页码处理类
* 
* 改版履历
* Ver----------日期---------单位・姓名--------------------概要------------------
* 1.0.0.0      2020/05/25   Shandong_HuaShi ZhangSh       新建
* 
* ------------------------------------------------------------------------------
*/
using System;
namespace CodeReading.View.BLL.MainFormNew
{
    /// <summary>
    /// 页码处理类
    /// </summary>
    public class PageNumber
    {
        /// <summary>
        /// 页码截取处理
        /// </summary>
        /// <param name="Page">原值</param>
        /// <param name="NumberOfPage">当前页值</param>
        /// <param name="NumberOfPages">总页值</param>
        public void PageNumberProcessing(string Page,out int NumberOfPage, out int NumberOfPages)
        {
            Page = "1/3";
            string[] PageList = Page.Split('/');

            NumberOfPage =Convert.ToInt32( PageList[0]);
            NumberOfPages = Convert.ToInt32( PageList[1]);
            //System.Diagnostics.Debug.WriteLine("当前页值" + NumberOfPage+ "总页值" + NumberOfPages);
        }

        /// <summary>
        /// 入库表页码扫描顺序使用变量
        /// </summary>
        int numberOfPageold=0;

        /// <summary>
        /// 页码扫描顺序
        /// </summary>
        /// <param name="i">是否读取过</param>
        /// <param name="numberOfPage">当前页数</param>
        /// <param name="numberOfPages">总页数</param>
        /// <param name="numberOfPageshow">请放入第" + numberOfPageshow + "页</param>
        /// <returns>0-读取并初始一些数据变量，1-读取，2-请放入第" + numberOfPageshow + "页，3-请从第1/" + numberOfPages + "页开始读取</returns>
        public int PageOrder(int i, int numberOfPage, int numberOfPages,out int numberOfPageshow)
        {
            // 表单（供应商，入库单号，入库日期）未读过 
            if (i == 0)
            {
                if (numberOfPage == 1)
                {
                    numberOfPageold = numberOfPage;
                    numberOfPageshow = 0;  // 无用
                    // 读取
                    return 1;
                    
                }
                else
                {
                    numberOfPageshow = 0;  // 无用
                    return 3;
                    //System.Diagnostics.Debug.WriteLine("请从第1/" + numberOfPages + "页开始读取。");
                }
            }
            // 表单读过
            else
            {
                // 是要读取的下一页
                if (numberOfPage == numberOfPageold + 1)
                {
                    numberOfPageold = numberOfPage;
                    numberOfPageshow = 0;  // 无用
                    // 读取
                    return 1;
                }
                // 是最后一页
                else if (numberOfPage == numberOfPages)
                {

                    numberOfPageshow = 0;  // 无用
                    // 读取并初始一些数据变量
                    return 0;
                }
                // 其他情况
                else
                {
                    numberOfPageshow = numberOfPageold + 1;
                    return 2;
                    //System.Diagnostics.Debug.WriteLine("请放入第" + numberOfPageshow + "页。");
                }
            }
        }
    }
}
