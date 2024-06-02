using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    [Table("tblCities")]
    public class CityEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string CityId { get; set; }

        public CityEntity(string city, string cityId)
        {
            City = city;
            CityId = cityId;
        }
    }
}
