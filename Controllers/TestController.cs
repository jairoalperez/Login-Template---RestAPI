using LoginTemplate_RestAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    // TEST API CONNECTION
    [HttpGet()]
    public IActionResult TestAPI()
    {
        return Ok(Messages.API.Working);
    }
}