using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPR.Web.Models
{
    public class BrigadeViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Код бригады")]
        public int Code { get; set; }
        [Display(Name = "Кол-во человек")]
        public int NumberOfPeople { get; set; }
        [Display(Name = "Бригадир")]
        public string BrigadeChiefName { get; set; }
        [Display(Name = "Номер цеха")]
        public int? DepartmentId { get; set; }
        public DepartmentViewModel Department { get; set; }
    }
}