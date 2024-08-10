using Newtonsoft.Json;
using PE_Mobile_APP.Model;
using System.Security.Policy;
using System.Text;
using System.Web.Http;
using Azure.Storage.Blobs;
using Microsoft.Maui.Storage;
using Azure.Storage.Blobs.Models;

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
                var photoStream = await result.OpenReadAsync();

                string connectionString = "DefaultEndpointsProtocol=https;AccountName=pemobileapp;AccountKey=nXpkgkPDCv/e2t1hURJJcA5pwXJTFmC2AfZI0mQqkET2lxvdp/ikv/95eX3ypxNRSIzKmu4Sug53+AStDoS6yg==;EndpointSuffix=core.windows.net";
                string containerName = "mobileappcontainer";

                var blobContainerClient = new BlobContainerClient(connectionString, containerName);

                await blobContainerClient.CreateIfNotExistsAsync();

                var blobClient = blobContainerClient.GetBlobClient(result.FileName);

                var blobHttpHeaders = new BlobHttpHeaders
                {
                    ContentType = "image/jpeg" 
                };

                
                await blobClient.UploadAsync(photoStream, new BlobUploadOptions
                {
                    HttpHeaders = blobHttpHeaders
                });

                
                var blobUrl = blobClient.Uri.AbsoluteUri;

                
                VerkoopAuto.ImageUrl = blobUrl;
                PreviewImage.Source = blobUrl; 
                lblPreview.IsVisible = true;
                PreviewImage.IsVisible = true;
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

        await DisplayAlert("Succes", "Je auto is succesvol gepubliceerd!", "OK");


    }
}