using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class cDocContratado : cDocente
    {
        #region ==== ATRIBUTOS ====

        private string aCategoria;
        private string aRegimen;

        #endregion

        #region ==== CONSTRUCTORES ====

        public cDocContratado() : base()
        {
            aCategoria = "";
            aRegimen = "";
        }
        public cDocContratado(string pCodigo, string pNombre, string pDpto, string pCategoria, string pRegimen) : base(pCodigo, pNombre, pDpto)
        {
            aCategoria = pCategoria;
            aRegimen = pRegimen;
        }

        #endregion

        #region ==== PROPIEDADES ====

        public string Categoria
        { 
            get { return aCategoria; }
            set { aCategoria = value; }
        }
        public string Regimen
        {
            get { return aRegimen; }
            set { aRegimen = value; }
        }

        #endregion

        #region ==== METODOS ====

        public override void Leer()
        {
            base.Leer();
            Console.WriteLine("Categoria:");
            aCategoria = Console.ReadLine();
            Console.WriteLine("Regimen:");
            aRegimen = Console.ReadLine();
        }

        public override void Mostrar()
        {
            base.Mostrar();
            Console.WriteLine($"Categoria: {aCategoria}");
            Console.WriteLine($"Regimen: {aRegimen}");
        }
        public override int CalcularSueldo()
        {
            if (aRegimen == "TC")
            {
                if (aCategoria == "Principal")
                {
                    return 8000;
                }
                else if (aCategoria == "Asociado")
                {
                    return 4000;
                }
                else
                {
                    return 3000;
                }
            }
            else
            {
                if (aCategoria == "Principal")
                {
                    return 4000;
                }
                else if (aCategoria == "Asociado")
                {
                    return 3000;
                }
                else
                {
                    return 1500;
                }
            }
        }
        #endregion
    }
}
