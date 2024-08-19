using InstitutoApp.ViewModels.Commons;

namespace InstitutoApp.Views;

public partial class CarrerasView : ContentPage
{
	public CarrerasView()
	{
		InitializeComponent();
		BindingContext = new CarrerasViewModel();
	}
}