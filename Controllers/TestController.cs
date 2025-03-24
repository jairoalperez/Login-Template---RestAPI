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

    
}