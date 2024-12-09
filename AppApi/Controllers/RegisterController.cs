using AppApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=App;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterModel model)
        {
            if (model == null)
            {
                return BadRequest("Ongeldige registratiegegevens");
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string query = "INSERT INTO Users (Naam, Email, Wachtwoord) VALUES (@Naam, @Email, @Password)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Naam", model.naam);
                        command.Parameters.AddWithValue("@Email", model.email);
                        command.Parameters.AddWithValue("@Password", model.wachtwoord);

                        int rowsAffected = await command.ExecuteNonQueryAsync();

                        if (rowsAffected > 0)
                        {
                            return Ok("Registratie succesvol!");
                        }
                        else
                        {
                            return BadRequest("Registratie mislukt.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Er is een fout opgetreden: " + ex.Message);
            }
        }
    }
}
