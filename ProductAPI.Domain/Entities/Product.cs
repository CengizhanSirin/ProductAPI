namespace ProductAPI.Domain.Entities
{
    public class Product:BaseEntity<int>
    {
        public string Name { get; set; } = default!;

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
