using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PPR.Web.Models
{
    public class EquipmentViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Инвентарный номер")]
        public string InventoryNumber { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Модель")]
        public string Model { get; set; }
        [Display(Name = "Кол-во двигателей")]
        public int NumberOfEngines { get; set; }
        [Display(Name = "Мощность")]
        public int Power { get; set; }
        [Display(Name = "ЕРС")]
        public float URC { get; set; }
        [Display(Name = "Примечания")]
        public string Notes { get; set; }
        [Display(Name = "Номер цеха")]
        public int? DepartmentId { get; set; }
        public DepartmentViewModel Department { get; set; }

        public ICollection<LastRepairViewModel> LastRepairs { get; set; }
        public ICollection<NextRepairViewModel> NextRepairs { get; set; }

        public EquipmentViewModel()
        {
            LastRepairs = new List<LastRepairViewModel>();
            NextRepairs = new List<NextRepairViewModel>();
        }
    }
}