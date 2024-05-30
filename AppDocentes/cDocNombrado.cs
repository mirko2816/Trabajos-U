using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class cDocNombrado : cDocente
    {
        #region ==== ATRIBUTOS ====

        private string aNivel;

        #endregion

        #region ==== CONSTRUCTORES ====

        public cDocNombrado() : base()
        {
            aNivel = "";
        }
        public cDocNombrado(string pCodigo, string pNombre, string pDpto, string pNivel) : base(pCodigo, pNombre, pDpto)
        {
            aNivel = pNivel;
        }

        #endregion

        #region ==== PROPIEDADES ====

        public string Nivel
        {
            get { return aNivel; }
            set { aNivel = value; }
        }

        #endregion

        #region ==== METODOS ====

        public override void Leer()
        {
            base.Leer();
            Console.WriteLine("Nivel: (A1/B1/B2)");
            aNivel = Console.ReadLine();
        }

        public override void Mostrar()
        {
            base.Mostrar();
            Console.WriteLine($"Nivel: {aNivel}");
        }
        public override int CalcularSueldo()
        {
            
            if (aNivel == "A1")
            {
                return 4000;
            }
            else if (aNivel == "B1")
            {
                return 2000;
            }
            else
            {
                return 1000;
            }
           
        }

        #endregion

    }
}
