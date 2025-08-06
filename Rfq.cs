namespace sample1.Models
{
    public class Rfq
    {
        public int Id { get; set; }
        public string RfqId { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
    }
}