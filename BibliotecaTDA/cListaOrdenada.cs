using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaTDA
{
    public class cListaOrdenada : cListaRecursiva
    {
        // Constructores
        public cListaOrdenada() : base()
        {
        }

        public cListaOrdenada(object pElemento, cListaRecursiva pSublista) : base(pElemento, pSublista)
        {
        }
        
        
        // Metodos de proceso
        public override void Agregar(object pElemento)
        {
            if (!EsVacia())
            {
                if ((pElemento.ToString().CompareTo(Elemento.ToString()) < 0))
                {
                    SubLista = new cListaOrdenada(Elemento, SubLista);
                    Elemento = pElemento;
                }
                else
                {
                    SubLista.Agregar(pElemento);
                }
            }
            else
            {
                Elemento = pElemento;
                SubLista = new cListaOrdenada();
            }
        }
    }
}
