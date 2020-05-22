using HalconDotNet;
using System;
using System.Drawing;

namespace CodeReading.View.SaveImage
{
    public class ImgHelper
    {
        /// <summary>
        /// 二进制图片转字符串
        /// </summary>
        /// <param name="holconImage"></param>
        /// <returns></returns>
        public string ImageToString(byte[] holconImage)
        {
            string hImageString = Convert.ToBase64String(holconImage);
            return hImageString;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ho_Image"></param>
        public void ImageToString(HObject ho_Image)
        {

        }
        #region 废弃
        public string SaveImg(string pictureName, Bitmap RawFormat)
        {
            // 设置默认保存目录

            try
            {
                //Bitmap bmp = new Bitmap(picBox1.Image);
                ////保存到磁盘文件
                //bmp.Save(@pictureName, PictureBox.Image.RawFormat);
                //bmp.Dispose();

                return "成功";
            }
            catch { return "失败"; }

        }
        #endregion
        /// <summary>
        /// 保存图片到本地
        /// </summary>
        /// <param name="pictureName">图片名字</param>
        /// <param name="RawFormat">图片</param>
        public void SaveImg(string pictureName, HObject ho_Image)
        {
            // 图片保存的路径
            string filename = "C:/Users/Public/"+ pictureName + ".bmp";
            // 保存图片到本地
            HOperatorSet.WriteImage(ho_Image, "bmp", 0, filename);
        }
        /// <summary>
        /// 保存图片到本地加数据库
        /// </summary>
        /// <param name="pictureName">图片名字</param>
        /// <param name="RawFormat">图片</param>
        public void SaveImgSaveData(string pictureName, HObject ho_Image)
        {
            // 图片保存的路径
            string filename = "C:/Users/Public/" + pictureName + ".bmp";
            // 保存图片到本地
            HOperatorSet.WriteImage(ho_Image, "bmp", 0, filename);

        }
    }
}
