using Pizza.Management.Domain.DDDBases;
using Pizza.Management.Domain.PizzaManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pizza.Management.Domain.PizzaManagement.Entities
{
    public class Order : Aggregate<int>
    {
        //TODO: Add ValueObjects
        public virtual string? Code { get; protected set; }

        public virtual int CustomerId { get; protected set; }

        public virtual bool IsDelivered { get; protected set; }

        private ICollection<PizzaOrder> _pizzas = new List<PizzaOrder>();
        public virtual IEnumerable<PizzaOrder> Pizzas => _pizzas ??= new List<PizzaOrder>();

        protected Order()
        {
            _pizzas = new List<PizzaOrder>();
            IsDelivered = false;
        }

        public static Order Create(int customerId)
        {
            return new Order
            {
                Id = 0,
                CustomerId = customerId,
                Code = Guid.NewGuid().ToString(),
                IsDelivered = false
            };
        }

        public PizzaOrder AddPizzaOrder(PizzaNumberDTO pizzaDto)
        {
            var pizzaOrder = PizzaOrder.Create(Id, pizzaDto);
            _pizzas.Add(pizzaOrder);

            return pizzaOrder;
        }

        //TODO: delivey/complete Oder should be a next feature
    }
}
