using BibliotecaTDA;

namespace AppTarea1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear una nueva cola
            cCola cola = cCola.Crear();

            // Verificar si la cola está vacía
            Console.WriteLine("La cola está vacía: " + cola.EsVacia()); // Debería imprimir True

            // Acolar elementos
            cola.Acolar(1);
            cola.Acolar(2);
            cola.Acolar(3);

            // Verificar si la cola está vacía después de acolar elementos
            Console.WriteLine("La cola está vacía: " + cola.EsVacia()); // Debería imprimir False

            // Mostrar el elemento en la cima de la cola
            Console.WriteLine("Elemento en la cima de la cola: " + cola.Cima()); // Debería imprimir 1

            // Desacolar un elemento y mostrar la nueva cima
            cola.Desacolar();
            Console.WriteLine("Elemento en la cima de la cola después de desacolar: " + cola.Cima()); // Debería imprimir 2

            // Desacolar otro elemento y mostrar la nueva cima
            cola.Desacolar();
            Console.WriteLine("Elemento en la cima de la cola después de desacolar nuevamente: " + cola.Cima()); // Debería imprimir 3

            // Acolar un nuevo elemento
            cola.Acolar(4);
            cola.Acolar(5);

            // Mostrar la cima de la cola después de acolar nuevos elementos
            Console.WriteLine("Elemento en la cima de la cola: " + cola.Cima()); // Debería imprimir 3
            cola.Desacolar(); // Desacolar para avanzar a la siguiente cima
            Console.WriteLine("Elemento en la cima de la cola: " + cola.Cima()); // Debería imprimir 4
            cola.Desacolar(); // Desacolar para avanzar a la siguiente cima
            Console.WriteLine("Elemento en la cima de la cola: " + cola.Cima()); // Debería imprimir 5

            // Verificar si la cola está vacía después de desacolar todos los elementos
            Console.WriteLine("La cola está vacía: " + cola.EsVacia()); // Debería imprimir True

            Console.ReadLine();
        }
    }
}