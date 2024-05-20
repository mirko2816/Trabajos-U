using System.Runtime.InteropServices;

namespace EspacioDeNombres
{
    public abstract class cVehiculo
    {
        private string aPlaca;
        private string aMarca;
        private string aModelo;

        public cVehiculo()
        {
            aPlaca = "";
            aMarca = "";
            aModelo = "";
        }
        public cVehiculo(string pPlaca, string pMarca, string pModelo)
        {
            aPlaca = pPlaca;
            aMarca = pMarca;
            aModelo = pModelo;
        }
        // Propiedades
        public string Placa
        {
            get { return aPlaca; }
            set { aPlaca = value; }
        }
        public string Marca
        {
            get { return aMarca; }
            set { aMarca = value; }
        }
        public string Modelo
        {
            get { return aModelo; }
            set { aModelo = value; }
        }
        // Metodos
        public virtual void Leer()
        {
            Console.Write("Placa:");
            aPlaca = Console.ReadLine();
            Console.Write("Marca:");
            aMarca = Console.ReadLine();
            Console.Write("Modelo:");
            aModelo = Console.ReadLine();
        }
        public virtual void Mostrar()
        {
            Console.WriteLine($"Placa: {aPlaca}");
            Console.WriteLine($"Placa: {aMarca}");
            Console.WriteLine($"Placa: {aModelo}");
        }
        public abstract int CalcularPeaje();

        public override bool Equals(object pPlaca)
        {
            return aPlaca.Equals(pPlaca.ToString());
        }
    }

    public class cAuto : cVehiculo
    {
        private int aAnio;

        // Constructores
        public cAuto() : base() 
        {
            aAnio = 1886;
        }

        public cAuto(string pPlaca, string pMarca, string pModelo, int pAnio) : base(pPlaca, pMarca, pModelo)
        {
            if (pAnio >= 1886)
            {
                aAnio = pAnio;
            }
            else 
            {
                aAnio = 1886;
            }
        }

        // Propiedades
        public int Anio
        {
            get { return aAnio; }
            set
            {
                if (value >= 1886)
                {
                    aAnio = value;
                }
            }
        }
        // Metodos
        public override int CalcularPeaje()
        {
            int anioActual = DateTime.Now.Year;
            int Antiguedad = anioActual - aAnio;
            if (Antiguedad > 20)
            {
                return 20;
            }
            else if (Antiguedad > 15)
            {
                return 10;
            }
            else    
            {
                return 0;
            }
        }
    }

    public class cCamion : cVehiculo
    {
        // Atributos
        private int aNroRuedas;

        // Constructores
        public cCamion() : base()
        {
            aNroRuedas = 4;
        }

        public cCamion(string pPlaca, string pMarca, string pModelo, int pNroRuedas) : base(pPlaca, pMarca, pModelo)
        {
            if (pNroRuedas < 4)
            {
                aNroRuedas = 4;
            }
            else if (pNroRuedas%2 == 0)
            {
                aNroRuedas = pNroRuedas;
            }
            else
            {
                aNroRuedas = 4;
            }
        }

        // Propiedades
        public int NroRuedas
        {
            get { return aNroRuedas;}
            set
            {
                if ((value < 0)) {
                    aNroRuedas = 0;
                } 
                else {
                    aNroRuedas = value;
                }
            }
        }
        // Metodos
        public override int CalcularPeaje() // segun al numero de ruedas
        {
            if (aNroRuedas > 4)
            {
                return 20;
            } 
            else { return 10; }
        }
    }

    public static class Control
    {
        // Metodos que reciben la opcion y el array
        public static int ElegirOpcion()
        {
            Console.WriteLine("MENU DE VEHICULOS");
            Console.WriteLine("1. Listar");
            Console.WriteLine("2. Insertar");
            Console.WriteLine("3. Buscar");
            Console.WriteLine("4. Total Peaje");
            Console.WriteLine("5. Nro de autos y camiones");
            Console.Write("Opcion --> ");
            int opcion = int.Parse(Console.ReadLine());
            return opcion;
        }
    }
}