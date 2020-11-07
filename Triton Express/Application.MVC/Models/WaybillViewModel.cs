using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Application.MVC.Models
{
    public class WaybillViewModel
    {
        public int WaybillId { get; set; }

        [Required]
        [Display(Name = "Total Weight")]
        public string Waybill_Total_weight { get; set; }
        [Required]
        [Display(Name = "Total Parcels")]
        public string Waybil_Total_Parcels_Allocated { get; set; }
        [Display(Name = "Registration Number")]
        public int Vehicle_Registration_Number { get; set; }
        [Required]
        [Display(Name = "Number Plate")]
        public string Vehicle_Number_Plate { get; set; }

        [ForeignKey("Vehicle_Registration_Number")]
        public VehicleViewModel Vehicle { get; set; }

    }
}
