using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.Models
{
    public class Signup
    {
        public Int32 SignupId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public string Activity { get; set; }

        public string Comments { get; set; }
    }
}
