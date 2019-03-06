using System;
using System.ComponentModel.DataAnnotations;

namespace PPR.Web.Models
{
    public class LastRepairReportInfoViewModel
    {
            public int Id { get; set; }
            [Display(Name = "Текущая дата")]
            public DateTime CurrentDate { get; set; }
            public int? EquipmentId { get; set; }
            public EquipmentViewModel Equipment { get; set; }
            public int? LastRepairId { get; set; }
            public LastRepairViewModel LastRepair { get; set; }
    }
}