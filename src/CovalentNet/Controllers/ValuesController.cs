using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovalentNet.Data;
using CovalentNet.Data.Entities;
using CovalentNet.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CovalentNet.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public ValuesController(IOrderRepository orderRepository )
        {
            _orderRepository = orderRepository;
            
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            try
            {
                return await _orderRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                
            }
            return new List<Order>();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
