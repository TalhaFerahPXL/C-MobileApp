using Newtonsoft.Json;
using PE_Mobile_APP.Model;
using System.Security.Policy;
using System.Text;
using System.Web.Http;

namespace PE_Mobile_APP.Views;

public partial class VerkoopPage : ContentPage
{
   
    public Car VerkoopAuto { get; set; }


    public VerkoopPage()
    {
        InitializeComponent();
        VerkoopAuto = new Car(); 
        BindingContext = VerkoopAuto; 
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

                string staticPad = $"/data/user/0/com.companyname.PE_Mobile_APP/files/Images/{result.FileName}";

                VerkoopAuto.ImageUrl = staticPad;
                PreviewImage.Source = staticPad;

                // Bestand lezen als een byte array
                var photoStream = await result.OpenReadAsync();
                var photoBytes = new byte[photoStream.Length];
                await photoStream.ReadAsync(photoBytes.AsMemory(0, (int)photoStream.Length));

                // Het pad naar de map 'Images' verkrijgen
                var imageFolder = FileSystem.AppDataDirectory + "/Images";
                var imagePath = Path.Combine(imageFolder, result.FileName);

                // Controleer of de map 'Images' bestaat, zo niet, maak deze aan
                if (!Directory.Exists(imageFolder))
                    Directory.CreateDirectory(imageFolder);

                // Schrijf de byte-array van de foto naar het bestand in de map 'Images'
                File.WriteAllBytes(imagePath, photoBytes);

                
                
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fout", $"Fout bij het uploaden van de foto: {ex.Message}", "OK");
        }
    }




    

    private async void OnSaveClicked(object sender, EventArgs e)
    {

        try
        {
            HttpClient client = new HttpClient();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(VerkoopAuto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("http://10.0.2.2:5084/Home/addAuto", content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Car data added successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to add car data. Status code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

    }
}