using BibliotecaTDA;

namespace AppArboles
{
    internal class Programa
    {
        public static void Menu()
        {
            Console.WriteLine("\n---- ORGANIZACION DE ALUMNOS ----");
            Console.WriteLine("1. Agregar alumno");
            Console.WriteLine("2. Eliminar alumno");
            Console.WriteLine("3. Listar alumnos por orden de notas");
            Console.WriteLine("4. Alumnos de informatica con nota mayor al promedio");
            Console.WriteLine("4. Salir");
        }

        public static void Ejecutar()
        {
            cArbolBinario arbolAlumnos = new cArbolBinario();

            int opcion = 0;
            while(opcion != 4)
            {
                Menu();
                Console.Write("Opcion --> ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\n-- Agregar alumno --");
                        cAlumno nuevoAlum = new cAlumno();
                        nuevoAlum.LeerDatos();
                        arbolAlumnos.Agregar(nuevoAlum);
                        break;
                    case 2:
                        Console.WriteLine("\n-- Eliminar alumno --");
                        cAlumno alumEliminado = new cAlumno();
                        alumEliminado.LeerDatos();
                        arbolAlumnos.Eliminar(alumEliminado.Codigo);
                        break;
                    case 3:
                        Console.WriteLine("\n-- Lista de notas en orden --");
                        arbolAlumnos.RecorrerInOrden();
                        break;
                    case 4:
                        break;
                }
            }
        }

    }
}
