using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.Business;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Business.StudentInfoVMs
{
    public partial class StudentInfoSearcher : BaseSearcher
    {
        [Display(Name = "Column.InTake")]
        public DateRange InTake { get; set; }
        [Display(Name = "Column.Code")]
        public String Code { get; set; }
        [Display(Name = "Column.Name")]
        public String Name { get; set; }
        [Display(Name = "Column.Phone")]
        public String CellPhone { get; set; }
        [Display(Name = "_Admin.ZipCode")]
        public String ZipCode { get; set; }
        [Display(Name = "Column.EmContacts")]
        public String EmContacts { get; set; }
        [Display(Name = "Column.EmContactsPhone")]
        public String EmConPhone { get; set; }
        [Display(Name = "Column.Major")]
        public int? MajorInfoId { get; set; }
        [Display(Name = "Column.GradeClass")]
        public int? GradeClassId { get; set; }

        protected override void InitVM()
        {
        }

    }
}
