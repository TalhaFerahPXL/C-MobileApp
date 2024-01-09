using PE_Mobile_APP.Model;

namespace PE_Mobile_APP.Views;

public partial class FavorietPage : ContentPage
{
	public FavorietPage()
	{
		InitializeComponent();
        BindingContext = FavorietenViewModel.Instance;
    }

    private void OnDeleteItem(object sender, EventArgs e)
    {
        if (sender is SwipeItem swipeItem && swipeItem.CommandParameter is Car car)
        {
            // Verwijder de auto uit de lijst
            FavorietenViewModel.Instance.FavorieteAutoLijst.Remove(car);
        }
    }

}