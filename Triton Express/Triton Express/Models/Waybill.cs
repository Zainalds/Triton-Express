using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TritonExpress.Models
{
    public class Waybill
    {
        [Key]
        public int WaybillId { get; set; }


        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Waybill_Total_weight { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Waybil_Total_Parcels_Allocated { get; set; }


        public int Vehicle_Registration_Number { get; set; }

        public string Vehicle_Number_Plate { get; set; }

        [ForeignKey("Vehicle_Registration_Number")]
        public Vehicle Vehicle { get; set; }
    }
}
