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
        [Required, StringLength(200)]
        public string Ref { get; set; }
        [Required, StringLength(200)]
        public string Description { get; set; }
        [ForeignKey("Area")]
        public int AreaId { get; set; }
        public virtual AreaEntity Area { get; set; }
    }
}
