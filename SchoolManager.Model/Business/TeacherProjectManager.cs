using SchoolManager.Model.BasicInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace SchoolManager.Model.Business
{
    /// <summary>
    /// 教师培训项目管理
    /// </summary>
    [Table("Middle_TeacherProjectManager")]
    public class TeacherProjectManager : PersistPoco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ID { get; set; }

        [Display(Name = "开始时间")]
        public DateTime StartDate { get; set; }

        [Display(Name = "结束时间")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Column.Project")]
        public ProjectInfo Project { get; set; }

        [Display(Name = "Column.Teacher")]
        public TeacherInfo Teacher { get; set; }

        [Display(Name = "项目ID")]
        public int ProjectId { get; set; }

        [Display(Name = "教师ID")]
        public int TeacherId { get; set; }
    }
}
