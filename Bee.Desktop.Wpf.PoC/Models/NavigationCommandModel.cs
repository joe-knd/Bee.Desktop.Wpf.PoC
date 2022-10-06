namespace Bee.Desktop.Wpf.PoC.Models
{
    public class NavigationCommandModel
    {
        public bool CanExecute { get; set; }
        public string? ViewModelName { get; set; }
        public bool IsHidden { get; set; }
    }
}
