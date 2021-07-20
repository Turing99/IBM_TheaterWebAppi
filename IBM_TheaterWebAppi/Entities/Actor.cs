using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_TheaterWebAppi.Entities
{
    public class Actor
    {
        [Key]
        public Guid ID { get; set; }

        [MaxLength(150)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(150)]
        [Required]
        public string LastName { get; set; }


        public bool? Deleted { get; set; }

    }
}
