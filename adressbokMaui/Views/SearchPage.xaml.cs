using adressbokMaui.ViewModels;
namespace adressbokMaui.Views;

public partial class SearchPage : ContentPage
{
	public SearchPage(SearchViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}