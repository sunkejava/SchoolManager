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
    /// 科目管理
    /// </summary>
    [Table("basic_subject")]
    public class SubjectInfo : PersistPoco
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
    }
}
