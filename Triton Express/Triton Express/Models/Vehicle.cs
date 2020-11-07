using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TritonExpress.Models
{
    public class Vehicle
    {
        [Key]
        public int Vehicle_Registration_Number { get; set; }


        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Vehicle_Number_Plate { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Vehicle_Make { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Vehicle_Model { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Branch { get; set; }

        public virtual List<Waybill> Waybill { get; set; }
    }
}
