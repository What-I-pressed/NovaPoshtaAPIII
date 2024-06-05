using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaPoshtaAPIBleBla.Entities
{
    [Table("tblPostOffices")]
    public class PostOfficeEntity
    {
        [Key]
        public int Id {get; set;}
        [Required]
        public string CityDescription { get; set;}
        [Required]
        public string Description { get; set;}
        [Required]
        public string CategoryOfWarehouse { get; set;}

        [Required]
        public string Ref {  get; set;}
    }
}
