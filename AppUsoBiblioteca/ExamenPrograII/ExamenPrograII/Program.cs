using BibliotecaTDA;

namespace ExamenPrograII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            cListaRecursiva listaAutos = new cListaRecursiva();
            listaAutos.Agregar(new cVehiculo("a", "a", "a", "a", "CAMIONETA", 2003));
            listaAutos.Agregar(new cVehiculo("b", "b", "b", "b", "BUS", 2002));
            listaAutos.Agregar(new cVehiculo("c", "c", "c", "c", "TRAILER", 2005));
            listaAutos.Agregar(new cVehiculo("d", "d", "d", "d", "VOLQUETE", 2023));
            listaAutos.Agregar(new cVehiculo("e", "e", "e", "e", "CAMIONETA", 1993));

            cListaRecursiva listaFiltrada = ListarCamionesOBusesPos2000(listaAutos);

            listaFiltrada.Listar();
            Console.WriteLine();
            
        }

        public static cListaRecursiva ListarCamionesOBusesPos2000(cListaRecursiva listaAutos)
        {
            cListaRecursiva list = new cListaRecursiva();
            for (int i = 0; i < listaAutos.Longitud(); i++)
            {
                if (listaAutos.Iesimo(i) is cVehiculo)
                {
                    cVehiculo vehiculoAux = listaAutos.Iesimo(i) as cVehiculo;
                    if (vehiculoAux.Anio > 2000 && (vehiculoAux.Tipo == "CAMIONETA" || vehiculoAux.Tipo == "BUS") )
                    {
                        vehiculoAux.MostrarInfo();
                    }
                }
            }
            return list;
        }
    }
}