using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PPR.Web.Models
{
    public class BrigadeViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name ="Код бригады")]
        [Required]
        [Range(1, 999, ErrorMessage = "1 < Код бригады < 999")]
        public int Code { get; set; }
        [Display(Name = "Кол-во человек")]
        [Required]
        [Range(1, 11, ErrorMessage = "1 < Кол-во человек < 11")]
        public int NumberOfPeople { get; set; }
        [Display(Name = "Бригадир")]
        [Required]
        public string BrigadeChiefName { get; set; }
        [Display(Name = "Номер цеха")]
        public int? DepartmentId { get; set; }
        public DepartmentViewModel Department { get; set; }
    }
}