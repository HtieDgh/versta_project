namespace versta.Models
{
    /// <summary>
    /// DTO для Cargo
    /// </summary>
    public record Cargo
    {
        public long ID { get; set; }
        public decimal Weight { get; set; }
        public List<Delivery> Deliverys { get; set; } = new();
    }
}
