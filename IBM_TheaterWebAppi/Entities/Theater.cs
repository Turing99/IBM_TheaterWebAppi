using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_TheaterWebAppi.Entities
{
    public class Theater
    {

        [Key]
        public Guid ID { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(120)]
        public string Adress { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required]
        public Guid ActorId { get; set; }

        [ForeignKey("ActorId")]
        public virtual Actor Actor { get; set; }

        public bool? Deleted { get; set; }

    }
}
