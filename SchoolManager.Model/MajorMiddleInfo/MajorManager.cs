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

namespace SchoolManager.Model.MajorMiddleInfo
{
    /// <summary>
    /// 学生荣誉管理
    /// </summary>
    [Table("Middle_MajorManager")]
    public class MajorManager : PersistPoco
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

        [Display(Name = "Column.Student")]
        public StudentInfo Student { get; set; }

        [Display(Name = "荣誉ID")]
        public int HonorId { get; set; }

        [Display(Name = "学生ID")]
        public int StudentId { get; set; }

    }

}
