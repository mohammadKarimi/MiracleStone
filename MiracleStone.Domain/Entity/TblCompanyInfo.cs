using MiracleStone.Domain.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleStone.Domain.Entity
{
    [Table("TblCompanyInfo", Schema = "Company")]
    public class TblCompanyInfo
    {
        [Key]
        [ScaffoldColumn(false)]
        public int TblCompanyInfoID { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(25, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string Tel { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]
        [Column(TypeName = "varchar")]
        [MaxLength(25, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string Mobile { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]

        [Column(TypeName = "varchar")]
        [MaxLength(25, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string Fax { get; set; }

        [Required(ErrorMessage = "Please Enter The Bussiness Hours Field")]
        [Column(TypeName = "varchar")]
        [MaxLength(5, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string BussinessHoursFrom { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]

        [Column(TypeName = "varchar")]
        [MaxLength(5, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string BussinessHoursTo { get; set; }

        [MaxLength(500, ErrorMessage = "Please Don't Enter More Than 500 Charachter")]
        public string BussinessHoursDescription { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]
        [MaxLength(250, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string Address { get; set; }

        [MaxLength(350, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string Facebook { get; set; }

        [MaxLength(350, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string Twitter { get; set; }

        [MaxLength(350, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string GooglePlus { get; set; }

        [MaxLength(350, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string LinkedIn { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string AboutUs { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string Email { get; set; }

        [MaxLength(700, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string GoogleMapAddress { get; set; }

        public Lang Lang { get; set; }
    }
}
