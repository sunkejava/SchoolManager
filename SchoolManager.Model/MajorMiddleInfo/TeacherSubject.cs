using SchoolManager.Model.BasicInfo;
using SchoolManager.Model.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Attributes;

namespace SchoolManager.Model.MajorMiddleInfo
{
    /// <summary>
    /// 教师科目中间表
    /// </summary>
    [MiddleTable()]
    [Table("Middle_TeacherSubject")]
    public class TeacherSubject : BasePoco
    {
        [Display(Name = "Column.Subject")]
        public SubjectInfo Subject { get; set; }

        [Display(Name = "Column.Teacher")]
        public TeacherInfo Teacher { get; set; }

        [Display(Name = "科目ID")]
        public int SubjectId { get; set; }

        [Display(Name = "教师ID")]
        public int TeacherId { get; set; }
        
    }
}
