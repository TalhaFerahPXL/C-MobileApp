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
            private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=App;Integrated Security=True;Connect Timeout=30;Encrypt=False"; // Vervang dit met jouw eigen verbindingsstring

            [HttpGet("GetAutos")]
            public IActionResult GetAutos()
            {
                try
                {
                    List<Auto> autos = new List<Auto>();

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "SELECT * FROM Autos"; // Jouw query om alle auto's op te halen

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            SqlDataReader reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                Auto auto = new Auto
                                {
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
        }
    }

}
