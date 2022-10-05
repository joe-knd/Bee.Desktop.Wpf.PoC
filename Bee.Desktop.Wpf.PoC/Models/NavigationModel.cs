namespace Bee.Desktop.Wpf.PoC.Models
{
    public class NavigationModel
    {
        public bool CanExecute { get; set; }
        public string ViewModelName { get; set; }

        public NavigationModel(bool canExecute, string viewModelName)
        {
            CanExecute = canExecute;
            ViewModelName = viewModelName;
        }
    }
}
