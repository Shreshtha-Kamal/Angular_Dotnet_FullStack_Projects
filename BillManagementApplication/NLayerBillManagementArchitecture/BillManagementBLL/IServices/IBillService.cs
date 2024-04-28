using BillManagementBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagementBLL.IServices
{
    public interface IBillService
    {
        public Task<string> AddBill(BillModel bill);
        public Task<List<BillModel>?> GetUserSixMonthBills(string userId);
        public Task<string> PayBill(string billId);
    }
}
