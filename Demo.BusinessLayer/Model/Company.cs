using System.ComponentModel.DataAnnotations;

namespace Demo.BusinessLayer.Model
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
