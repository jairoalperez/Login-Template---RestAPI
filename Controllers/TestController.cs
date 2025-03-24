using LoginTemplate_RestAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    // DB CONTEXT DEFINITION
    private readonly AppDbContext _dbContext;
    public TestController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // TEST API CONNECTION
    [HttpGet()]
    public IActionResult TestAPI()
    {
        return Ok(Messages.API.Working);
    }

    // TEST DATABASE ENDPOINT
    [HttpGet("database")]
    public async Task<IActionResult> TestDatabaseConnection()
    {
        try
        {
            var result = await _dbContext.Database.ExecuteSqlRawAsync("SELECT 1");
            if (result == -1)
                return Ok(Messages.Database.ConnectionSuccess);
            
            return Problem(Messages.Database.ConnectionFailed);
        }
        catch (Exception ex)
        {
            return Problem(Messages.Database.ConnectionFailed, ex.Message);
        }
    }
}