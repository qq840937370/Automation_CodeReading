

using System;
using CodeReading.Entity;
using CodeReading.Entity.MainForm;
using CodeReading.View.DAL;
using CodeReading.View.SaveImage;

namespace CodeReading.View
{
    public class MainFormBLL
    {
        // MainFormDAL
        MainFormDAL mainFormDAL = new MainFormDAL();
        // ImgHelper
        ImgHelper imgHelper = new ImgHelper();
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
        public void CaptureImgbll(UsedInfo usedInfomain)
        {
            //SaveData.state = SaveDataState.saveDataTrue;

            // 保存图片
            imgHelper.SaveImg(usedInfomain.ScanDate, usedInfomain.HImg);

            // 保存数据
            mainFormDAL.SaveTemp(usedInfomain);
            //SaveData.state = SaveDataState.saveDataFalse;
        }

    }
}
