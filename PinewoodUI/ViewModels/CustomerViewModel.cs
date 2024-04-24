
using System.ComponentModel.DataAnnotations;
    

namespace PinewoodUI.Models
{
    public class CustomerViewModel
    {
        [Display(Name="ID")]
        public int CustomerId { get; set; }
        [Display(Name = "Account")]
        public int Accountno { get; set; }
        [Display(Name = "Name")]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
