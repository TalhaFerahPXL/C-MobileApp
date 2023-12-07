using AppApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=App;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        [HttpPost("LoginUser")]
        public IActionResult LoginUser([FromBody] LoginModel model)
        {
            if (model == null)
            {
                return BadRequest("Ongeldige inloggegevens");
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Wachtwoord = @Password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", model.Email);
                        command.Parameters.AddWithValue("@Password", model.Wachtwoord);

                        int userCount = (int)command.ExecuteScalar();

                        if (userCount > 0)
                        {
                            return Ok("Inloggen succesvol!");
                        }
                        else
                        {
                            return Unauthorized("Onjuiste inloggegevens.");
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
