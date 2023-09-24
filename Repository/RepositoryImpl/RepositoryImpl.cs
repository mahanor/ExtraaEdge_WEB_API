using ExtraaEdge_WEB_API.DataContext;
using ExtraaEdge_WEB_API.Model;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace ExtraaEdge_WEB_API.Repository.RepositoryImpl
{
    public class RepositoryImpl : IRepository.IRepository
    {
        private readonly CollectionContext _ctx;
        public RepositoryImpl(CollectionContext ctx)
        {
            _ctx = ctx;
        }


        #region Customer
        public Customer InsertCustomer(Customer customer)
        {
            try
            {
                _ctx.customers.Add(customer);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return customer;
        }
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            customers = _ctx.customers.ToList();
            return customers;
        }

        public Customer GetCustomerById(int id)
        {
            return _ctx.customers.FirstOrDefault(u => u.CustId == id);
        }


        public bool UpdateCustomer(Customer updatedcustomers)
        {
            _ctx.customers.Update(updatedcustomers);
            _ctx.SaveChanges();
            return true;
        }


        public bool DeleteCustomer(Customer deleteCustomers)
        {
            _ctx.customers.Remove(deleteCustomers);
            _ctx.SaveChanges();
            return true;
        }


        #endregion

        #region Sales

        public List<Sale> GetSalesByDateRange(DateTime fromDate, DateTime toDate)
        {
            List<Sale> sales = new List<Sale>();

            sales = _ctx.sales.Where(s => s.SaleDate >= fromDate && s.SaleDate <= toDate).ToList();

            return sales;
        }

        public decimal GetTotalLossByDateRange(DateTime fromDate, DateTime toDate)
        {
            decimal totalRevenue = _ctx.sales.Sum(s => s.SaleAmount);
            decimal totalCost = _ctx.sales.Sum(s => s.DiscountApplied);
            return totalRevenue - totalCost;

        }

        public decimal GetTotalProfitByDateRange(DateTime fromDate, DateTime toDate)
        {
            decimal totalRevenue = _ctx.sales.Sum(s => s.SaleAmount);

            decimal totalCost = _ctx.sales.Sum(s => s.DiscountApplied);

            decimal TotalProfit = totalRevenue - totalCost;

            return TotalProfit;
        }

        #endregion


        #region Loginusers
        public LoginModel LoginUser(LoginModel loginModel)
        {
            LoginModel loginResult = _ctx.login
                .SingleOrDefault(T => T.StoreOwnerName == loginModel.StoreOwnerName && T.Password == loginModel.Password);

            return loginResult;
        }



        #endregion
    }
}
