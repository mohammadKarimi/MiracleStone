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
    public class TblImage
    {
        [Key]
        public int TblImageID { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string Address { get; set; }

        public int ForeignKey { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(25, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string TableName { get; set; }

        public bool IsDefault { get; set; }

    }
}
