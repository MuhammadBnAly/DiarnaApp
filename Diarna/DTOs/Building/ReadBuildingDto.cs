﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diarna.DTOs.Building
{
    public class ReadBuildingDto
    {

        public int Id { get; set; }
        public int? VillageId { get; set; }
        public string Name { get; set; }

    }
}
