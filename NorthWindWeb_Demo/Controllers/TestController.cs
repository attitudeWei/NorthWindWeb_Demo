using Microsoft.AspNetCore.Mvc;

namespace NorthWindWeb_Demo.Controllers
{
    public class TestController:ControllerBase
    {
        [Route("test")]
        public IActionResult Get()
        {
            return Ok("Ok");
        }
    }
}
