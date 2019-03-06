using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPR.BLL.DataTransferObjects
{
    public class LastRepairReportInfoDTO
    {
        public int Id { get; set; }
        public DateTime CurrentDate { get; set; }
        public int? EquipmentId { get; set; }
        public EquipmentDTO Equipment { get; set; }
        public int? LastRepairId { get; set; }
        public LastRepairDTO LastRepair { get; set; }
    }
}
