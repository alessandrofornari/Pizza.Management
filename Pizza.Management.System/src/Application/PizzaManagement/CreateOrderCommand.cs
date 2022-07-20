using MediatR;
using Pizza.Management.Domain.PizzaManagement;
using Pizza.Management.Domain.PizzaManagement.DTO;
using Pizza.Management.Domain.PizzaManagement.Entities;
using Pizza.Management.Domain.PizzaManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Pizza.Management.Application.PizzaManagement
{
    public class CreateOrderCommand : IRequest<CreateOrderCommandResult>
    {
        public int CustomerId { get; set; } //Supposing the customer is registered in the web app

        public List<PizzaNameNumberDTO>  PizzaOrders { get; set; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandResult>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IPizzaRepository pizzaRepository;
        private readonly ICustomerRepository customerRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IPizzaRepository pizzaRepository, ICustomerRepository customerRepository)
        {
            this.orderRepository = orderRepository;
            this.pizzaRepository = pizzaRepository;
            this.customerRepository = customerRepository;
        }

        public async Task<CreateOrderCommandResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            //TODO: Add domain Service
            await Validate(request); //TODO: Add Validators

            var fullOrderPrice = await CalculateTotalPrice(request.PizzaOrders);
            var pendingOrders = await orderRepository.GetAllPendingOrders();

            var order = Order.Create(request.CustomerId);
            await AddPizzaOrders(request.PizzaOrders, order);

            await orderRepository.AddAsync(order);
            await orderRepository.SaveChanges();

            var result = new CreateOrderCommandResult()
            {
                Id = order.Id,
                OrderFullPrice = fullOrderPrice,
                PendingOrdersNumber = pendingOrders.Count()
            };

            return result;
        }

        private async Task Validate(CreateOrderCommand request)
        {
            var customer = await customerRepository.GetByKey(request.CustomerId); //used for validtion purpose

            var totalPizzaNumber = request.PizzaOrders.Sum(x => x.Number);

            if (totalPizzaNumber < 1)
                throw new ArgumentException("No Pizzas ordered"); //TODO: manage maybe in a middleware
        }

        private async Task<double> CalculateTotalPrice(List<PizzaNameNumberDTO> pizzaOrders)
        {
            var fullOrderPrice = 0.0;

            foreach (var pizzaOrder in pizzaOrders)
            {
                var pizza = await pizzaRepository.GetByName(pizzaOrder.Name);
                fullOrderPrice += pizzaOrder.Number * pizza.Price;
            }

            return fullOrderPrice;
        }

        private async Task AddPizzaOrders(List<PizzaNameNumberDTO> pizzaOrders, Order order)
        {
            foreach (var pizzaOrder in pizzaOrders)
            {
                var pizza = await pizzaRepository.GetByName(pizzaOrder.Name);

                var pizzaOrderDto = new PizzaNumberDTO()
                {
                    PizzaId = pizza.Id,
                    Number = pizzaOrder.Number
                };

                order.AddPizzaOrder(pizzaOrderDto);
            }
        }
    }

    public class CreateOrderCommandResult
    {
        public int Id { get; set; }
        public double OrderFullPrice { get; set; }
        public int PendingOrdersNumber { get; set; }
    }
}
