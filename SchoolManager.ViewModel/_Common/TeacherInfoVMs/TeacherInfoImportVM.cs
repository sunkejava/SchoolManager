using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.Business;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Common.TeacherInfoVMs
{
    public partial class TeacherInfoTemplateVM : BaseTemplateVM
    {
        [Display(Name = "任教日期")]
        public ExcelPropety InTake_Excel = ExcelPropety.CreateProperty<TeacherInfo>(x => x.InTake);
        [Display(Name = "Column.Position")]
        public ExcelPropety Position_Excel = ExcelPropety.CreateProperty<TeacherInfo>(x => x.PositionId);
        [Display(Name = "Column.Title")]
        public ExcelPropety Title_Excel = ExcelPropety.CreateProperty<TeacherInfo>(x => x.TitleId);
        [Display(Name = "Column.Code")]
        public ExcelPropety Code_Excel = ExcelPropety.CreateProperty<TeacherInfo>(x => x.Code);
        [Display(Name = "Column.Name")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<TeacherInfo>(x => x.Name);
        [Display(Name = "Column.Phone")]
        public ExcelPropety CellPhone_Excel = ExcelPropety.CreateProperty<TeacherInfo>(x => x.CellPhone);
        [Display(Name = "_Admin.ZipCode")]
        public ExcelPropety ZipCode_Excel = ExcelPropety.CreateProperty<TeacherInfo>(x => x.ZipCode);
        [Display(Name = "Column.EmContacts")]
        public ExcelPropety EmContacts_Excel = ExcelPropety.CreateProperty<TeacherInfo>(x => x.EmContacts);
        [Display(Name = "Column.EmContactsPhone")]
        public ExcelPropety EmConPhone_Excel = ExcelPropety.CreateProperty<TeacherInfo>(x => x.EmConPhone);
        [Display(Name = "Column.SchoolName")]
        public ExcelPropety SchoolInfo_Excel = ExcelPropety.CreateProperty<TeacherInfo>(x => x.SchoolInfoId);
        [Display(Name = "Column.Major")]
        public ExcelPropety MajorInfo_Excel = ExcelPropety.CreateProperty<TeacherInfo>(x => x.MajorInfoId);
        [Display(Name = "Column.GradeClass")]
        public ExcelPropety GradeClass_Excel = ExcelPropety.CreateProperty<TeacherInfo>(x => x.GradeClassId);

	    protected override void InitVM()
        {
            Position_Excel.DataType = ColumnDataType.ComboBox;
            Position_Excel.ListItems = DC.Set<PositionInfo>().GetSelectListItems(Wtm, y => y.Name);
            Title_Excel.DataType = ColumnDataType.ComboBox;
            Title_Excel.ListItems = DC.Set<TitleInfo>().GetSelectListItems(Wtm, y => y.Name);
            SchoolInfo_Excel.DataType = ColumnDataType.ComboBox;
            SchoolInfo_Excel.ListItems = DC.Set<SchoolInfo>().GetSelectListItems(Wtm, y => y.EnglishName);
            MajorInfo_Excel.DataType = ColumnDataType.ComboBox;
            MajorInfo_Excel.ListItems = DC.Set<MajorInfo>().GetSelectListItems(Wtm, y => y.Name);
            GradeClass_Excel.DataType = ColumnDataType.ComboBox;
            GradeClass_Excel.ListItems = DC.Set<GradeClassInfo>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class TeacherInfoImportVM : BaseImportVM<TeacherInfoTemplateVM, TeacherInfo>
    {

    }

}
