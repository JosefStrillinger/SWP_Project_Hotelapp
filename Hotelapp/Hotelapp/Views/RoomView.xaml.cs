using Hotelapp.ViewModels;

namespace Hotelapp.Views;

public partial class RoomView : ContentPage
{
	private RoomViewModel vm; // = new RoomViewModel();
	public RoomView()
	{
        this.vm = new RoomViewModel();
        this.BindingContext = vm;
        InitializeComponent();
		
	}

	protected override void OnAppearing() {
		base.OnAppearing();
		this.vm.OnShowRooms();
	}
}