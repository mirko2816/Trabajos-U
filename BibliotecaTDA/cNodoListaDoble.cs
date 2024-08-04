using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaTDA
{
    public class cNodoListaDoble
    {
        //========== ATRIBUTOS ==========
        private cNodoListaDoble aNodoAnterior;
        private object aElemento;
        private cNodoListaDoble aNodoPosterior;

        // ===================== METODOS ==================

        // ========CONSTRUCTORES =========
        public cNodoListaDoble()
        {
            aNodoAnterior = null;
            aElemento = null;
            aNodoPosterior = null;
        }

        public cNodoListaDoble(cNodoListaDoble pNodoAnterior, object pElemento, cNodoListaDoble pNodoPosterior)
        {
            aNodoAnterior = pNodoAnterior;
            aElemento = pElemento;
            aNodoPosterior = pNodoPosterior;
        }

        public static cNodoListaDoble Crear()
        {
            return new cNodoListaDoble();
        }

        public static cNodoListaDoble Crear(cNodoListaDoble pNodoAnterior, object pElemento, cNodoListaDoble pNodoPosterior)
        {
            return new cNodoListaDoble(pNodoAnterior, pElemento, pNodoPosterior);
        }

        // =========== MODIFICADORES ===========
        public void ModificarNodoAnterior(cNodoListaDoble pNodoAnterior)
        {
            aNodoAnterior = pNodoAnterior;
        }

        public void ModificarElemento(object pElemento)
        {
            aElemento = pElemento;
        }

        public void ModificarNodoPosterior(cNodoListaDoble pNodoPosterior)
        {
            aNodoPosterior = pNodoPosterior;
        }

        // ============ SELECTORES ==============
        public cNodoListaDoble NodoAnterior()
        {
            return aNodoAnterior;
        }

        public object Elemento()
        {
            return aElemento;
        }

        public cNodoListaDoble NodoPosterior()
        {
            return aNodoPosterior;
        }
    }
}
