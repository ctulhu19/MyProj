using System.Collections.Generic;

namespace Symbiote.Server.Models
{
    public interface ITodoRepository
    {
        
        IEnumerable<TodoItem> GetAll();
        TodoItem Find(string id);
    }
}
