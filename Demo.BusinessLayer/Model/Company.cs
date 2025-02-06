using System.ComponentModel.DataAnnotations;

namespace Demo.BusinessLayer.Model
{
    public class Company
    {
        [Required]
        public string CompanyName { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
