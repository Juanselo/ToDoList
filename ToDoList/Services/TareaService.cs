using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data.Interfaces;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class TareaService
    {
        private readonly ITareaRepository _tareaRepository;

        // Constructor que recibe un repositorio de tareas
        public TareaService(ITareaRepository tareaRepository)
        {
            _tareaRepository = tareaRepository; // Se inicializa el repositorio
        }

        // Metodo para agregar una nueva tarea
        public void AgregarTarea(string descripcion, DateTime? fechaLimite)
        {
            // Verifica que la descripción no esté vacía o nula
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException("La descripcion de la tarea no puede estar vacia", nameof(descripcion));
            }
            // Crea una nueva tarea con los datos con los datos 
            var nuevaTarea = new Tarea
            {
                Descripcion = descripcion,
                FechaLimite = fechaLimite,
                Completada = false
            };

            _tareaRepository.AddTasks(nuevaTarea);
            Console.WriteLine($"Tarea agregada con exito: {nuevaTarea.Descripcion}, ID: {nuevaTarea.Id}");
        }
        // Método para listar todas las tareas
        public void ListarTareas()
        {
            // Obtiene la lista de tareas desde el repositorio
            var tareas = _tareaRepository.GetTasks();
            foreach (var tarea in tareas)
            {
                Console.WriteLine($"ID: {tarea.Id}, Descripcion: {tarea.Descripcion}. Fecha Limite: {tarea.FechaLimite} Completada: {tarea.Completada} ");
            }
        }

        public void MarcarTareaCompletada(int id)
        {
            // Obtiene la lista de tareas desde el repositorio por su ID.
            var tarea = _tareaRepository.GetTasksById(id);
            // Verifica si la tarea fue encontrada
            if (tarea != null)
            {
                // Se marca la tarea como completada y se actualiza la tarea en el repositorio
                tarea.Completada = true;
                _tareaRepository.UpdateTasks(tarea);
                Console.WriteLine($"Tarea con ID: {id} fue marcada como completada");
            }
            else
            {

                Console.WriteLine("Esta tarea no ha sido encontrada");
            }
        }
        // Método para eliminar una tarea
        public void EliminarTarea(int id)
        {
            _tareaRepository.DeleteTasks(id);
            Console.WriteLine($"Tarea con ID: {id} ha sido eliminada");
        }
    }
}
