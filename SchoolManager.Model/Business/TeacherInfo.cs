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
    /// 教师表
    /// </summary>
    [Table("common_teacher")]
    public class TeacherInfo : PersonInfo
    {
        [Display(Name = "任教日期")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public DateTime? InTake { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public int PositionId { get; set; }

        [Display(Name = "Column.Position")]
        public PositionInfo Position { get; set; }
        /// <summary>
        /// 职称
        /// </summary>
        public int TitleId { get; set; }

        [Display(Name = "Column.Title")]
        public TitleInfo Title { get; set; }
        
        [Display(Name = "教师培训")]
        public List<TeacherProject> TeacherProjects { get; set; }

        [Display(Name = "教师荣誉")]
        public List<TeacherHonor> StudentHonors { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        [Display(Name = "授业科目")]
        public List<TeacherSubject> StudentSubjects { get; set; }

        
    }
}
