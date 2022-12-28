namespace Messages
{
    public record CreateOrderMessage
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerEmail { get; set; }
    }
}
