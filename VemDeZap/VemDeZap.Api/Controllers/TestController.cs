using Microsoft.AspNetCore.Mvc;

namespace VemDeZap.Api.Controllers
{
    public class TestController : Controller
    {
        public string Get()
        {
            return "1.0.0";
        }
    }
}