using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.Business;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Common.StudentInfoVMs
{
    public partial class StudentInfoTemplateVM : BaseTemplateVM
    {
        [Display(Name = "Column.InTake")]
        public ExcelPropety InTake_Excel = ExcelPropety.CreateProperty<StudentInfo>(x => x.InTake);
        [Display(Name = "Column.Code")]
        public ExcelPropety Code_Excel = ExcelPropety.CreateProperty<StudentInfo>(x => x.Code);
        [Display(Name = "Column.Name")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<StudentInfo>(x => x.Name);
        [Display(Name = "Column.Phone")]
        public ExcelPropety CellPhone_Excel = ExcelPropety.CreateProperty<StudentInfo>(x => x.CellPhone);
        [Display(Name = "_Admin.ZipCode")]
        public ExcelPropety ZipCode_Excel = ExcelPropety.CreateProperty<StudentInfo>(x => x.ZipCode);
        [Display(Name = "Column.EmContacts")]
        public ExcelPropety EmContacts_Excel = ExcelPropety.CreateProperty<StudentInfo>(x => x.EmContacts);
        [Display(Name = "Column.EmContactsPhone")]
        public ExcelPropety EmConPhone_Excel = ExcelPropety.CreateProperty<StudentInfo>(x => x.EmConPhone);
        [Display(Name = "Column.SchoolName")]
        public ExcelPropety SchoolInfo_Excel = ExcelPropety.CreateProperty<StudentInfo>(x => x.SchoolInfoId);
        [Display(Name = "Column.Major")]
        public ExcelPropety MajorInfo_Excel = ExcelPropety.CreateProperty<StudentInfo>(x => x.MajorInfoId);
        [Display(Name = "Column.GradeClass")]
        public ExcelPropety GradeClass_Excel = ExcelPropety.CreateProperty<StudentInfo>(x => x.GradeClassId);

	    protected override void InitVM()
        {
            SchoolInfo_Excel.DataType = ColumnDataType.ComboBox;
            SchoolInfo_Excel.ListItems = DC.Set<SchoolInfo>().GetSelectListItems(Wtm, y => y.EnglishName);
            MajorInfo_Excel.DataType = ColumnDataType.ComboBox;
            MajorInfo_Excel.ListItems = DC.Set<MajorInfo>().GetSelectListItems(Wtm, y => y.Name);
            GradeClass_Excel.DataType = ColumnDataType.ComboBox;
            GradeClass_Excel.ListItems = DC.Set<GradeClassInfo>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class StudentInfoImportVM : BaseImportVM<StudentInfoTemplateVM, StudentInfo>
    {

    }

}
