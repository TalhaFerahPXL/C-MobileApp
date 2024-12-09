using Microsoft.Maui.ApplicationModel.Communication;
using PE_Mobile_APP.Model;
using System.Text;

namespace PE_Mobile_APP.Views;

public partial class Login : ContentPage
{
    public LoginViewModel ViewModel { get; set; }

    public Login()
    {
        InitializeComponent();
        ViewModel = new LoginViewModel();
        BindingContext = ViewModel;
    }

    public Login(string userEmail)
    {
        InitializeComponent();
        ViewModel = new LoginViewModel();
        BindingContext = ViewModel;
        email.Text = userEmail;
    }

}