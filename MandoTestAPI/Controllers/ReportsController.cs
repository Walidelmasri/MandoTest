using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dapper;
using MandoTestAPI.Models;


[Route("api/[controller]")]
[ApiController]
public class ReportsController : ControllerBase
{
    private readonly string _connectionString;

    public ReportsController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    [HttpGet("class-report")]
    public async Task<IActionResult> GetClassReport()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var results = await connection.QueryAsync<ClassReport>(
                "EXEC ClassRegistrationReport");
            return Ok(results);
        }
    }
}

