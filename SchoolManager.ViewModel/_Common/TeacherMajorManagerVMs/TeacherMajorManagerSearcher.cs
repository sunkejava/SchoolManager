using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.Business;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Common.TeacherMajorManagerVMs
{
    public partial class TeacherMajorManagerSearcher : BaseSearcher
    {
        [Display(Name = "开始时间")]
        public DateRange StartDate { get; set; }
        [Display(Name = "结束时间")]
        public DateRange EndDate { get; set; }
        [Display(Name = "Column.Honor")]
        public int? HonorId { get; set; }
        [Display(Name = "Column.Teacher")]
        public int? TeacherId { get; set; }

        protected override void InitVM()
        {
        }

    }
}
