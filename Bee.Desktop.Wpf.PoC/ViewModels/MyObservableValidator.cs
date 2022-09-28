using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bee.Desktop.Wpf.PoC.ViewModels
{
    public abstract class MyObservableValidator : ObservableValidator
    {
        public async Task Authorize()
        {
            MessageBox.Show("Authorized");
        }

        public bool AuthorizeCanExecute()
        {
            return !HasErrors;
        }
    }
}
