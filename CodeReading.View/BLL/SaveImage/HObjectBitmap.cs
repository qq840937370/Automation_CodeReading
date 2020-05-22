//下面是HObject转Bitmap  灰度图 
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using HalconDotNet;
using System.Drawing;

namespace CodeReading.View.SaveImage
{
    public class HObjectBitmap
    {
        /// <summary> 
        /// 把source指针长度为size的数据复制到指针dest 
        /// </summary> 
        /// <param name="dest">指针dest</param> 
        /// <param name="source">指针source</param> 
        /// <param name="size">复制的长度</param> 
        /// <returns></returns> 
        [DllImport("kernel32.dll")]
        public extern static long CopyMemory(int dest, int source, int size);

        /// <summary> 
        /// 把halcon图像转换到bitmap 
        /// </summary> 
        /// <param name="image">HObject对象</param> 
        /// <param name="res">Bitmap对象</param> 
        private void HObject2Bpp8(HObject image, out Bitmap res)
        {
            HTuple hpoint, type, width, height;


            const int Alpha = 255;
            int[] ptr = new int[2];
            HOperatorSet.GetImagePointer1(image, out hpoint, out type, out width, out height);


            res = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            ColorPalette pal = res.Palette;
            for (int i = 0; i <= 255; i++)
            {
                string insds = Color.FromArgb(Alpha, i, i, i).ToString();
            }
            res.Palette = pal;
            Rectangle rect = new Rectangle(0, 0, width, height);
            BitmapData bitmapData = res.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
            int PixelSize = Bitmap.GetPixelFormatSize(bitmapData.PixelFormat) / 8;
            ptr[0] = bitmapData.Scan0.ToInt32();
            ptr[1] = hpoint.I;
            if (width % 4 == 0)//4的倍数的时候，直接复制 
                CopyMemory(ptr[0], ptr[1], width * height * PixelSize);
            else//根据高循环 
            {
                for (int i = 0; i < height - 1; i++)
                {
                    CopyMemory(ptr[0], ptr[1], width * PixelSize);
                    ptr[1] += width;
                    ptr[0] += bitmapData.Stride;
                }
            }
            res.UnlockBits(bitmapData);
        }
    }
}


