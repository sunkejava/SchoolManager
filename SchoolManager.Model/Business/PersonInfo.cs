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
    /// 人员基类
    /// </summary>
    [Table("FrameworkUsers")]
    public class PersonInfo : PersistPoco
    {

        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ID { get; set; }

        [Display(Name = "Column.Code")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [RegularExpression("^[0-9]{6,6}$", ErrorMessage = "Validate.{0}formaterror")]
        [StringLength(6, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Code { get; set; }

        [Display(Name = "Column.Name")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Name { get; set; }

        [Display(Name = "Column.Phone")]
        [RegularExpression("^[1][3,4,5,7,8][0-9]{9}$", ErrorMessage = "Validate.{0}formaterror")]
        public string CellPhone { get; set; }

        [Display(Name = "_Admin.ZipCode")]
        [RegularExpression("^[0-9]{6,6}$", ErrorMessage = "Validate.{0}zipcode")]
        public string ZipCode { get; set; }

        [Display(Name = "Column.EmContacts")]
        public string EmContacts { get; set; }

        [Display(Name = "Column.EmContactsPhone")]
        [RegularExpression("^[1][3,4,5,7,8][0-9]{9}$", ErrorMessage = "Validate.{0}formaterror")]
        public string EmConPhone { get; set; }


        public int SchoolInfoId { get; set; }

        [Display(Name = "Column.SchoolName")]
        public SchoolInfo SchoolInfo { get; set; }

        public int MajorInfoId { get; set; }
        [Display(Name = "Column.Major")]
        public MajorInfo MajorInfo { get; set; }

        [Display(Name = "_Admin.Photo")]
        public Guid? PhotoId { get; set; }
        [Display(Name = "_Admin.Photo")]
        public FileAttachment Photo { get; set; }

        public int GradeClassId { get; set; }

        [Display(Name = "Column.GradeClass")]
        public GradeClassInfo GradeClass { get; set; }

    }
}
