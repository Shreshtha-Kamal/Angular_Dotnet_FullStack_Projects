using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagementBLL.Models
{
    public class BillModel
    {
        public Guid? Id { get; set; }
        [Required]
        public int UnitsConsumed { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int PerUnitPrice { get; set; }
        [Required]
        public int LoadAllowed { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public int LateCharge { get; set; }
        public string? Status { get; set; }
        public int? TotalAmount { get; set; }
        public DateTime? PaidOn {  get; set; }
    }
}
