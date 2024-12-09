using AppApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AppApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SettingsController : Controller
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=App;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        [HttpPost("ChangeName")]
        public IActionResult ChangeName([FromBody] Settings settings)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Users SET Naam = @Naam WHERE UserId = @UserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", settings.UserId);
                    command.Parameters.AddWithValue("@Naam", settings.Naam);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                        return Ok("Naam is bijgewerkt.");
                    else
                        return NotFound("Gebruiker niet gevonden.");
                }
            }
        }
    }
}
