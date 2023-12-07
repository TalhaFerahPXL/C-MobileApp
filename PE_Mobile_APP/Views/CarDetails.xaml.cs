using PE_Mobile_APP.Model;

namespace PE_Mobile_APP.Views;

public partial class CarDetails : ContentPage
{
	public CarDetails(Car car)
	{
		InitializeComponent();
        BindingContext = car;
    }

    private async void OnBuyClicked(object sender, EventArgs e)
    {

    }
}