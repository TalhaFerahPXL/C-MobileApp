namespace PE_Mobile_APP.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Home");
    }
}