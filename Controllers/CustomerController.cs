using ExtraaEdge_WEB_API.Model;
using ExtraaEdge_WEB_API.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtraaEdge_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _ICust;

        public CustomerController(ICustomerRepository iCust)
        {
            _ICust = iCust;
        }

        #region Customers

        [HttpPost("InsertCustomers")]
        public IActionResult InsertCustomer(Customer cust)
        {

            var Customer = _ICust.InsertCustomer(cust);
            return Ok(Customer);

        }




        [HttpGet("GetCustomersById")]
        public IActionResult GetCustomersById(int id)
        {
            var customer = _ICust.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPut("UpdateCustomersById")]
        public IActionResult UpdateUser(int id, [FromBody] Customer updatedCustomers)
        {
            var isUpdated = _ICust.UpdateCustomer(id, updatedCustomers);

            if (isUpdated)
            {
                return Ok("User Updated Successfully");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("DeleteCustomersById")]
        public IActionResult DeleteCustomersById(int id)
        {
            var isDeleted = _ICust.DeleteCustomer(id);

            if (isDeleted)
            {
                return Ok("User Deleted Successfully");
            }
            else
            {
                return NotFound();
            }
        }



        [HttpGet("ShowAllCustomers")]
        public IActionResult GetAllCustomers()
        {

            var customers = _ICust.GetAllCustomers();

            return Ok(customers);
        }

        #endregion
    }
}
