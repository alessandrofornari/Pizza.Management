using Pizza.Management.Domain.DDDBases;
using Pizza.Management.Domain.PizzaManagement.DTO;

namespace Pizza.Management.Domain.PizzaManagement.Entities
{
    public class PizzaOrder : Entity<int>
    {
        //TODO: Add ValueObjects
        public virtual int OrderId { get; protected set; }
        public virtual int PizzaId { get; protected set; }
        public virtual int Number { get; protected set; }

        protected PizzaOrder() { }

        public static PizzaOrder Create(int orderId, PizzaNumberDTO pizzaDto)
        {
            return new PizzaOrder
            {
                Id = 0,
                OrderId = orderId,
                PizzaId = pizzaDto.PizzaId,
                Number = pizzaDto.Number
            };
        }
    }
}
