using Hotelapp.ViewModels;

namespace Hotelapp.Views;

public partial class RegisterView : ContentPage
{

	private RegisterViewModel _vm = new RegisterViewModel();
	public RegisterView()
	{
		InitializeComponent();
		this.BindingContext = _vm;
	}
}