using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class cControl
    {
        #region ==== ATRIBUTOS ====

        private cDocente[] aDocentes;
        private int aContador;

        #endregion

        #region ==== CONSTRUCTORES ====

        public cControl()
        {
            aDocentes = new cDocente[3];
            aContador = 0;
        }
        public cControl(int pTamanio)
        {
            aDocentes = new cDocente[pTamanio];
            aContador = 0;
        }

        #endregion

        #region ==== METODOS ====

        public void Ejecutar()
        {
            int op = 0;
            do
            {
                Menu();

                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        IngresarDocente();
                        break;
                    case 2:
                        BuscarDocente();
                        break;
                    case 3:
                        PagoNombrados();
                        break;
                    case 4:
                        PagoContratados();
                        break;
                    case 5:


                }

            } while (op != 6);
        }
        private void Menu()
        {
            Console.WriteLine("================");
            Console.WriteLine("MENU DE DOCENTES");
            Console.WriteLine("================");
            Console.WriteLine("1. Ingresar Docente");
            Console.WriteLine("2. Buscar Docente");
            Console.WriteLine("3. Calcular pago a Nombrados");
            Console.WriteLine("4. Calcular pago a Contratados");
            Console.WriteLine("5. Ingresar Docente");
            Console.WriteLine("6. Salir");
            Console.WriteLine("Elija una opcion: ");
        }

        #endregion
    }
}
