using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.ProjectInfoVMs
{
    public partial class ProjectInfoTemplateVM : BaseTemplateVM
    {
        [Display(Name = "Column.Code")]
        public ExcelPropety Code_Excel = ExcelPropety.CreateProperty<ProjectInfo>(x => x.Code);
        [Display(Name = "Column.Name")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<ProjectInfo>(x => x.Name);
        [Display(Name = "Column.TypeOfProjectEnum")]
        public ExcelPropety TypeOfProject_Excel = ExcelPropety.CreateProperty<ProjectInfo>(x => x.TypeOfProject);

	    protected override void InitVM()
        {
        }

    }

    public class ProjectInfoImportVM : BaseImportVM<ProjectInfoTemplateVM, ProjectInfo>
    {

    }

}
