using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ToDoList.Data.Interfaces;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Data.Implementations
{
    public class TareaRepository : ITareaRepository
    {
        private readonly string _filePath; // Ruta del archivo donde se van a almacenar las tareas.
        private List<Tarea> _tareas;

        public TareaRepository(string filePath)
        {
            _filePath = filePath;
            _tareas = LoadData(); // cargar todos los datos al inicializar el repositorio
        }

        public void AddTasks(Tarea tarea)
        {
            tarea.Id = _tareas.Count > 0 ? _tareas.Max(t => t.Id) + 1 : 1;
            _tareas.Add(tarea);
            SaveData(); // guarda los cambios en el archivo
        }
        public IEnumerable<Tarea> GetTasks()
        {
            return _tareas;
        }

        public Tarea GetTasksById(int id)
        {
            return _tareas.FirstOrDefault(t => t.Id == id);
        }
        public void UpdateTasks(Tarea tarea)
        {
            var ExistTasks = GetTasksById(tarea.Id);
            if (ExistTasks != null)
            {
                ExistTasks.Descripcion = tarea.Descripcion;
                ExistTasks.FechaLimite = tarea.FechaLimite;
                ExistTasks.Completada = tarea.Completada;
                SaveData();
            }
        }
        public void DeleteTasks(int id)
        {
            var tarea = GetTasksById(id);
            if (tarea != null)
            {
                _tareas.Remove(tarea);
                SaveData();
            }
        }
        // Guardar la lista de tareas en el archivo en formato JSON
        private void SaveData()
        {
            var json = JsonConvert.SerializeObject(_tareas, Formatting.Indented); // convertir lista a formato JSON.
            File.WriteAllText(_filePath, json); // Escribe el JSON en el archivo.
        }

        // Guardar la lista de tareas en el archivo en formato JSON
        private List<Tarea> LoadData()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                return JsonConvert.DeserializeObject<List<Tarea>>(json) ?? new List<Tarea>(); // deserializar el JSON a una lista
            }
            return new List<Tarea>();
        }
    }
}
