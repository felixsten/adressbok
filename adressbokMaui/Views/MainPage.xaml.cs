using adressbokMaui.ViewModels;
using System.Collections.ObjectModel;

namespace adressbokMaui
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            
        }

    }

}
