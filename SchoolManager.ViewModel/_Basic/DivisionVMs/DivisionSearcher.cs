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
    public partial class DivisionSearcher : BaseSearcher
    {
        [Display(Name = "Column.ZoningCode")]
        public String Code { get; set; }
        [Display(Name = "Column.ParentZoningCode")]
        public String ParentCode { get; set; }
        [Display(Name = "Column.TypeOfUrbanAndRuralCode")]
        public String RuralCode { get; set; }
        [Display(Name = "Column.Name")]
        public String Name { get; set; }

        protected override void InitVM()
        {
        }

    }
}
