using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.GradeInfoVMs
{
    public partial class GradeInfoTemplateVM : BaseTemplateVM
    {
        [Display(Name = "Column.Code")]
        public ExcelPropety Code_Excel = ExcelPropety.CreateProperty<GradeInfo>(x => x.Code);
        [Display(Name = "Column.Name")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<GradeInfo>(x => x.Name);

	    protected override void InitVM()
        {
        }

    }

    public class GradeInfoImportVM : BaseImportVM<GradeInfoTemplateVM, GradeInfo>
    {

    }

}
