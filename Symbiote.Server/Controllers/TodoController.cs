using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Symbiote.Server.Models;
using Microsoft.EntityFrameworkCore;


namespace Symbiote.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _repository;

        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("all")]
        public IEnumerable<TodoItem> GetAll()
        {
            return _repository.GetAll();
        }
        
        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetTodoById(string id)
        {
            // Получаем сервис задач
            var service = new Service(_repository);

            // Поиск задачи по ID
            var todoItem = service.GetTodoById(id);

            // Проверка, найдена ли задача
            if (todoItem == null)
            {
                return NotFound();
            }

            // Возвращаем найденную задачу
            return Ok(todoItem);
        }

    }
}
