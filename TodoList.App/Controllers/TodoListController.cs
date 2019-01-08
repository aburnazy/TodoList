using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Core.Model;
using TodoList.Core.Model.Contracts;

namespace TodoList.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoProcessor _todoProcessor;
        private readonly ITodoProvider _todoProvider;

        public TodoListController(ITodoProvider todoProvider, ITodoProcessor todoProcessor)
        {
            this._todoProvider = todoProvider;
            this._todoProcessor = todoProcessor;
        }

        // GET: api/TodoList
        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return _todoProvider.FindAll();
        }

        // GET: api/TodoList/5
        [HttpGet("{id}", Name = "Get")]
        public Todo Get(int id)
        {
            return _todoProvider.FindById(id);
        }

        // POST: api/TodoList
        [HttpPost]
        public void Post([FromBody] Todo value)
        {
            _todoProcessor.Create(value);
        }

        // PUT: api/TodoList/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Todo value)
        {
            _todoProcessor.Update(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _todoProcessor.Delete(id);
        }
    }
}
