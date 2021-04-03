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
    /// 学生科目中间表
    /// </summary>
    [MiddleTable]
    [Table("Middle_StudentSubject")]
    public class StudentSubject : BasePoco
    {
        [Display(Name = "Column.Subject")]
        public SubjectInfo Subject { get; set; }

        [Display(Name = "Column.Student")]
        public StudentInfo Student { get; set; }

        [Display(Name = "科目ID")]
        public int SubjectId { get; set; }

        [Display(Name = "学生ID")]
        public int StudentId { get; set; }
    }
}
