using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    [Table("tblAreas")]
    public class AreaEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Ref { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        public virtual ICollection<CityEntity> Settlements { get; set; }

    }
}
