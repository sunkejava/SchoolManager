using SchoolManager.Model.BasicInfo;
using SchoolManager.Model.MajorMiddleInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Model.Business
{
    /// <summary>
    /// 学生表
    /// </summary>
    [Table("common_student")]
    public class StudentInfo : PersonInfo
    {
        [Display(Name = "Column.InTake")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public DateTime? InTake { get; set; }    

        [Display(Name = "学生荣誉")]
        public List<StudentHonor> StudentHonors { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        [Display(Name = "学生科目")]
        public List<StudentSubject> StudentSubjects { get; set; }

    }
}
