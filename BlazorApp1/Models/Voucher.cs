
namespace BlazorApp1.Models{
    public class Vouchers
    {
    
        public int VoucherId { get; set; }
        
        public string? PayeeName { get; set; }
        
        public string? VoucherType { get; set; }
        
        public string? VoucherNumber { get; set; }
        
        public string? VoucherDateDescription { get; set; }
        
        public string? VoucherLocation { get; set; }
        
        public string? ObligationNumber { get; set; }
        
        public string? ObligationDate { get; set; }
        
        public string? CheckNumber { get; set; }
        
        public string? CheckDate { get; set; }
        
        public decimal GrossAmount { get; set; }
        
        public decimal NetAmount { get; set; }
        
        public string? FundDescription { get; set; }
        
        public string? Particulars { get; set; }
        
        public string? Remarks { get; set; }
    }
}
