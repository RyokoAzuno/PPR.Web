using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPR.Web.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Код цеха")]
        public int Code { get; set; }
        [Display(Name = "Название цеха")]
        public string Name { get; set; }
        [Display(Name = "Кол-во бригад")]
        public int NumberOfBrigades { get; set; }
        public ICollection<BrigadeViewModel> Brigades { get; set; }
        public ICollection<EquipmentViewModel> Equipments { get; set; }

        public DepartmentViewModel()
        {
            Equipments = new List<EquipmentViewModel>();
            Brigades = new List<BrigadeViewModel>();
        }
    }
}