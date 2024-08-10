using AppApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AppApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavorietController : ControllerBase
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=App;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        [HttpPost("AddCarToFavorite")]
        public async Task<IActionResult> AddCarToFavorite(FavorietModel model)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string query = "INSERT INTO UserFavorites (UserId, AutoId) VALUES (@UserId, @AutoId);";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", model.userId);
                        command.Parameters.AddWithValue("@AutoId", model.autoId);

                        int result = await command.ExecuteNonQueryAsync();

                        if (result > 0)
                        {
                            return Ok("Auto succesvol toegevoegd aan favorieten.");
                        }
                        else
                        {
                            return BadRequest("Geen rijen toegevoegd, controleer de input data.");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                return StatusCode(500, "Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server error: " + ex.Message);
            }
        }

        [HttpDelete("RemoveCarFromFavorite")]
        public async Task<IActionResult> RemoveCarFromFavorite(int userId, int autoId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string query = "DELETE FROM UserFavorites WHERE UserId = @UserId AND AutoId = @AutoId;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@AutoId", autoId);

                        int result = await command.ExecuteNonQueryAsync();

                        if (result > 0)
                        {
                            return Ok("Auto succesvol verwijderd uit favorieten.");
                        }
                        else
                        {
                            return NotFound("Geen favoriete auto gevonden met opgegeven UserId en AutoId.");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                return StatusCode(500, "Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server error: " + ex.Message);
            }
        }

        [HttpGet("GetFavoriteCars")]
        public async Task<IActionResult> GetFavoriteCars([FromQuery] int userId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string query = @"
                SELECT Autos.AutoId, Make, Price, Year, ImageUrl, Kilometers, Description
                FROM Autos
                JOIN UserFavorites ON Autos.AutoId = UserFavorites.AutoId
                WHERE UserFavorites.UserId = @UserId;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        List<object> favoriteCars = new List<object>();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                favoriteCars.Add(new
                                {
                                    AutoId = reader["AutoId"],
                                    Make = reader["Make"].ToString(),
                                    Price = reader["Price"],
                                    Year = reader["Year"],
                                    ImageUrl = reader["ImageUrl"].ToString(),
                                    Kilometers = reader["Kilometers"],
                                    Description = reader["Description"].ToString()
                                });
                            }
                        }

                        if (favoriteCars.Count > 0)
                        {
                            return Ok(favoriteCars);
                        }
                        else
                        {
                            return NotFound("Geen favoriete auto's gevonden voor deze gebruiker.");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                return StatusCode(500, "Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server error: " + ex.Message);
            }
        }


    }

}
