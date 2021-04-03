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
    /// 学校信息
    /// </summary>
    [Table("basic_schools")]
    public class SchoolInfo: PersistPoco
    {
        [Key]
        [Column("SchoolInfoId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ID { get; set; }

        [Display(Name = "Column.Code")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [RegularExpression("^[0-9]{6,6}$",ErrorMessage = "Validate.{0}formaterror")]
        [StringLength(11,ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Code { get; set; }

        [Display(Name = "Column.Name")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Name { get; set; }

        [Display(Name = "Column.EnglishName")]
        [StringLength(500, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string EnglishName { get; set; }

        [Display(Name = "Column.PinyinName")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [StringLength(30,ErrorMessage = "Validate.{0}stringmax{1}")]
        public string PinyinName { get; set; }

        [Display(Name = "Column.SimplePinyinName")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string SimplePinyinName { get; set; }

        [Display(Name = "Column.SimpleName")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string SimpleName { get; set; }

        [Display(Name = "Column.Contacts")]
        [StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Contacts { get; set; }


        [Display(Name = "Column.Phone")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Phone { get; set; }

        [Display(Name = "Column.TypeOfEducation")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public TypeOfEducationEnum? TypeOfEducation { get; set; }

        [Display(Name = "Column.Address")]
        [StringLength(100, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Address { get; set; }

        [Display(Name = "Column.TypeOfUrbanAndRural")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public TypeOfUrbanAndRuralEnum TypeOfUrbanAndRural { get; set; }

    }

    #region 枚举

    /// <summary>
    /// 教育类型
    /// </summary>
    public enum TypeOfEducationEnum
    { 
        [Display(Name = "学前教育")]
        XQJY,
        [Display(Name = "初等教育")]
        CDJY,
        [Display(Name = "中等教育")]
        ZDJY,
        [Display(Name = "高等教育")]
        GDJY,
        [Display(Name = "特殊教育")]
        TSJY
    }


    /// <summary>
    /// 城乡类型
    /// </summary>
    public enum TypeOfUrbanAndRuralEnum 
    {
        [Display(Name = "主城区")]
        ZCQ,
        [Display(Name = "城乡结合区")]
        CXJHQ,
        [Display(Name = "镇中心区")]
        ZZXQ,
        [Display(Name = "镇乡结合区")]
        ZXJHQ,
        [Display(Name = "特殊区域")]
        TSQY,
        [Display(Name = "乡中心区")]
        XZXQ,
        [Display(Name = "村庄")]
        CZ
    }

    #endregion
}
