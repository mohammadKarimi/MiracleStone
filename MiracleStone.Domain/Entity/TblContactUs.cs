using MiracleStone.Domain.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleStone.Domain.Entity
{
    [Table("TblContactUs", Schema = "dbo")]
    public class TblContactUs
    {
        [Key]
        public int TblContactUsID { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]
        [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string FullName { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]
        [MaxLength(150, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string Subject { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]
        [MaxLength(1500, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string Message { get; set; }

        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        public ContactStatus ContactStatus { get; set; }

        public int? ParentID { get; set; }

        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Please Enter Correct Email")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]
        [MaxLength(150, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }
    }

    public enum ContactStatus
    {
        Read,
        UnRead,
        Delete
    }
}
