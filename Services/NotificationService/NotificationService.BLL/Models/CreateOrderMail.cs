namespace NotificationService.BLL.Models
{
    public class CreateOrderMail
    {
        public string Email { get; set; } = null!;
        public string Subject { get; set; } = "Your order is accepted";
        public string Message { get; set; } = "Your order is accepted"!;
        public DateTime OrderDate { get; set; }
    }
}
