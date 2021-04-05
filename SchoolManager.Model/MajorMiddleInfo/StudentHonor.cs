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
    /// 学生荣誉中间表
    /// 处理多对多业务
    /// </summary>
    [MiddleTable()]
    [Table("Middle_StudentHonor")]
    public class StudentHonor : BasePoco
    {
        [Display(Name = "Column.Honor")]
        public HonorInfo Honor { get; set; }

        [Display(Name = "Column.Student")]
        public StudentInfo Student { get; set; }

        [Display(Name = "荣誉ID")]
        public int HonorId { get; set; }

        [Display(Name = "学生ID")]
        public int StudentId { get; set; }
    }

}
