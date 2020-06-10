//
// File generated by HDevelop for HALCON/.NET (C#) Version 18.11.1.1
// Non-ASCII strings in this file are encoded in UTF-8.
// 
// Please note that non-ASCII characters in string constants are exported
// as octal codes in order to guarantee that the strings are correctly
// created on all systems, independent on any compiler settings.
// 
// Source files with different encoding should not be mixed in one project.
//


using System;
using CodeReading.Entity.MainForm;
using HalconDotNet;

public partial class HDevelopExport
{
  public void image_prog_2HNCL (HObject ho_Image, HTuple rtaHalconWin, HTuple hv_ExpDefaultWinHandle, out UsedInfo usedInfo)
    {
    // Local iconic variables 

    HObject ho_ImageOut=null, ho_SymbolXLDs, ho_SymbolRegions;
    HObject ho_ObjectSelected=null;

    // Local control variables 

    HTuple hv_BarWidth = new HTuple(), hv_BarHeight = new HTuple();
    HTuple hv_DataCodeHandle = new HTuple(), hv_BarCodeHandle = new HTuple();
    HTuple hv_ResultHandles = new HTuple(), hv_DecodedDataStrings = new HTuple();
    HTuple  hv_DecodedDataStrings2D = new HTuple();
    HTuple hv_someitem = new HTuple(), hv_Area = new HTuple();
    HTuple hv_BarIndex = new HTuple(), hv_Row = new HTuple();
    HTuple hv_Column = new HTuple();
    // Initialize local and output iconic variables 
    HOperatorSet.GenEmptyObj(out ho_ImageOut);
    HOperatorSet.GenEmptyObj(out ho_SymbolXLDs);
    HOperatorSet.GenEmptyObj(out ho_SymbolRegions);
    HOperatorSet.GenEmptyObj(out ho_ObjectSelected);
    ho_ImageOut.Dispose();
    ho_ImageOut = new HObject(ho_Image);
    //***
    //** INIT
    //* INIT CONST
    hv_BarWidth.Dispose();
    hv_BarWidth = 800;
    hv_BarHeight.Dispose();
    hv_BarHeight = 100;
    //* INIT IMAGE
    //* INIT DATACODE
    hv_DataCodeHandle.Dispose();
    HOperatorSet.CreateDataCode2dModel("QR Code", new HTuple(), new HTuple(), out hv_DataCodeHandle);

    //* INIT BARCODE
    hv_BarCodeHandle.Dispose();
    HOperatorSet.CreateBarCodeModel(new HTuple(), new HTuple(), out hv_BarCodeHandle);
    HOperatorSet.SetBarCodeParam(hv_BarCodeHandle, "quiet_zone", "true");
        //* INIT LOC
        //* Info:
        //read_shape_model ('C:/Users/zhang-sh/source/repos/qq840937370/Automation_CodeReading/file/InvV1CaliInfo.shm', InfoModel)
        //get_shape_model_contours (InfoModelContours, InfoModel, 1)
        //* Sign
        //read_shape_model ('C:/Users/zhang-sh/source/repos/qq840937370/Automation_CodeReading/file/InvV1CaliSign.shm', SignModel)
        //get_shape_model_contours (SignModelContours, SignModel, 1)
        //** PRE
        //find_shape_model (ImageOut, SignModel, rad(0), rad(360), 0.3, 1, 0.5, 'least_squares', [7,1], 0.6, InfoRow, InfoColumn, InfoAngle, InfoScore)
        //rotate_image (ImageOut, ImageOut, deg(-InfoAngle), 'constant')
        // HOperatorSet.DispObj(ho_ImageOut, rtaHalconWin);
        HOperatorSet.DispObj(ho_ImageOut, hv_ExpDefaultWinHandle);
    //** RECOGNITION
    //* DataCode
    ho_SymbolXLDs.Dispose();hv_ResultHandles.Dispose();hv_DecodedDataStrings.Dispose();hv_DecodedDataStrings2D.Dispose();
    HOperatorSet.FindDataCode2d(ho_ImageOut, out ho_SymbolXLDs, hv_DataCodeHandle, 
        "stop_after_result_num", 3, out hv_ResultHandles, out hv_DecodedDataStrings2D);
    image_display_datacode(ho_SymbolXLDs, hv_ResultHandles, hv_ExpDefaultWinHandle, hv_DecodedDataStrings2D, 
        hv_DataCodeHandle);
        

    //* BARCODE
    ho_SymbolRegions.Dispose();hv_DecodedDataStrings.Dispose();hv_someitem.Dispose();
    image_get_bar(ho_ImageOut, out ho_SymbolRegions, hv_BarCodeHandle, out hv_DecodedDataStrings, 
        out hv_someitem);
    //* LOC
    //* Info:
    //find_shape_model (ImageOut, InfoModel, rad(0), rad(360), 0.3, 1, 0.5, 'least_squares', [7,1], 0.7, InfoRow, InfoColumn, InfoAngle, InfoScore)
    //* HaedSign
    //find_shape_model (ImageOut, SignModel, rad(0), rad(360), 0.3, 1, 0.5, 'least_squares', [7,1], 0.7, SignRow, SignColumn, SignAngle, SignScore)
    //* Ocr
    //gen_rectangle2 (ROI_OCR_01_0, InfoRow + 70, InfoColumn - 700, InfoAngle, 100, 30)
    //region_ocr_num_svm (ImageOut, ROI_OCR_01_0, [], [], SymbolNames_OCR_01_0, Ocr_Split)
    //area_center (ROI_OCR_01_0, Area, IDRow, IDColumn)
    //smallest_rectangle1 (ROI_OCR_01_0, IDRow1, IDColumn1, IDRow2, IDColumn2)
    //height_width_ratio (ROI_OCR_01_0, IDHeight, IDWidth, IDRatio)
    //* Sign
    //HeadSignScale := 1
    //HeadSignRow := SignRow
    //HeadSignCol := SignColumn
    //HeadPhi := SignAngle
    //region_judge_sign (ImageOut, EDGE, HeadSignScale, HeadSignRow, HeadSignCol, HeadPhi, WindowHandle, sign)
    //** DISPLAY
    //* DISPLAY BARCODE
    set_display_font(hv_ExpDefaultWinHandle, 14, "mono", "true", "false");
    HOperatorSet.SetDraw(hv_ExpDefaultWinHandle, "margin");
    HOperatorSet.SetLineWidth(hv_ExpDefaultWinHandle, 3);
    HOperatorSet.SetColor(hv_ExpDefaultWinHandle, "forest green");
    HOperatorSet.DispObj(ho_SymbolRegions, hv_ExpDefaultWinHandle);
    for (hv_BarIndex=1; (int)hv_BarIndex<=(int)(new HTuple(hv_DecodedDataStrings.TupleLength()
        )); hv_BarIndex = (int)hv_BarIndex + 1)
    {
      ho_ObjectSelected.Dispose();
      HOperatorSet.SelectObj(ho_SymbolRegions, out ho_ObjectSelected, hv_BarIndex);
      hv_Area.Dispose();hv_Row.Dispose();hv_Column.Dispose();
      HOperatorSet.AreaCenter(ho_ObjectSelected, out hv_Area, out hv_Row, out hv_Column);
      using (HDevDisposeHelper dh = new HDevDisposeHelper())
      {
      HOperatorSet.SetTposition(hv_ExpDefaultWinHandle, hv_Row-hv_BarHeight, hv_Column-(0.25*hv_BarWidth));
      }
      using (HDevDisposeHelper dh = new HDevDisposeHelper())
      {
      HOperatorSet.WriteString(hv_ExpDefaultWinHandle, hv_DecodedDataStrings.TupleSelect(
          hv_BarIndex-1));
      }
    }
    //* DISPLAY LOC
    HOperatorSet.SetLineWidth(hv_ExpDefaultWinHandle, 1);
        //* Info:
        //hom_mat2d_identity (InfoHomMat2D)
        //hom_mat2d_rotate (InfoHomMat2D, InfoAngle, 0, 0, InfoHomMat2D)
        //hom_mat2d_translate (InfoHomMat2D, InfoRow, InfoColumn, InfoHomMat2D)
        //affine_trans_contour_xld (InfoModelContours, InfoTransContours, InfoHomMat2D)
        //dev_set_color ('green')
        //dev_display (InfoTransContours)
        //* Ocr
        //dev_disp_text (Ocr_Split, 'image', IDRow1 + IDHeight, IDColumn1, 'blue', [], [])
        //* HeadSign
        //hom_mat2d_identity (SignHomMat2D)
        //hom_mat2d_rotate (SignHomMat2D, SignAngle, 0, 0, SignHomMat2D)
        //hom_mat2d_translate (SignHomMat2D, SignRow, SignColumn, SignHomMat2D)
        //affine_trans_contour_xld (SignModelContours, SignTransContours, SignHomMat2D)
        //dev_set_color ('green')
        //dev_display (SignTransContours)
        //* Sign
        //dev_set_colored (12)
        //dev_display (EDGE)
        //dump_window_image (ImageResult, WindowHandle)

        //stop ()

        {
            HOperatorSet.DumpWindowImage(out HObject miaResult, hv_ExpDefaultWinHandle);
            var result = new UsedInfo();
            // 表单类型
            result.DbId = "2HNCL";
            ////result.OtherID = "6527815";//
            // 模拟主键
            result.OtherID = hv_DecodedDataStrings2D.TupleSubstr(0,6);
            //System.Diagnostics.Debug.WriteLine("result： " + hv_DecodedDataStrings2D.TupleSubstr(0, 6));
            //System.Diagnostics.Debug.WriteLine("result： " + result.OtherID);
            //result.OtherID = hv_Ocr_Split;
            // 签字
            result.Sign = "1";
            //if (hv_sign[0] * hv_sign[1] * hv_sign[2] * hv_sign[3] == 1)
            //{
            //    result.Sign = "1";
            //}
            //else
            //{
            //    result.Sign = "0";
            //}
            //result.Sign = hv_sign;
            // 条形码
            int TagCodeNum = 0;
            result.TagCode = "";
            for (; TagCodeNum < hv_DecodedDataStrings.Length; TagCodeNum++)
            {
                result.TagCode += hv_DecodedDataStrings[TagCodeNum].S + ",";
            }
            // 条形码数
            result.TagCodeNum = TagCodeNum.ToString();
            // 图片
            result.HImg = miaResult;
            usedInfo = result;
        }
        ho_ImageOut.Dispose();
    ho_SymbolXLDs.Dispose();
    ho_SymbolRegions.Dispose();
    ho_ObjectSelected.Dispose();

    hv_BarWidth.Dispose();
    hv_BarHeight.Dispose();
    hv_DataCodeHandle.Dispose();
    hv_BarCodeHandle.Dispose();
    hv_ResultHandles.Dispose();
    hv_DecodedDataStrings.Dispose();
    hv_someitem.Dispose();
    hv_Area.Dispose();
    hv_BarIndex.Dispose();
    hv_Row.Dispose();
    hv_Column.Dispose();

    return;
  }

}
