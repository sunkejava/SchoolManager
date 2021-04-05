using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.Business;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Common.TeacherProjectManagerVMs
{
    public partial class TeacherProjectManagerTemplateVM : BaseTemplateVM
    {
        [Display(Name = "开始时间")]
        public ExcelPropety StartDate_Excel = ExcelPropety.CreateProperty<TeacherProjectManager>(x => x.StartDate);
        [Display(Name = "结束时间")]
        public ExcelPropety EndDate_Excel = ExcelPropety.CreateProperty<TeacherProjectManager>(x => x.EndDate);
        [Display(Name = "Column.Project")]
        public ExcelPropety Project_Excel = ExcelPropety.CreateProperty<TeacherProjectManager>(x => x.ProjectId);
        [Display(Name = "Column.Teacher")]
        public ExcelPropety Teacher_Excel = ExcelPropety.CreateProperty<TeacherProjectManager>(x => x.TeacherId);

	    protected override void InitVM()
        {
            Project_Excel.DataType = ColumnDataType.ComboBox;
            Project_Excel.ListItems = DC.Set<ProjectInfo>().GetSelectListItems(Wtm, y => y.Name);
            Teacher_Excel.DataType = ColumnDataType.ComboBox;
            Teacher_Excel.ListItems = DC.Set<TeacherInfo>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class TeacherProjectManagerImportVM : BaseImportVM<TeacherProjectManagerTemplateVM, TeacherProjectManager>
    {

    }

}
