using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.MVC.Models
{
    public class VehicleViewModel
    {
        public int Vehicle_Registration_Number { get; set; }
        [Required]
        [Display(Name = "Number Plate")]
        public string Vehicle_Number_Plate { get; set; }
        [Required]
        [Display(Name = "Vehicle Make")]
        public string Vehicle_Make { get; set; }
        [Required]
        [Display(Name = "Vehicle Model")]
        public string Vehicle_Model { get; set; }
        [Required]
        [Display(Name = "Branch")]
        public string Branch { get; set; }

        public virtual List<WaybillViewModel> Waybill { get; set; }
    }
}
