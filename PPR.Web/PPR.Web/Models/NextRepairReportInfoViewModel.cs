using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPR.Web.Models
{
    public class NextRepairReportInfoViewModel
    {
            public int Id { get; set; }
            [Display(Name = "Текущая дата")]
            public DateTime CurrentDate { get; set; }
            public int? EquipmentId { get; set; }
            public EquipmentViewModel Equipment { get; set; }
            public int? LastRepairId { get; set; }
            public NextRepairViewModel NextRepair { get; set; }
    }
}