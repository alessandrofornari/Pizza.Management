using Pizza.Management.Domain.DDDBases;

namespace Pizza.Management.Domain.PizzaManagement.Entities
{
    public class Customer : Aggregate<int>
    {
        public virtual string Name { get; protected set; }

        protected Customer() { }

        public static Customer Create(string name)
        {
            return new Customer
            {
                Id = 0,
                Name = name
            };
        }
    }
}
