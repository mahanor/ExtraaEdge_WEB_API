using ExtraaEdge_WEB_API.Model;

namespace ExtraaEdge_WEB_API.Services.IServices
{
    public interface ICustomerRepository
    {
        //Customer Insert(Customer customer);
        List<Customer> GetAllCustomers();
        object InsertCustomer(Customer cust);

        Customer GetCustomerById(int id);


        bool UpdateCustomer(int id, Customer updatedCustomer);
        bool DeleteCustomer(int id);
    }
}
