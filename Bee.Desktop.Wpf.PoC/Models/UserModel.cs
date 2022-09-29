using System;
using System.ComponentModel.DataAnnotations;

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
