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
  public void image_prog_3CWDL (HObject ho_Image, HTuple rtaHalconWin, HTuple hv_ExpDefaultWinHandle, out UsedInfo usedInfo)
    {

    // Stack for temporary objects 
    HObject[] OTemp = new HObject[20];

    // Local iconic variables 

    HObject ho_ImageOut=null, ho_SignModelContours;
    HObject ho_SymbolRegions, ho_ROI_OCR_01_0, ho_EDGE, ho_ObjectSelected=null;
    HObject ho_SignTransContours;

    // Local control variables 

    HTuple hv_BarWidth = new HTuple(), hv_BarHeight = new HTuple();
    HTuple hv_BarCodeHandle = new HTuple(), hv_SignModel = new HTuple();
    HTuple hv_InfoRow = new HTuple(), hv_InfoColumn = new HTuple();
    HTuple hv_InfoAngle = new HTuple(), hv_InfoScore = new HTuple();
    HTuple hv_DecodedDataStrings = new HTuple(), hv_someitem = new HTuple();
    HTuple hv_SignRow = new HTuple(), hv_SignColumn = new HTuple();
    HTuple hv_SignAngle = new HTuple(), hv_SignScore = new HTuple();
    HTuple hv_SymbolNames_OCR_01_0 = new HTuple(), hv_Ocr_Split = new HTuple();
    HTuple hv_Area = new HTuple(), hv_IDRow = new HTuple();
    HTuple hv_IDColumn = new HTuple(), hv_IDRow1 = new HTuple();
    HTuple hv_IDColumn1 = new HTuple(), hv_IDRow2 = new HTuple();
    HTuple hv_IDColumn2 = new HTuple(), hv_IDHeight = new HTuple();
    HTuple hv_IDWidth = new HTuple(), hv_IDRatio = new HTuple();
    HTuple hv_HeadSignScale = new HTuple(), hv_HeadSignRow = new HTuple();
    HTuple hv_HeadSignCol = new HTuple(), hv_HeadPhi = new HTuple();
    HTuple hv_sign = new HTuple(), hv_BarIndex = new HTuple();
    HTuple hv_Row = new HTuple(), hv_Column = new HTuple();
    HTuple hv_SignHomMat2D = new HTuple();
    // Initialize local and output iconic variables 
    HOperatorSet.GenEmptyObj(out ho_ImageOut);
    HOperatorSet.GenEmptyObj(out ho_SignModelContours);
    HOperatorSet.GenEmptyObj(out ho_SymbolRegions);
    HOperatorSet.GenEmptyObj(out ho_ROI_OCR_01_0);
    HOperatorSet.GenEmptyObj(out ho_EDGE);
    HOperatorSet.GenEmptyObj(out ho_ObjectSelected);
    HOperatorSet.GenEmptyObj(out ho_SignTransContours);
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

    //* INIT BARCODE
    hv_BarCodeHandle.Dispose();
    HOperatorSet.CreateBarCodeModel(new HTuple(), new HTuple(), out hv_BarCodeHandle);
    HOperatorSet.SetBarCodeParam(hv_BarCodeHandle, "quiet_zone", "true");
    //* INIT LOC
    //* Info:
    //read_shape_model ('C:/Users/zhang-sh/source/repos/qq840937370/Automation_CodeReading/file/InvV1CaliInfo.shm', InfoModel)
    //get_shape_model_contours (InfoModelContours, InfoModel, 1)
    //* Sign
    hv_SignModel.Dispose();
    HOperatorSet.ReadShapeModel("C:/Users/zhang-sh/source/repos/qq840937370/Automation_CodeReading/file/SignV3.shm", 
        out hv_SignModel);
    ho_SignModelContours.Dispose();
    HOperatorSet.GetShapeModelContours(out ho_SignModelContours, hv_SignModel, 1);
    //** PRE
    using (HDevDisposeHelper dh = new HDevDisposeHelper())
    {
    hv_InfoRow.Dispose();hv_InfoColumn.Dispose();hv_InfoAngle.Dispose();hv_InfoScore.Dispose();
    HOperatorSet.FindShapeModel(ho_ImageOut, hv_SignModel, (new HTuple(0)).TupleRad()
        , (new HTuple(360)).TupleRad(), 0.3, 1, 0.5, "least_squares", (new HTuple(7)).TupleConcat(
        1), 0.6, out hv_InfoRow, out hv_InfoColumn, out hv_InfoAngle, out hv_InfoScore);
    }
    using (HDevDisposeHelper dh = new HDevDisposeHelper())
    {
    HObject ExpTmpOutVar_0;
    HOperatorSet.RotateImage(ho_ImageOut, out ExpTmpOutVar_0, ((-hv_InfoAngle)).TupleDeg()
        , "constant");
    ho_ImageOut.Dispose();
    ho_ImageOut = ExpTmpOutVar_0;
    }
        HOperatorSet.DispObj(ho_ImageOut, rtaHalconWin);
        HOperatorSet.DispObj(ho_ImageOut, hv_ExpDefaultWinHandle);
    //** RECOGNITION
    //* BARCODE
    ho_SymbolRegions.Dispose();hv_DecodedDataStrings.Dispose();hv_someitem.Dispose();
    image_get_bar(ho_ImageOut, out ho_SymbolRegions, hv_BarCodeHandle, out hv_DecodedDataStrings, 
        out hv_someitem);
    //* LOC
    //* Info:
    //find_shape_model (ImageOut, InfoModel, rad(0), rad(360), 0.3, 1, 0.5, 'least_squares', [7,1], 0.7, InfoRow, InfoColumn, InfoAngle, InfoScore)
    //* HaedSign
    using (HDevDisposeHelper dh = new HDevDisposeHelper())
    {
    hv_SignRow.Dispose();hv_SignColumn.Dispose();hv_SignAngle.Dispose();hv_SignScore.Dispose();
    HOperatorSet.FindShapeModel(ho_ImageOut, hv_SignModel, (new HTuple(0)).TupleRad()
        , (new HTuple(360)).TupleRad(), 0.3, 1, 0.5, "least_squares", (new HTuple(7)).TupleConcat(
        1), 0.7, out hv_SignRow, out hv_SignColumn, out hv_SignAngle, out hv_SignScore);
    }
    //* Ocr
    using (HDevDisposeHelper dh = new HDevDisposeHelper())
    {
    ho_ROI_OCR_01_0.Dispose();
    HOperatorSet.GenRectangle2(out ho_ROI_OCR_01_0, hv_InfoRow+70, hv_InfoColumn-700, 
        hv_InfoAngle, 100, 30);
    }
    hv_SymbolNames_OCR_01_0.Dispose();hv_Ocr_Split.Dispose();
    region_ocr_num_svm(ho_ImageOut, ho_ROI_OCR_01_0, new HTuple(), new HTuple(), 
        out hv_SymbolNames_OCR_01_0, out hv_Ocr_Split);
    hv_Area.Dispose();hv_IDRow.Dispose();hv_IDColumn.Dispose();
    HOperatorSet.AreaCenter(ho_ROI_OCR_01_0, out hv_Area, out hv_IDRow, out hv_IDColumn);
    hv_IDRow1.Dispose();hv_IDColumn1.Dispose();hv_IDRow2.Dispose();hv_IDColumn2.Dispose();
    HOperatorSet.SmallestRectangle1(ho_ROI_OCR_01_0, out hv_IDRow1, out hv_IDColumn1, 
        out hv_IDRow2, out hv_IDColumn2);
    hv_IDHeight.Dispose();hv_IDWidth.Dispose();hv_IDRatio.Dispose();
    HOperatorSet.HeightWidthRatio(ho_ROI_OCR_01_0, out hv_IDHeight, out hv_IDWidth, 
        out hv_IDRatio);
    //* Sign
    hv_HeadSignScale.Dispose();
    hv_HeadSignScale = 1;
    hv_HeadSignRow.Dispose();
    hv_HeadSignRow = new HTuple(hv_SignRow);
    hv_HeadSignCol.Dispose();
    hv_HeadSignCol = new HTuple(hv_SignColumn);
    hv_HeadPhi.Dispose();
    hv_HeadPhi = new HTuple(hv_SignAngle);
    ho_EDGE.Dispose();hv_sign.Dispose();
    region_judge_sign(ho_ImageOut, out ho_EDGE, hv_HeadSignScale, hv_HeadSignRow, 
        hv_HeadSignCol, hv_HeadPhi, hv_ExpDefaultWinHandle, out hv_sign);
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
    hv_SignHomMat2D.Dispose();
    HOperatorSet.HomMat2dIdentity(out hv_SignHomMat2D);
    {
    HTuple ExpTmpOutVar_0;
    HOperatorSet.HomMat2dRotate(hv_SignHomMat2D, hv_SignAngle, 0, 0, out ExpTmpOutVar_0);
    hv_SignHomMat2D.Dispose();
    hv_SignHomMat2D = ExpTmpOutVar_0;
    }
    {
    HTuple ExpTmpOutVar_0;
    HOperatorSet.HomMat2dTranslate(hv_SignHomMat2D, hv_SignRow, hv_SignColumn, out ExpTmpOutVar_0);
    hv_SignHomMat2D.Dispose();
    hv_SignHomMat2D = ExpTmpOutVar_0;
    }
    ho_SignTransContours.Dispose();
    HOperatorSet.AffineTransContourXld(ho_SignModelContours, out ho_SignTransContours, 
        hv_SignHomMat2D);
    HOperatorSet.SetColor(hv_ExpDefaultWinHandle, "green");
    HOperatorSet.DispObj(ho_SignTransContours, hv_ExpDefaultWinHandle);
    //* Sign
    HOperatorSet.SetColored(hv_ExpDefaultWinHandle, 12);
    HOperatorSet.DispObj(ho_EDGE, hv_ExpDefaultWinHandle);
        //dump_window_image (ImageResult, WindowHandle)

        //stop ()

        {
            HOperatorSet.DumpWindowImage(out HObject miaResult, hv_ExpDefaultWinHandle);
            var result = new UsedInfo();
            result.DbId = "3CWDL";
            //result.OtherID = "6527815";
            result.OtherID = hv_DecodedDataStrings;
            //result.Sign = "1";
            //result.Sign = hv_sign;
            if (hv_sign[0] * hv_sign[1] * hv_sign[2] * hv_sign[3] == 1)
            {
                result.Sign = "1";
            }
            else
            {
                result.Sign = "0";
            }
            //result.TagCode = "110112572371,110112572370,110112572373,110112572375,110112572374,110112572368,110112572369,110112572367,110112572372,";
            result.TagCode = hv_DecodedDataStrings;
            result.HImg = miaResult;
            usedInfo = result;
        }
        ho_ImageOut.Dispose();
    ho_SignModelContours.Dispose();
    ho_SymbolRegions.Dispose();
    ho_ROI_OCR_01_0.Dispose();
    ho_EDGE.Dispose();
    ho_ObjectSelected.Dispose();
    ho_SignTransContours.Dispose();

    hv_BarWidth.Dispose();
    hv_BarHeight.Dispose();
    hv_BarCodeHandle.Dispose();
    hv_SignModel.Dispose();
    hv_InfoRow.Dispose();
    hv_InfoColumn.Dispose();
    hv_InfoAngle.Dispose();
    hv_InfoScore.Dispose();
    hv_DecodedDataStrings.Dispose();
    hv_someitem.Dispose();
    hv_SignRow.Dispose();
    hv_SignColumn.Dispose();
    hv_SignAngle.Dispose();
    hv_SignScore.Dispose();
    hv_SymbolNames_OCR_01_0.Dispose();
    hv_Ocr_Split.Dispose();
    hv_Area.Dispose();
    hv_IDRow.Dispose();
    hv_IDColumn.Dispose();
    hv_IDRow1.Dispose();
    hv_IDColumn1.Dispose();
    hv_IDRow2.Dispose();
    hv_IDColumn2.Dispose();
    hv_IDHeight.Dispose();
    hv_IDWidth.Dispose();
    hv_IDRatio.Dispose();
    hv_HeadSignScale.Dispose();
    hv_HeadSignRow.Dispose();
    hv_HeadSignCol.Dispose();
    hv_HeadPhi.Dispose();
    hv_sign.Dispose();
    hv_BarIndex.Dispose();
    hv_Row.Dispose();
    hv_Column.Dispose();
    hv_SignHomMat2D.Dispose();

    return;
  }

}
