using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopping.Domain.Commands.Request;
using Shopping.Domain.Commands.Response;

namespace Shopping.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public Task<CreateCustomerResponse> Post(
            [FromServices] IMediator mediator, 
            [FromBody]CreateCustomerRequest command
            )
        {
            return mediator.Send(command);
        }
    }
}
