using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diarna.DTOs.Building2
{
    public class ReadBuilding2Dto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int? VillageId { get; set; }
        public string VillageName { get; set; }
    }
}
