namespace ProductAPI.Domain.Entities
{
    public class BaseEntity<TId>
    {
        public TId Id { get; set; }
    }
}
