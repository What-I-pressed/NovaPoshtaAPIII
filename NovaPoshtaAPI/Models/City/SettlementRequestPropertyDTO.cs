using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaPoshtaAPIBleBla.Models.City
{
    public class SettlementRequestPropertyDTO
    {
        public int Page { get; set; } = 1;
        
        public int Warehouse { get; set; } = 1;
        
        public int Limit { get; set; } = 200;
    }
}
