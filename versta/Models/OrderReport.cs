namespace versta.Models
{
    /// <summary>
    /// DTO для отчета о заказе (включая его ID)
    /// </summary>
    public record OrderReport
    {
        public long OrderID { get; set; }
        public DateOnly Date { get; set; }
        public string SenderCity { get; set; } = string.Empty;
        public string SenderAddress { get; set; } = string.Empty;
        public string RecipientCity { get; set; } = string.Empty;
        public string RecipientAddress { get; set; } = string.Empty;
        public decimal Weight { get; set; }
    }
}
