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
    public partial class ProjectInfoSearcher : BaseSearcher
    {
        [Display(Name = "Column.Code")]
        public String Code { get; set; }
        [Display(Name = "Column.Name")]
        public String Name { get; set; }
        [Display(Name = "Column.TypeOfProjectEnum")]
        public TypeOfProjectEnum? TypeOfProject { get; set; }

        protected override void InitVM()
        {
        }

    }
}
