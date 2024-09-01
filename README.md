# ToDoApp

## Descripci�n

ToDoList es una aplicaci�n de consola para gestionar una lista de tareas. Permite agregar, listar, marcar como completadas y eliminar tareas.

## Requerimientos

- .NET Framework 4.8
- Newtonsoft.Json (paquete NuGet)

## Instalaci�n

1. Clona el repositorio:
    ```bash
    git clone https://github.com/Juanselo/ToDoList.git
    ```
2. Navega al directorio del proyecto:
    ```bash
    cd ToDoApp
    ```
3. Restaura los paquetes NuGet:
    ```bash
    nuget restore ToDoApp.sln
    ```

## Ejecuci�n

1. Compila el proyecto:
    ```bash
    msbuild ToDoApp.sln
    ```
2. Ejecuta la aplicaci�n:
    ```bash
    ToDoApp.exe
    ```

## Uso

Selecciona una opci�n del men� para interactuar con la aplicaci�n:
1. **Agregar tarea**: Introduce una descripci�n y una fecha l�mite opcional.
2. **Listar tareas**: Muestra todas las tareas registradas.
3. **Marcar tarea como completada**: Introduce el ID de la tarea para marcarla como completada.
4. **Eliminar tarea**: Introduce el ID de la tarea para eliminarla.
5. **Salir**: Cierra la aplicaci�n.

## Documentaci�n

El c�digo est� documentado para explicar la l�gica implementada y las operaciones realizadas.
