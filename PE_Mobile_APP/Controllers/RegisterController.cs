using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace PE_Mobile_APP.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    //public class RegisterController : ControllerBase
    //{
    //    [HttpPost("RegisterUser")]
    //    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=App;Integrated Security=True;Connect Timeout=30;Encrypt=False";
    //    //Data Source=MSI\SQLEXPRESS;Initial Catalog=testApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
    //    public async void RegisterUser(string naam, string email, string password)
    //    {
    //        try
    //        {
    //            using (SqlConnection connection = new SqlConnection(connectionString))
    //            {
    //                await connection.OpenAsync();

    //                string query = "INSERT INTO Users (Naam, Email, Wachtwoord) VALUES (@Naam, @Email, @Password)";

    //                using (SqlCommand command = new SqlCommand(query, connection))
    //                {
    //                    command.Parameters.AddWithValue("@Naam", naam);
    //                    command.Parameters.AddWithValue("@Email", email);
    //                    command.Parameters.AddWithValue("@Password", password);

    //                    int rowsAffected = await command.ExecuteNonQueryAsync();

    //                    if (rowsAffected > 0)
    //                    {
    //                        await Application.Current.MainPage.DisplayAlert("Succes", "Registratie succesvol!", "OK");
    //                    }
    //                    else
    //                    {
    //                        await Application.Current.MainPage.DisplayAlert("Fout", "Registratie mislukt.", "OK");
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            await Application.Current.MainPage.DisplayAlert("Fout", "Er is een fout opgetreden: " + ex.Message, "OK");
    //        }
    //    }
    //}
}
