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
        [Range(0, 9999)]
        public int? PortNumber { get; set; }

        public string? NIP { get; set; }
    }
}
