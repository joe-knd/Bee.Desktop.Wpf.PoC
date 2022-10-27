using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bee.Desktop.Wpf.PoC.Models
{
    public partial class UserModel : ObservableValidator
    {
        [Required]
        [EmailAddress]
        [ObservableProperty]
        private string? emailAddress;

        [Required]
        [ObservableProperty]
        private string? name;

        [ObservableProperty]
        private bool isSelected;
    }
}
