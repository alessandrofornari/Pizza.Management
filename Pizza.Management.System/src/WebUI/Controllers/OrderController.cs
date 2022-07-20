using Microsoft.AspNetCore.Mvc;
using Pizza.Management.Application.PizzaManagement;
using System.Threading.Tasks;

namespace Pizza.Management.WebUI.Controllers
{
    public class OrderController : ApiController
    {
        [HttpGet("nextOrder")]
        public async Task<GetOrderQueryResult> GetNextOrder()
            => await Mediator.Send(new GetNextOrderQuery());

        [HttpPost]
        public async Task<CreateOrderCommandResult> Create(CreateOrderCommand command)
            => await Mediator.Send(command);

        //TODO: delivey/complete Oder should be one of the next features
    }
}
