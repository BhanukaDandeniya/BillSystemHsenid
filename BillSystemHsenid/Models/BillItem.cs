namespace BillSystemHsenid.Models
{
    public class BillItem
    {
        public int Id { get; set; }

        public int BillId { get; set; }
        public int ItemId { get; set; }

        public string? ItemName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }



       
       
    }
}
