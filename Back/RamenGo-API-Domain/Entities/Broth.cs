using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo_API_Domain.Entities
{
    public class Broth : EntityBase
    {
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("price")]
        public double Price { get; set; }
        [Column("imageActive")]
        public string ImageActive { get; set; }
        [Column("imageInactive")]
        public string ImageInactive { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
