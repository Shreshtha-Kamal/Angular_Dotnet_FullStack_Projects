using AutoMapper;
using BillManagementBLL.IServices;
using BillManagementBLL.Models;
using BillManagementDAL.IRepository;
using BillManagementDomain.Entities;
using BillManagementDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagementBLL.Services
{
    public class BillService: IBillService
    {
        private IBillRepository _billRepository;
        private Mapper _billMapper;
        public BillService(IBillRepository billRepository)
        {
            _billRepository = billRepository;
            var _configBill = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Bill, BillModel>().ReverseMap();
            });
            this._billMapper = new Mapper(_configBill);
        }

        public async Task<string> AddBill(BillModel bill)
        {
            var recentBillOfUser = await _billRepository.GetMostRecentBillForUser(bill.UserId);
            if(recentBillOfUser == null)
            {
                var basePriceForBillAllowedLoad = await _billRepository.GetBasePriceofLoadAllowed(bill.LoadAllowed);
                Bill billEntity = new Bill()
                {
                    Id =  Guid.NewGuid(),
                    UnitsConsumed = bill.UnitsConsumed,
                    UserId = bill.UserId,
                    PerUnitPrice = bill.PerUnitPrice,
                    LoadAllowed = bill.LoadAllowed,
                    StartDate = bill.StartDate,
                    EndDate = bill.EndDate,
                    DueDate = bill.DueDate,
                    LateCharge = bill.LateCharge,
                    Status = BillStatus.Pending,
                    TotalAmount = bill.UnitsConsumed * bill.PerUnitPrice + basePriceForBillAllowedLoad
                };
                return await _billRepository.AddBill(billEntity);
            }
            if (recentBillOfUser.EndDate>bill.StartDate)
            {
                return null;
            }
            var BasePriceForBillAllowedLoad = await _billRepository.GetBasePriceofLoadAllowed(bill.LoadAllowed);
            var BillEntity = new Bill()
            {
                Id = Guid.NewGuid(),
                UnitsConsumed = bill.UnitsConsumed,
                UserId = bill.UserId,
                PerUnitPrice = bill.PerUnitPrice,
                LoadAllowed = bill.LoadAllowed,
                StartDate = bill.StartDate,
                EndDate = bill.EndDate,
                DueDate = bill.DueDate,
                LateCharge = bill.LateCharge,
                Status = BillStatus.Pending,
                TotalAmount = bill.UnitsConsumed * bill.PerUnitPrice + BasePriceForBillAllowedLoad
            };
            return await _billRepository.AddBill(BillEntity);
        }

        public async Task<List<BillModel>?> GetUserSixMonthBills(string userId)
        {
            var bills = await _billRepository.GetUserSixMonthBills(userId);
            var sixMonthBills= _billMapper.Map<List<Bill>, List<BillModel>>(bills);
            if(sixMonthBills==null)
            {
                return null;
            }
            return sixMonthBills;
        }

        public async Task<string> PayBill(string billId)
        {
            var bill= await _billRepository.GetBillById(Guid.Parse(billId));
            if (bill == null)
            {
                return null;
            }
            bill.PaidOn= DateTime.Now;
            if (bill.DueDate >= DateTime.Now)
            {
                bill.Status = BillStatus.Paid;
            }
            else
            {
                bill.Status = BillStatus.Due_Date_Passed;
            }
            var response = await _billRepository.UpdateBill(bill);
            return response;
        }
    }
}
