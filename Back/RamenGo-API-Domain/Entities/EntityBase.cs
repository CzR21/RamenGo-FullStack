using RamenGo_API_Domain.Enums;
using RamenGo_API_Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo_API_Domain.Entities
{
    public class EntityBase
    {
        public EntityBase()
        {
            TypeStatus = TypeStatus.Active;
            CreationDate = DateHelper.GetDateTimeBrazil();
        }

        [Column("id")]
        public int Id { get; set; }
        [Column("tp_status")]
        public TypeStatus TypeStatus{ get; set; }
        [Column("dt_creation")]
        public DateTime CreationDate { get; set; }
        [Column("dt_modification")]
        public DateTime? ModificationDate { get; set; }
    }
}
