using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.DivisionVMs
{
    public partial class DivisionTemplateVM : BaseTemplateVM
    {
        [Display(Name = "Column.ZoningCode")]
        public ExcelPropety Code_Excel = ExcelPropety.CreateProperty<Division>(x => x.Code);
        [Display(Name = "Column.ParentZoningCode")]
        public ExcelPropety ParentCode_Excel = ExcelPropety.CreateProperty<Division>(x => x.ParentCode);
        [Display(Name = "Column.TypeOfUrbanAndRuralCode")]
        public ExcelPropety RuralCode_Excel = ExcelPropety.CreateProperty<Division>(x => x.RuralCode);
        [Display(Name = "Column.Name")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<Division>(x => x.Name);

	    protected override void InitVM()
        {
        }

    }

    public class DivisionImportVM : BaseImportVM<DivisionTemplateVM, Division>
    {

    }

}
