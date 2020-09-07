using Shop.Domain.Commands.Request;
using Shop.Domain.Commands.Response;
namespace Shop.Domain.Handlers
{
    public interface ICreateCustomerHandler
    {
        CreateCustomerResponse Handle(CreateCustomerRequest request);
    }
}