using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace SchoolManager.Model.BasicInfo
{
    /// <summary>
    /// 荣誉信息
    /// </summary>
    [Table("basic_honors")]
    public class HonorInfo: PersistPoco
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ID { get; set; }

        [Display(Name = "Column.Code")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [StringLength(12, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Code { get; set; }


        [Display(Name = "Column.Name")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Name { get; set; }

        [Display(Name = "Column.TypeOfHonorEnum")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public TypeOfHonorEnum TypeOfHonor { get; set; }
    }

    /// <summary>
    /// 类型
    /// </summary>
    public enum TypeOfHonorEnum
    {
        [Display(Name = "教师")]
        Teacher,
        [Display(Name = "学生")]
        Student,
    }
}
