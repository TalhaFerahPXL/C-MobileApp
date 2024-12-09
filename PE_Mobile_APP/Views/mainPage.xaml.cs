namespace PE_Mobile_APP.Views;

public partial class AanmeldenPage : ContentPage
{
	public AanmeldenPage(AanmeldenViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        



	}

    private async void Button_Clicked(object sender, EventArgs e)
    {

          await Navigation.PushAsync(new Login());
       
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Register());
    }
}
