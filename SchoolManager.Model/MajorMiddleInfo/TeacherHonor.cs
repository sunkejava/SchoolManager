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
    /// 教师荣誉
    /// </summary>
    [MiddleTable()]
    [Table("Middle_TeacherHonor")]
    public class TeacherHonor : BasePoco
    {
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
