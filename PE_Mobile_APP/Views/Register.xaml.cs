
using PE_Mobile_APP.Model;
using System.Text;

namespace PE_Mobile_APP.Views;

public partial class Register : ContentPage
{
    public Register()
    {
        InitializeComponent();
        BindingContext = new RegisterViewModel();
       
    }


}