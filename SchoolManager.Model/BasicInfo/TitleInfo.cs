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
    /// 职称信息
    /// </summary>
    [Table("basic_titles")]
    public class TitleInfo : PersistPoco
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ID { get; set; }

        [Display(Name = "Column.Code", Description = "代码")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [StringLength(12, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Code { get; set; }


        [Display(Name = "Column.Name",Description = "名称")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Name { get; set; }
    }
}
