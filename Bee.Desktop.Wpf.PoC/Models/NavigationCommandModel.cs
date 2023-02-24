using System;

namespace Bee.Desktop.Wpf.PoC.Models
{
    public class NavigationCommandModel
    {
        public bool CanExecute { get; set; }
        public Type? ViewModel { get; set; }
        public string? ViewModelName
        {
            get
            {
                return ViewModel?.Name;
            }
        }
        public bool IsHidden { get; set; }
    }
}
