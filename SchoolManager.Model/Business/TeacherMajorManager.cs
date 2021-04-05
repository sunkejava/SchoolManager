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
    /// 教师荣誉管理
    /// </summary>
    [Table("Middle_TeacherMajorManager")]
    public class TeacherMajorManager : PersistPoco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ID { get; set; }

        [Display(Name = "开始时间")]
        public DateTime StartDate { get; set; }

        [Display(Name = "结束时间")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Column.Honor")]
        public HonorInfo Honor { get; set; }

        [Display(Name = "Column.Teacher")]
        public TeacherInfo Teacher { get; set; }

        [Display(Name = "荣誉ID")]
        public int HonorId { get; set; }

        [Display(Name = "教师ID")]
        public int TeacherId { get; set; }
    }
}
