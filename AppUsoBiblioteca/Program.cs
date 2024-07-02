using BibliotecaTDA;
class Program
{
    static void Main(string[] args)
    {
        cListaRecursiva listaDeTareas = new cListaRecursiva();
        int opcion;

        do
        {
            Console.WriteLine("\nMenú de Tareas Pendientes:");
            Console.WriteLine("1. Agregar tarea");
            Console.WriteLine("2. Listar tareas");
            Console.WriteLine("3. Eliminar tarea");
            Console.WriteLine("4. Buscar ubicación de una tarea");
            Console.WriteLine("5. Verificar si la lista está vacía");
            Console.WriteLine("6. Obtener longitud de la lista");
            Console.WriteLine("0. Salir");
            Console.Write("Ingrese una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese la descripción de la tarea: ");
                    string tarea = Console.ReadLine();
                    listaDeTareas.Agregar(tarea);
                    Console.WriteLine("Tarea agregada.");
                    break;

                case 2:
                    Console.WriteLine("Lista de tareas:");
                    listaDeTareas.Listar();
                    break;

                case 3:
                    Console.Write("Ingrese el índice de la tarea a eliminar: ");
                    int indiceEliminar = int.Parse(Console.ReadLine());
                    listaDeTareas.Eliminar(indiceEliminar);
                    Console.WriteLine("Tarea eliminada.");
                    break;

                case 4:
                    Console.Write("Ingrese la descripción de la tarea a buscar: ");
                    string tareaABuscar = Console.ReadLine();
                    int ubicacion = listaDeTareas.Ubicacion(tareaABuscar);
                    if (ubicacion == -1)
                    {
                        Console.WriteLine("Tarea no encontrada.");
                    }
                    else
                    {
                        Console.WriteLine("La tarea se encuentra en la posición: " + ubicacion);
                    }
                    break;

                case 5:
                    Console.WriteLine("¿La lista está vacía? " + listaDeTareas.EsVacia());
                    break;

                case 6:
                    Console.WriteLine("La longitud de la lista es: " + listaDeTareas.Longitud());
                    break;

                case 0:
                    Console.WriteLine("Saliendo del programa.");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        } while (opcion != 0);
    }
}