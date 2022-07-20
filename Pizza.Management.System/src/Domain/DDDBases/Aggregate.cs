
namespace Pizza.Management.Domain.DDDBases
{
    public abstract class Aggregate<TKey> : Aggregate where TKey : struct
    {
        public virtual TKey Id { get; protected set; }

        public virtual byte[] Version { get; protected set; }
    }

    public abstract class Aggregate
    {
        public Aggregate()
        { }
    }
}
