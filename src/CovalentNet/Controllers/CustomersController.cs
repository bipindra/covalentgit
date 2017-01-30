using CovalentNet.Data.Entities;
using CovalentNet.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Cors;

namespace CovalentNet.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("local")]
    public class CustomersController : BaseController<Customer,string>
    {
        public CustomersController(ICustomerRepository orderRepository) : base(orderRepository)
        {

        }
    }
}