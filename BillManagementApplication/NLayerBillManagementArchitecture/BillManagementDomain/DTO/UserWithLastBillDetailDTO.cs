using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagementDomain.DTO
{
    public class UserWithLastBillDetailDTO
    {
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public string? Pincode { get; set; }
        public int? LoadAllowed { get; set; }
        public int? LatestBillAmount { get; set; }
        public string? BillStatus { get; set; }
    }
}
