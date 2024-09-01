using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data.Implementations;
using ToDoList.Services;

namespace ToDoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ruta donde se almacenaran las tareas
            var filePath = "tareas.json";
            var tareaRepository = new TareaRepository(filePath);
            var tareaService = new TareaService(tareaRepository);

            while (true)
            {
                Console.WriteLine("Seleccione una opcion");
                Console.WriteLine("1. Agregar Tarea");
                Console.WriteLine("2. Listar Tareas");
                Console.WriteLine("3. Marcar tarea como completada");
                Console.WriteLine("4. Eliminar Tarea");
                Console.WriteLine("5. Salir");

                var opcion = Console.ReadLine();
                try
                {
                    switch (opcion)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("Agregar Nueva Tarea");
                            Console.WriteLine(new string('-', 30));
                            Console.Write("Descripción de la tarea: ");
                            var descripcion = Console.ReadLine();
                            Console.Write("Fecha Límite (Opcional, formato yyyy-MM-dd): ");
                            // parsear la fecha Limite si es que hay fecha
                            DateTime? fechaLimite = DateTime.TryParse(Console.ReadLine(), out var fecha) ? fecha : (DateTime?)null;
                            // Se llama al servicio para agregar la tarea.
                            tareaService.AgregarTarea(descripcion, fechaLimite);
                            break;

                        case "2":
                            Console.Clear();
                            Console.WriteLine("Listado de Tareas");
                            Console.WriteLine(new string('-', 30));
                            tareaService.ListarTareas();
                            break;

                        case "3":
                            Console.Write("ID de la tarea para marcarla como completada: ");
                            // parsear id de la tarea.
                            if (int.TryParse(Console.ReadLine(), out var idCompletar))
                            {
                                tareaService.MarcarTareaCompletada(idCompletar);
                            }
                            else
                            {
                                Console.WriteLine("ID incorrecta");
                            }
                            break;

                        case "4":
                            Console.Write("ID de la tarea a eliminar: ");
                            if (int.TryParse(Console.ReadLine(), out var idEliminar))
                            {
                                tareaService.EliminarTarea(idEliminar);
                            }
                            break;

                        case "5":
                            return;
                        default:
                            Console.WriteLine("Esta opcion no es valida, intente de nuevo");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Cualquier excepcion que ocurra, mostrarla
                    Console.WriteLine($"Error: {ex.Message}");

                }
                // Espera a que el usuario pulse una tecla
                Console.WriteLine();
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
