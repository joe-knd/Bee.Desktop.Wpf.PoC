using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bee.Desktop.Wpf.PoC.Models
{
    public class UserModel
    {
        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }

        [Required]
        public string? IPV4Address { get; set; }

        [Required]
        public string? PortNumber { get; set; }

        [Required]
        public string? SecurePIN { get; set; }
    }
}
