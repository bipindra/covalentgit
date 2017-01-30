using System.Collections.Generic;
using System.Threading.Tasks;
using CovalentNet.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using CovalentNet.Data.Entities;
using Microsoft.AspNetCore.Cors;

namespace CovalentNet.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("local")]
    public class OrdersController :BaseController<Order,int>
    {
        public OrdersController(IOrderRepository orderRepository):base(orderRepository)
        {
            
        }
    }
}