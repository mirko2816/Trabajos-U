using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public abstract class cDocente
    {
        #region ==== ATRIBUTOS ====

        private string aCodigo;
        private string aNombre;
        private string aDpto;

        #endregion

        #region ==== CONSTRUCTORES ====

        public cDocente() 
        {
            aCodigo = "";
            aNombre = "";
            aDpto = "";
        }

        public cDocente(string pCodigo, string  pNombre, string pDpto)
        {
            aCodigo = pCodigo;
            aNombre = pNombre;
            aDpto = pDpto;
        }

        #endregion

        #region ==== PROPIEDADES ====

        public string Codigo
        {
            get { return aCodigo; }
            set { aCodigo = value; }
        }
        public string Nombre
        {
            get { return aNombre; }
            set { aNombre = value; }
        }
        public string Dpto
        {
            get { return aDpto; }
            set { aDpto = value; }
        }

        #endregion

        #region ==== METODOS ====
        public virtual void Leer()
        {
            Console.WriteLine("Codigo:");
            aCodigo = Console.ReadLine();
            Console.WriteLine("Nombre:");
            aNombre = Console.ReadLine();
            Console.WriteLine("Departamento:");
            aDpto = Console.ReadLine();
        }
        public virtual void Mostrar()
        {
            Console.WriteLine($"Codigo: {aCodigo}");
            Console.WriteLine($"Nombre: {aNombre}");
            Console.WriteLine($"Departamento: {aDpto}");
        }

        public abstract int CalcularSueldo();

        #endregion
    }
}
