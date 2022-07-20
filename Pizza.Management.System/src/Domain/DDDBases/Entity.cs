

namespace Pizza.Management.Domain.DDDBases
{
    public abstract class Entity<TKey> : Aggregate where TKey : struct
    {
        public virtual TKey Id { get; protected set; }
    }
}
