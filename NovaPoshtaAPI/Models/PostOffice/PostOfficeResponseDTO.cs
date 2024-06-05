using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaPoshtaAPIBleBla.Models.PostOffice
{
    public class PostOfficeResponseDTO
    {
        public bool Success { get; set; }

        public List<PostOfficeItemResponseDTO> Data { get; set; }
    }
}
