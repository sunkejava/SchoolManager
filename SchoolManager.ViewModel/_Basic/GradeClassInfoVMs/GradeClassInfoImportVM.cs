using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.GradeClassInfoVMs
{
    public partial class GradeClassInfoTemplateVM : BaseTemplateVM
    {
        [Display(Name = "Column.Code")]
        public ExcelPropety Code_Excel = ExcelPropety.CreateProperty<GradeClassInfo>(x => x.Code);
        [Display(Name = "Column.Grade")]
        public ExcelPropety Grade_Excel = ExcelPropety.CreateProperty<GradeClassInfo>(x => x.GradeId);
        [Display(Name = "Column.Name")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<GradeClassInfo>(x => x.Name);

	    protected override void InitVM()
        {
            Grade_Excel.DataType = ColumnDataType.ComboBox;
            Grade_Excel.ListItems = DC.Set<GradeInfo>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class GradeClassInfoImportVM : BaseImportVM<GradeClassInfoTemplateVM, GradeClassInfo>
    {

    }

}
