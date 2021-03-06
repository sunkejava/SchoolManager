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
    public partial class SchoolInfoSearcher : BaseSearcher
    {
        [Display(Name = "Column.Code")]
        public String Code { get; set; }
        [Display(Name = "Column.Name")]
        public String Name { get; set; }
        [Display(Name = "Column.EnglishName")]
        public String EnglishName { get; set; }
        [Display(Name = "Column.PinyinName")]
        public String PinyinName { get; set; }
        [Display(Name = "Column.SimplePinyinName")]
        public String SimplePinyinName { get; set; }
        [Display(Name = "Column.SimpleName")]
        public String SimpleName { get; set; }
        [Display(Name = "Column.Contacts")]
        public String Contacts { get; set; }
        [Display(Name = "Column.Phone")]
        public String Phone { get; set; }
        [Display(Name = "Column.TypeOfEducation")]
        public TypeOfEducationEnum? TypeOfEducation { get; set; }
        [Display(Name = "Column.Address")]
        public String Address { get; set; }
        [Display(Name = "Column.TypeOfUrbanAndRural")]
        public TypeOfUrbanAndRuralEnum? TypeOfUrbanAndRural { get; set; }

        protected override void InitVM()
        {
        }

    }
}
