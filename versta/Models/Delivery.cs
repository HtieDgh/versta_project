namespace versta.Models
{
    public record Delivery
    {
        public long CargoID { get; set; }
        public long OrderID { get; set; }
        public long SenderID { get; set; }
        public long RecipientID { get; set; }
        public DateOnly Date{ get; set; }

        //Навигационое свойство
        public Order? Order{ get; set; }
        //Навигационое свойство
        public Endpoint? SenderEndpoint { get; set; }
        public Endpoint? RecipientEndpoint { get; set; }
        //Навигационое свойство
        public Cargo? Cargo{ get; set; }

    }
}
