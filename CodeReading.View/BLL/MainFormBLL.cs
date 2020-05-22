

using System;
using CodeReading.Entity;
using CodeReading.View.DAL;

namespace CodeReading.View
{
    public class MainFormBLL
    {
        MainFormDAL mainFormDAL = new MainFormDAL();

        /// <summary>
        /// 自动捕捉bll
        /// </summary>
        /// <param name="imgAutoState"></param>
        /// <returns></returns>
        public bool ImgAutobll(bool imgAutoState)
        {
            if (imgAutoState == true)
            {
                ImgAuto.state = ImgAutoState.imgAutoFalse;
                return false;
            }
            else
            {
                ImgAuto.state = ImgAutoState.imgAutoTrue;
                return true;
            }
        }

        /// <summary>
        /// 抓取图片保存数据bll
        /// </summary>
        /// <returns></returns>
        public int CaptureImgbll()
        {
            try
            {
                SaveData.state = SaveDataState.saveDataTrue;
                return 1;
            }
            catch { return 0; }
        }

    }
}
