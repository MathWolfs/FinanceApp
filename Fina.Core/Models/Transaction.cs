namespace Fina.Core.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public String Title { get; set; } = String.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? PaidOrReceivedAt { get; set; }

    }
} 