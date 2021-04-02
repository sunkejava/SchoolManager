using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.PositionInfoVMs
{
    public partial class PositionInfoSearcher : BaseSearcher
    {
        [Display(Name = "Column.Code")]
        public String Code { get; set; }
        [Display(Name = "Column.Name")]
        public String Name { get; set; }

        protected override void InitVM()
        {
        }

    }
}
