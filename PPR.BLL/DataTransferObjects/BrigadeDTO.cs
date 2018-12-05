using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPR.BLL.DataTransferObjects
{
    public class BrigadeDTO
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public int NumberOfPeople { get; set; }
        public string BrigadeChiefName { get; set; }
        public int? DepartmentId { get; set; }
        public DepartmentDTO Department { get; set; }
    }
}
