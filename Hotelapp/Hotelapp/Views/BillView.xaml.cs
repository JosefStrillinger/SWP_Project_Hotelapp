using Hotelapp.ViewModels;

namespace Hotelapp.Views;

public partial class BillView : ContentPage
{
	private BillViewModel _vm = new BillViewModel();
	public BillView()
	{
		InitializeComponent();
		this.BindingContext = _vm;
	}

    protected override void OnAppearing() {
        base.OnAppearing();
        this._vm.OnShowBill();
    }
}