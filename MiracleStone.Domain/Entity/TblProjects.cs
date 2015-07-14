using MiracleStone.Domain.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleStone.Domain.Entity
{
    public class TblProjects
    {
        [Key]
        public int TblProjectsID { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]
        [MaxLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]
        [MaxLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string NameFa { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]
        [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string Location { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]
        [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        public string LocationFa { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ErrorMessage))]
        [Range(0, 100, ErrorMessage="Please Enter Progress Between 0 And 100")]
        public int Progress { get; set; }
    }
}
