using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PPR.Web.Models
{
    public class LastRepairViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Вид ремонта")]
        public string RepairType { get; set; }
        [Display(Name = "Исполнитель")]
        public string Technician { get; set; }
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] //!!!! for correct data in edit view
        public DateTime Date { get; set; }
        [Display(Name = "Наименование оборудования")]
        public int? EquipmentId { get; set; }
        public EquipmentViewModel Equipment { get; set; }
    }
}