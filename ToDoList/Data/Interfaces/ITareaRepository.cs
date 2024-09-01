using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Data.Interfaces
{
    public interface ITareaRepository
    {
        void AddTasks(Tarea tarea);
        IEnumerable<Tarea> GetTasks();

        Tarea GetTasksById(int id);
        void UpdateTasks(Tarea tarea);
        
        void DeleteTasks (int id);

    }
}
