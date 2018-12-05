using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPR.Web.Models
{
    public class NextRepairViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Вид ремонта")]
        public string RepairType { get; set; }
        [Display(Name = "Исполнитель")]
        public string Technician { get; set; }
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }
        public int? EquipmentId { get; set; }
        public EquipmentViewModel Equipment { get; set; }
    }
}