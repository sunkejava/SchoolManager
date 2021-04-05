using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.MajorMiddleInfo;
using SchoolManager.Model.BasicInfo;
using SchoolManager.Model.Business;


namespace SchoolManager.ViewModel._Common.MajorManagerVMs
{
    public partial class MajorManagerTemplateVM : BaseTemplateVM
    {
        [Display(Name = "开始时间")]
        public ExcelPropety StartDate_Excel = ExcelPropety.CreateProperty<MajorManager>(x => x.StartDate);
        [Display(Name = "结束时间")]
        public ExcelPropety EndDate_Excel = ExcelPropety.CreateProperty<MajorManager>(x => x.EndDate);
        [Display(Name = "Column.Honor")]
        public ExcelPropety Honor_Excel = ExcelPropety.CreateProperty<MajorManager>(x => x.HonorId);
        [Display(Name = "Column.Student")]
        public ExcelPropety Student_Excel = ExcelPropety.CreateProperty<MajorManager>(x => x.StudentId);

	    protected override void InitVM()
        {
            Honor_Excel.DataType = ColumnDataType.ComboBox;
            Honor_Excel.ListItems = DC.Set<HonorInfo>().GetSelectListItems(Wtm, y => y.Name);
            Student_Excel.DataType = ColumnDataType.ComboBox;
            Student_Excel.ListItems = DC.Set<StudentInfo>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class MajorManagerImportVM : BaseImportVM<MajorManagerTemplateVM, MajorManager>
    {

    }

}
