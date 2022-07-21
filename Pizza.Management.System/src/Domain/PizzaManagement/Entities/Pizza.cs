using Pizza.Management.Domain.DDDBases;


namespace Pizza.Management.Domain.PizzaManagement.Entities
{
    public class Pizza : Aggregate<int>
    {
        public virtual string? Name { get; protected set; }

        public virtual double Price { get; protected set; }

        protected Pizza() { }
    }
}
