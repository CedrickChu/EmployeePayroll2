using System.Text.Json.Serialization;

namespace BlazorApp1.Models
{
    public class EmployeeInfo
    {
        public string? EmployeeNumber { get; set; }
        public string? FullName { get; set; }
        public string? EmployeePosition { get; set; }
        public int? DetailId { get; set; }
        public decimal? Salary { get; set; }
        public int? DayAbsent { get; set; }
        public int? HourAbsent { get; set; }
        public int? MinuteAbsent { get; set; }
        public decimal? AmountEarned { get; set; }
        public string? PeriodDescription { get; set; }
    }

    public class PayslipDetails
    {
        public string? DeductionDescription { get; set; }
        public decimal? Amount { get; set; }
    }

    public class PayrollModel
    {
        public List<EmployeeInfo>? EmployeeInfo { get; set; }
        
        [JsonPropertyName("Payslip")]
        public List<PayslipDetails>? PayslipDetails { get; set; }
    }

}
