using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.Business;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Common.TeacherMajorManagerVMs
{
    public partial class TeacherMajorManagerTemplateVM : BaseTemplateVM
    {
        [Display(Name = "开始时间")]
        public ExcelPropety StartDate_Excel = ExcelPropety.CreateProperty<TeacherMajorManager>(x => x.StartDate);
        [Display(Name = "结束时间")]
        public ExcelPropety EndDate_Excel = ExcelPropety.CreateProperty<TeacherMajorManager>(x => x.EndDate);
        [Display(Name = "Column.Honor")]
        public ExcelPropety Honor_Excel = ExcelPropety.CreateProperty<TeacherMajorManager>(x => x.HonorId);
        [Display(Name = "Column.Teacher")]
        public ExcelPropety Teacher_Excel = ExcelPropety.CreateProperty<TeacherMajorManager>(x => x.TeacherId);

	    protected override void InitVM()
        {
            Honor_Excel.DataType = ColumnDataType.ComboBox;
            Honor_Excel.ListItems = DC.Set<HonorInfo>().GetSelectListItems(Wtm, y => y.Name);
            Teacher_Excel.DataType = ColumnDataType.ComboBox;
            Teacher_Excel.ListItems = DC.Set<TeacherInfo>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class TeacherMajorManagerImportVM : BaseImportVM<TeacherMajorManagerTemplateVM, TeacherMajorManager>
    {

    }

}
