using ExtraaEdge_WEB_API.DataContext;
using ExtraaEdge_WEB_API.Model;
using ExtraaEdge_WEB_API.Repository.IRepository;
using ExtraaEdge_WEB_API.Services.IServices;

namespace ExtraaEdge_WEB_API.Services.SevicesImpl
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IRepository _IRepo;
    
       public CustomerRepository(IRepository IRepo)
        {
            _IRepo = IRepo;
        }

       

        public List<Customer> GetAllCustomers()
        {
            return _IRepo.GetAllCustomers();
        }

        public object InsertCustomer(Customer cust)
        {
            var CreatedCust = _IRepo.InsertCustomer(cust);
            return CreatedCust;
        }




        public bool UpdateCustomer(int id, Customer updatedcustomers)
        {
            Customer userUpdated = new Customer();
            var existingCustomer = _IRepo.GetCustomerById(id);

            if (existingCustomer == null)
            {
                return false;
            }

            existingCustomer.CustName = updatedcustomers.CustName;
            existingCustomer.CustPhoneNo=updatedcustomers.CustPhoneNo;
            existingCustomer.CustAddress=updatedcustomers.CustAddress;
            existingCustomer.CustEmail=updatedcustomers.CustEmail;
            existingCustomer.CustPassword=updatedcustomers.CustPassword;

          

            _IRepo.UpdateCustomer(existingCustomer);

            return true;
        }

        public bool DeleteCustomer(int id)
        {
            var existingCustomers = _IRepo.GetCustomerById(id);

            if (existingCustomers == null)
            {
                return false;
            }

            _IRepo.DeleteCustomer(existingCustomers);

            return true;
        }

       
        public Customer GetCustomerById(int id)
        {

            return _IRepo.GetCustomerById(id);

        }




    }
}
