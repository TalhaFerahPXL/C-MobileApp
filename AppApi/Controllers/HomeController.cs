using Microsoft.AspNetCore.Mvc;
using AppApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


namespace AppApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    namespace JouwProject.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class HomeController : ControllerBase
        {
            private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=App;Integrated Security=True;Connect Timeout=30;Encrypt=False";

            //Haalt alle autos van de database en voegt ze toe in een list
            [HttpGet("GetAutos")]
            public IActionResult GetAutos()
            {
                try
                {
                    List<Auto> autos = new List<Auto>();

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "SELECT * FROM Autos";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            SqlDataReader reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                Auto auto = new Auto
                                {
                                    AutoId = Convert.ToInt32(reader["AutoId"]),
                                    Make = reader["Make"].ToString(),
                                    
                                    Price = Convert.ToDecimal(reader["Price"]),
                                    Year = Convert.ToInt32(reader["Year"]),
                                    ImageUrl = reader["ImageUrl"].ToString(),
                                    Kilometers = reader["Kilometers"].ToString(),
                                    Description = reader["Description"].ToString()
                                }; 

                                autos.Add(auto);
                            }

                            reader.Close();

                            if (autos.Count > 0)
                            {
                                return Ok(autos);
                            }
                            else
                            {
                                return NotFound("Geen auto's gevonden in de database.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Er is een fout opgetreden: " + ex.Message);
                }
            }

            //HttpPost methode om autos toe te voegen in de database
            [HttpPost("addAuto")]
            public async Task<IActionResult> addAuto([FromBody] Auto auto)
            {

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        await connection.OpenAsync();

                        string query = "INSERT INTO Autos (Make, Price, Year, ImageUrl, Kilometers, Description) VALUES (@Make, @Price, @Year, @ImageUrl, @Kilometers, @Description)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            //Parameters voorkomen sql injectie
                            command.Parameters.AddWithValue("@Make", auto.Make);
                            command.Parameters.AddWithValue("@Price", auto.Price);
                            command.Parameters.AddWithValue("@Year", auto.Year);
                            command.Parameters.AddWithValue("@ImageUrl", auto.ImageUrl);
                            command.Parameters.AddWithValue("@Kilometers", auto.Kilometers);
                            command.Parameters.AddWithValue("@Description", auto.Description);



                            int rowsAffected = await command.ExecuteNonQueryAsync();

                            if (rowsAffected > 0)
                            {
                                return Ok("Auto is succesvol toegevoegd");
                            }
                            else
                            {
                                return BadRequest("Kan auto niet toevoegen");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Er is een fout opgetreden: " + ex.Message);
                }
            }


            [HttpDelete]
            public async Task<IActionResult> DeleteCar(int id)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        await connection.OpenAsync();

                        string query = "DELETE FROM Autos WHERE AutoId = @AutoId";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@AutoId", id);

                            int rowsAffected = await command.ExecuteNonQueryAsync();

                            if (rowsAffected > 0)
                            {
                                return NoContent(); 
                            }
                            else
                            {
                                return NotFound(); 
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "An error occurred: " + ex.Message);
                }
            }


        }
    }

}
