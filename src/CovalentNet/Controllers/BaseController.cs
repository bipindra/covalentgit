using System.Collections.Generic;
using System.Threading.Tasks;
using CovalentNet.Data.Entities;
using CovalentNet.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CovalentNet.Controllers
{
    public abstract class BaseController<T> : Controller where T : class, IEntityBase<int>
    {
        private readonly IEntityBaseRepository<T, int> _repository;
        protected BaseController(IEntityBaseRepository<T, int> repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public virtual async Task<IEnumerable<T>> Get(int? pageSize,int? pageNumber)
        {
            var list = await _repository.GetAllAsync();
            if (pageSize != null && pageNumber != null)
            {
                return list.Skip(pageNumber.Value*pageSize.Value).Take(pageSize.Value);
            }
            else
            {
                return list;
            }
        }
    }
}