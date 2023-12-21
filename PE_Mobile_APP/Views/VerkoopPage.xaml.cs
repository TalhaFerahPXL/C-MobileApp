using PE_Mobile_APP.Model;

namespace PE_Mobile_APP.Views;

public partial class VerkoopPage : ContentPage
{
    public Car VerkoopAuto { get; set; }

    public VerkoopPage()
    {
        InitializeComponent();
        VerkoopAuto = new Car(); // Maak een nieuw Auto object
        BindingContext = VerkoopAuto; // Wijs het Auto object toe als BindingContext
    }

    //Bron https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/storage/file-picker?view=net-maui-8.0&tabs=android

    private async void OnUploadPhotoClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Selecteer een afbeelding"
            });

            if (result != null)
            {
                var imageName = Path.GetFileName(result.FullPath);
                var projectImagesPath = Path.Combine(Environment.CurrentDirectory, "Images"); // Het pad binnen je Visual Studio-project

                var imageData = await result.OpenReadAsync();
                using (var stream = new FileStream(projectImagesPath, FileMode.Create))
                {
                    await imageData.CopyToAsync(stream);
                }

                // Toon het pad van de gekopieerde afbeelding in een melding
                await DisplayAlert("Path", $"Foto opgeslagen op: {projectImagesPath}", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fout", $"Fout bij het uploaden van de foto: {ex.Message}", "OK");
        }
    }





    private void OnSaveClicked(object sender, EventArgs e)
    {
        // Doe iets met het VerkoopAuto object, bijvoorbeeld opslaan in een database of verder verwerken
        // ...

        DisplayAlert("Opslaan", $"merk {VerkoopAuto.ImageUrl}", "OK");
    }
}