using System.Collections.Generic;
using System.Threading.Tasks;
using CovalentNet.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using CovalentNet.Data.Entities;

namespace CovalentNet.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController :BaseController<Order>
    {
        public OrdersController(IOrderRepository orderRepository):base(orderRepository)
        {
            
        }
    }
}