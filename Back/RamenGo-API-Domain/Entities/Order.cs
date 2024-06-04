using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo_API_Domain.Entities
{
    public class Order : EntityBase
    {
        [Column("brothId")]
        public int BrothId { get; set; }
        public virtual Broth Broth { get; set; }
        [Column("proteinId")]
        public int ProteinId { get; set; }
        public virtual Protein Protein { get; set; }
    }
}
