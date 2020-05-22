/*-------------------------------------------------------------------------------
 * 系统名称  ：工业自动化系统
 * 子系统名称：工业相机识码子系统
 * 功能模块名：工业相机识码
 * 类名      ：SaveData/ImgAuto
 * 概要      ：保存数据/自动捕捉
 * 
 * 改版履历
 * Ver----------日期---------单位・姓名--------------------概要------------------
 * 1.0.0.0      2020/05/18   Shandong_HuaShi ZhangSh       新建
 * 
 * ------------------------------------------------------------------------------
 */

using System.Runtime.Serialization;

namespace CodeReading.Entity
{
    #region 是否需要"保存数据"
    [DataContract]
    public enum SaveDataState
    {
        [DataMember]
        saveDataTrue,
        [DataMember]
        saveDataFalse
    }
    /// <summary>
    /// 是否需要"保存数据"
    /// </summary>
    /// saveDataTrue-需要保存
    /// saveDataFalse-不需要保存
    [DataContract]
    public class SaveData
    {
        [DataMember]
        public static SaveDataState state = SaveDataState.saveDataFalse;
    }
    #endregion

    #region 是否需要"自动捕捉"
    [DataContract]
    public enum ImgAutoState
    {
        [DataMember]
        imgAutoTrue,
        [DataMember]
        imgAutoFalse
    }
    /// <summary>
    /// 是否需要"自动捕捉"
    /// </summary>
    /// imgAutoTrue-自动捕捉
    /// imgAutoFalse-手动捕捉
    [DataContract]
    public class ImgAuto
    {
        [DataMember]
        public static ImgAutoState state = ImgAutoState.imgAutoTrue;
    }
    #endregion

    #region 是否需要"自动识别"
    [DataContract]
    public enum AutoTState
    {
        [DataMember]
        AT,
        [DataMember]
        MT
    }
    /// <summary>
    /// 是否需要"自动识别"
    /// </summary>
    /// AT-自动识别
    /// MT-手动识别
    [DataContract]
    public class AutoT
    {
        [DataMember]
        public static AutoTState state = AutoTState.AT;
    }
    #endregion
}
