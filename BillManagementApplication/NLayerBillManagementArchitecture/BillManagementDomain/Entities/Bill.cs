using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillManagementDomain.Enums;

namespace BillManagementDomain.Entities
{
    public class Bill
    {
        [Key]
        public Guid Id { get; set; }
        public int UnitsConsumed { get; set; }
        [Required]
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
        public int PerUnitPrice { get; set; }
        public int LoadAllowed { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DueDate { get; set; }
        public int LateCharge { get; set; }
        public BillStatus Status { get; set; }
        public int TotalAmount { get; set; }
        public DateTime? PaidOn { get; set; }
    }
}
