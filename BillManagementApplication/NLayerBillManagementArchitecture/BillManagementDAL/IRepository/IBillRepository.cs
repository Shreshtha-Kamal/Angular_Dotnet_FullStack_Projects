using BillManagementDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagementDAL.IRepository
{
    public interface IBillRepository
    {
        public Task<string> AddBill(Bill bill);
        public Task<Bill> GetMostRecentBillForUser(string userId);
        public Task<int> GetBasePriceofLoadAllowed(int load);
        public Task<List<Bill>> GetUserSixMonthBills(string userId);
        public Task<Bill>GetBillById(Guid id);
        public Task<string> UpdateBill(Bill bill);
    }
}
