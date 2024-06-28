using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace Symbiote.Server.Models
{
    public class TodoRepository : ITodoRepository
    {
        
        private readonly Context _context;


        public TodoRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            // Возвращаем все задачи из базы данных
            return _context.Items.ToList();
        }

        public TodoItem Find(string id)
        {
            //поиск
            return _context.Items.FirstOrDefault(t => t.Id == id);
                
            
        }
    }
}
