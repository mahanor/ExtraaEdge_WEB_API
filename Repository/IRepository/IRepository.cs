using ExtraaEdge_WEB_API.Model;
using ExtraaEdge_WEB_API.Services.IServices;

namespace ExtraaEdge_WEB_API.Repository.IRepository
{
    public interface IRepository
    {
         List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        
        bool UpdateCustomer(Customer updatedcustomers);
        bool DeleteCustomer(Customer deleteCustomers);
        Customer InsertCustomer(Customer customer);


        List<Sale> GetSalesByDateRange(DateTime fromDate, DateTime toDate);
        decimal GetTotalProfitByDateRange(DateTime fromDate, DateTime toDate);
        decimal GetTotalLossByDateRange(DateTime fromDate, DateTime toDate);



        LoginModel LoginUser(LoginModel loginModel);
       

       
    }
}
