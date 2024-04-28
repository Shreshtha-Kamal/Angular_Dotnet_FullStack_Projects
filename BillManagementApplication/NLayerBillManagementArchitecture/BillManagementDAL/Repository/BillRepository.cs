using BillManagementDAL.DB;
using BillManagementDAL.IRepository;
using BillManagementDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagementDAL.Repository
{
    public class BillRepository: IBillRepository
    {
        private readonly AppDBContext _appDBContext;
        public BillRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<string> AddBill(Bill bill)
        {
            try
            {
                var newBill= _appDBContext.Bills.Add(bill);
                await _appDBContext.SaveChangesAsync();
                return "Bill Created Successfully";
            }
            catch (Exception ex)        
            {
                return null;
            }
        }

        public async Task<Bill> GetMostRecentBillForUser(string userId)
        {
            // Query bills filtered by UserId and ordered by EndDate in descending order
            var mostRecentBill = await _appDBContext.Bills
                .Where(b => b.UserId == userId)
                .OrderByDescending(b => b.EndDate)
                .FirstOrDefaultAsync();

            return mostRecentBill;
        }

        public async Task<int> GetBasePriceofLoadAllowed(int load)
        {
            var loadData = await _appDBContext.AllowedLoads.FirstOrDefaultAsync(l=>l.LoadCategoryInKW == load);
            var basePrice= loadData.BasePrice;
            return basePrice;
        }

        public async Task<List<Bill>?>GetUserSixMonthBills(string userId)
        {
            var dateSixMonthAgo= DateTime.Today.AddMonths(-6);
            var bills = await _appDBContext.Bills.Where(bill=>bill.UserId == userId && bill.StartDate>=dateSixMonthAgo ).OrderBy(bill=>bill.StartDate).ToListAsync();
            return bills;
        }

        public async Task<Bill> GetBillById(Guid id)
        {
            var bill = await _appDBContext.Bills.FirstOrDefaultAsync(bill => bill.Id == id);
            return bill;
        }

        public async Task<string>UpdateBill(Bill bill)
        {
            _appDBContext.Bills.Update(bill);
            await _appDBContext.SaveChangesAsync();
            return "Bill Paid Successfully";
        }
    }
}
