using Hotelapp.ViewModels;

namespace Hotelapp.Views;

public partial class ReservationView : ContentPage
{

	private ReservationViewModel _vm = new ReservationViewModel();
	public ReservationView()
	{
        InitializeComponent();
        this.BindingContext = _vm;
    }

    protected override void OnAppearing() {
        base.OnAppearing();
        this._vm.OnShowReservation();
    }
}