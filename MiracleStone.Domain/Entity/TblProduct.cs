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
    [Table("TblProduct", Schema = "dbo")]
    public class TblProduct
    {
        [Key]
        public int TblProductID { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]
        [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string Name { get; set; }
       
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]
        [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string NameFa { get; set; }

        [DisplayName("Category")]
        public int TblCategoriesID { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]
        [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string ProductBy { get; set; }
    }
}
