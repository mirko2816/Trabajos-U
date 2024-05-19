using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override bool Equals(object? vehiculo)
        {
            if (aPlaca == ((cVehiculo)vehiculo).Placa)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            return 0;
        }
    }
}