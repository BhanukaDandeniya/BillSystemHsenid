namespace BillSystemHsenid.Models
{
    public class Items
    {
        public int Id { get; set; }

        public string? ItemName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }
    }
}
