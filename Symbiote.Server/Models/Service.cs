

namespace Symbiote.Server.Models
{
    public class Service
    {
        private readonly ITodoRepository _repository;

        public Service(ITodoRepository repository)
        {
            _repository = repository;
        }

        public TodoItem GetTodoById(string id)
        {
            // Поиск задачи по ID в базе данных
            return _repository.Find(id);
        }

        public IEnumerable<TodoItem> GetAllTodos()
        {
            return _repository.GetAll();
        }
    }
}
