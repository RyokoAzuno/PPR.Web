using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPR.BLL.DataTransferObjects
{
    public class NextRepairReportInfoDTO
    {
        public int Id { get; set; }
        public DateTime CurrentDate { get; set; }
        public int? EquipmentId { get; set; }
        public EquipmentDTO Equipment { get; set; }
        public int? NextRepairId { get; set; }
        public NextRepairDTO NextRepair { get; set; }
    }
}
