namespace versta.Models
{
    public record Order
    {
        public long ID { get; set; }
        public Delivery? Delivery { get; set; } = new();
    }
}
