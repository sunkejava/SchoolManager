using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.SchoolInfoVMs
{
    public partial class SchoolInfoTemplateVM : BaseTemplateVM
    {
        [Display(Name = "Column.Code")]
        public ExcelPropety Code_Excel = ExcelPropety.CreateProperty<SchoolInfo>(x => x.Code);
        [Display(Name = "Column.Name")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<SchoolInfo>(x => x.Name);
        [Display(Name = "Column.EnglishName")]
        public ExcelPropety EnglishName_Excel = ExcelPropety.CreateProperty<SchoolInfo>(x => x.EnglishName);
        [Display(Name = "Column.PinyinName")]
        public ExcelPropety PinyinName_Excel = ExcelPropety.CreateProperty<SchoolInfo>(x => x.PinyinName);
        [Display(Name = "Column.SimplePinyinName")]
        public ExcelPropety SimplePinyinName_Excel = ExcelPropety.CreateProperty<SchoolInfo>(x => x.SimplePinyinName);
        [Display(Name = "Column.SimpleName")]
        public ExcelPropety SimpleName_Excel = ExcelPropety.CreateProperty<SchoolInfo>(x => x.SimpleName);
        [Display(Name = "Column.Contacts")]
        public ExcelPropety Contacts_Excel = ExcelPropety.CreateProperty<SchoolInfo>(x => x.Contacts);
        [Display(Name = "Column.Phone")]
        public ExcelPropety Phone_Excel = ExcelPropety.CreateProperty<SchoolInfo>(x => x.Phone);
        [Display(Name = "Column.TypeOfEducation")]
        public ExcelPropety TypeOfEducation_Excel = ExcelPropety.CreateProperty<SchoolInfo>(x => x.TypeOfEducation);
        [Display(Name = "Column.Address")]
        public ExcelPropety Address_Excel = ExcelPropety.CreateProperty<SchoolInfo>(x => x.Address);
        [Display(Name = "Column.TypeOfUrbanAndRural")]
        public ExcelPropety TypeOfUrbanAndRural_Excel = ExcelPropety.CreateProperty<SchoolInfo>(x => x.TypeOfUrbanAndRural);

	    protected override void InitVM()
        {
        }

    }

    public class SchoolInfoImportVM : BaseImportVM<SchoolInfoTemplateVM, SchoolInfo>
    {

    }

}
