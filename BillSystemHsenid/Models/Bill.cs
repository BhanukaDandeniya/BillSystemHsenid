namespace BillSystemHsenid.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        public DateTime BillDateTime { get; set; } = DateTime.Now;
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; } 
        public decimal Tax { get; set; } = 12;
        public decimal TotalAmount { get; set; }

        public List<BillItem> BillItems { get; set; } = new List<BillItem>();
    }
}
