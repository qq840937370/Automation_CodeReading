﻿using CodeReading.Entity.MainForm;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReading.View.BLL.HalconHelper
{
    public class HalconHelpers
    {
        UsedInfo usedInfoPub = new UsedInfo();
        #region 全局变量
        public string usedInfoDbId="";
        public string usedInfoOtherID = "";
        public string usedInfoSign = "";
        public string usedInfoTagCode = "";
        public HObject usedInfoHImg = null;
        public string usedInfoTagCodeNum = "";
        public int cameraFPS = 0;
        #endregion
        // 相机句柄
        HTuple hv_AcqHandle = null;
        HDevelopExport hDevelopExport = new HDevelopExport();
        /// <summary>
        /// 自动识图假方法
        /// </summary>
        /// <param name="rtaHalconWin"> halcon控件-实时影像</param>
        /// <param name="icsHalconWin"> halcon控件-处理结果</param>
        /// <param name="usedInfo"> 返回的信息类-UsedInfo </param>
        public void AutomaticMapRecognitionMethod(HTuple rtaHalconWin, HTuple icsHalconWin, out UsedInfo usedInfo1)
        {
            //Init
            HTuple hv_DecodedDataStrings = new HTuple(), hv_Exception = new HTuple();
            HTuple hv_WindowHandle = new HTuple(), hv_AcqHandle = new HTuple();
            hv_WindowHandle = icsHalconWin;
            // 返回值初始化
            #region 相机
            // 释放相机句柄
            HOperatorSet.CloseAllFramegrabbers();
            HObject ho_Image = null, ho_ImageRaw = null;
            HOperatorSet.GenEmptyObj(out ho_Image);
            #endregion
            //***
            //** DISPLAY
            //* DISPLAY INIT
            hDevelopExport.dev_update_off();
            //dev_close_window(...);
            //dev_open_window(...);

            //***
            //** LOOP
            //Image Acquisition 01: Code generated by Image Acquisition 01
            hv_AcqHandle.Dispose();
            HOperatorSet.OpenFramegrabber("GigEVision2", 0, 0, 0, 0, 0, 0, "progressive",
                -1, "default", -1, "false", "default", "c42f90f2b7fa_Hikvision_MVCE12010GM",
                0, -1, out hv_AcqHandle);
            while ((int)(1) != 0)
            {
                ho_Image.Dispose();

                HOperatorSet.GrabImage(out ho_Image, hv_AcqHandle);
                //HOperatorSet.GrabImageAsync(out ho_Image, hv_AcqHandle,500);

                cameraFPS += 1;

                //read_image (Image, 'C:/Users/zhang-sh/source/repos/qq840937370/Automation_CodeReading/file/1SHIL.bmp')
                try
                {
                    {
                        HObject ExpTmpOutVar_0;
                        hDevelopExport.image_cali_map(ho_Image, out ExpTmpOutVar_0, new HTuple(), new HTuple());
                        HOperatorSet.DispObj(ExpTmpOutVar_0, rtaHalconWin);
                        ho_Image.Dispose();
                        ho_Image = ExpTmpOutVar_0;
                    }
                    //dev_display (Image)

                    //***
                    //** Class
                    hv_DecodedDataStrings.Dispose();
                    hDevelopExport.image_class_mia(ho_Image, hv_WindowHandle, out hv_DecodedDataStrings);
                    // System.Diagnostics.Debug.WriteLine(hv_DecodedDataStrings.ToString());  //查看hv_DecodedDataStrings值

                    //*** Progress
                    //** 1SHIL
                    if ((int)(new HTuple(hv_DecodedDataStrings.TupleEqual("1SHIL"))) != 0)
                    {
                        hDevelopExport.image_prog_1SHIL(ho_Image, rtaHalconWin, hv_WindowHandle, out UsedInfo usedInfo);
                        usedInfoDbId = usedInfo.DbId;
                        usedInfoOtherID = usedInfo.OtherID;
                        usedInfoSign = usedInfo.Sign;
                        usedInfoTagCode = usedInfo.TagCode;
                        usedInfoHImg = usedInfo.HImg;
                        usedInfoTagCodeNum= usedInfo.TagCodeNum;
                    }
                    //** 2HNCL
                    else if ((int)(new HTuple(hv_DecodedDataStrings.TupleEqual("2HNCL"))) != 0)
                    {
                        hDevelopExport.image_prog_2HNCL(ho_Image, rtaHalconWin, hv_WindowHandle, out UsedInfo usedInfo);
                        usedInfoDbId = usedInfo.DbId;
                        usedInfoOtherID = usedInfo.OtherID;
                        usedInfoSign = usedInfo.Sign;
                        usedInfoTagCode = usedInfo.TagCode;
                        usedInfoHImg = usedInfo.HImg;
                        usedInfoTagCodeNum = usedInfo.TagCodeNum;
                    }
                    //** 3CWDL
                    
                    else if ((int)(new HTuple(hv_DecodedDataStrings.TupleEqual("3CWDL"))) != 0)
                    {
                        hDevelopExport.image_prog_3CWDL(ho_Image, rtaHalconWin, hv_WindowHandle, out UsedInfo usedInfo);
                        usedInfoDbId = usedInfo.DbId;
                        usedInfoOtherID = usedInfo.OtherID;
                        usedInfoSign = usedInfo.Sign;
                        usedInfoTagCode = usedInfo.TagCode;
                        usedInfoHImg = usedInfo.HImg;
                        usedInfoTagCodeNum = usedInfo.TagCodeNum;
                    }
                    //** 未识别出
                    else
                    {
                        hDevelopExport.image_prog_Null(ho_Image, rtaHalconWin, hv_WindowHandle);
                    }

                    //stop ()
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    System.Diagnostics.Debug.WriteLine("111111"+HDevExpDefaultException1.Message.ToString());
                }

            }
        }
    }
}
