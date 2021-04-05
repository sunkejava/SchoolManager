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
    /// 全国5级区划代码
    /// </summary>
    [Table("basic_divisions")]
    public class Division : PersistPoco
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ID { get; set; }

        [Display(Name = "Column.ZoningCode")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [StringLength(12, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Code { get; set; }

        private string parentCode;

        [Display(Name = "Column.ParentZoningCode")]
        public string ParentCode
        {
            get { return parentCode; }
            set { parentCode = value; }
        }

        [Display(Name = "Column.TypeOfUrbanAndRuralCode")]
        [StringLength(3, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string RuralCode { get; set; }

        [Display(Name = "Column.Name")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Name { get; set; }

    }
}
