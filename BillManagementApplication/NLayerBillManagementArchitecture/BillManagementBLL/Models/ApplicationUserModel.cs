using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagementBLL.Models
{
    public class ApplicationUserModel
    {
        public Guid? Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string AlternatePhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        public string? Role { get; set; }
        [Required]
        public string Pincode { get; set; }
        
        public int? LoadAllowed { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
