﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaPoshtaAPIBleBla.Models.Area
{
    public class AreaResponseDTO
    {
        public bool Success { get; set; }
        public List<AreaItemResponseDTO> Data { get; set; }
    }
}
