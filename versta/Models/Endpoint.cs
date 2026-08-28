namespace versta.Models
{
    /// <summary>
    /// DTO для Endpoint
    /// </summary>
    public record Endpoint
    {
        public long ID { get; set; } = default;
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<Delivery> Deliverys_recipient { get; set; } = new();
        public List<Delivery> Deliverys_sender { get; set; } = new();
    }
}
