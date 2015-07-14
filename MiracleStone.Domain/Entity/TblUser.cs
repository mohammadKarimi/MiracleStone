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
    public class TblUser
    {
        [Key]
        public int TblUserID { get; set; }

        [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]
        [MaxLength(10, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        [Column(TypeName = "varchar")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]

        [MaxLength(10, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        [Column(TypeName = "varchar")]
        public string Password { get; set; }
    }
}
