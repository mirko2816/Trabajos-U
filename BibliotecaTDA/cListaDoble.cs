using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaTDA
{
    public class cListaDoble
    {
        // Atributos
        private cNodoListaDoble aPrimerNodo;
        private cNodoListaDoble aNodoActual;
        private cNodoListaDoble aUltimoNodo;


        // Constructores
        public cListaDoble()
        {
            aPrimerNodo = null;
            aNodoActual = null;
            aUltimoNodo = null;
        }

        public cListaDoble(cNodoListaDoble pPrimerNodo, cNodoListaDoble pNodoActual, cNodoListaDoble pUltimoNodo)
        {
            aPrimerNodo = pPrimerNodo;
            aNodoActual = pNodoActual;
            aUltimoNodo = pUltimoNodo;
        }

        public static cListaDoble CrearLista()
        {
            return new cListaDoble();
        }

        public static cListaDoble CrearLista(cNodoListaDoble pPrimerNodo, cNodoListaDoble pNodoActual, cNodoListaDoble pUltimoNodo)
        {
            return new cListaDoble(pPrimerNodo, pNodoActual, pUltimoNodo);
        }

        // Modificadores
        public void ModificarPrimerNodo(cNodoListaDoble pPrimerNodo)
        {
            aPrimerNodo = pPrimerNodo;
        }

        public void ModificarUltimoNodo(cNodoListaDoble pUltimoNodo)
        {
            aUltimoNodo = pUltimoNodo;
        }

        // Selectores
        public cNodoListaDoble PrimerNodo()
        {
            return aPrimerNodo;
        }

        public cNodoListaDoble UltimoNodo()
        {
            return aUltimoNodo;
        }

        // Metodos
        public bool EsVacia()
        {
            return (aPrimerNodo == null);
        }

        public void Agregar(object pElemento)
        {
            Insertar(pElemento, Longitud() + 1);
        }

        public void Insertar(object pElemento, int posicion)
        {
            if (1 <= posicion && posicion <= Longitud() + 1)
            {
                // verificar si se inserta en una lista vacía
                if (EsVacia())
                {
                    aPrimerNodo = new cNodoListaDoble(null, pElemento, null);
                    aUltimoNodo = aPrimerNodo;
                    aNodoActual = aPrimerNodo;
                }
                else
                {
                    // verificar si se desea insertar al inicio
                    if (posicion == 1)
                    {
                        aPrimerNodo = new cNodoListaDoble(null, pElemento, aPrimerNodo);
                        aPrimerNodo.NodoPosterior().ModificarNodoAnterior(aPrimerNodo);
                        aNodoActual = aPrimerNodo;
                    }
                    // verificar si se desea insertar al final
                    else if (posicion == Longitud() + 1)
                    {
                        aUltimoNodo = new cNodoListaDoble(aUltimoNodo, pElemento, null);
                        aUltimoNodo.NodoAnterior().ModificarNodoPosterior(aUltimoNodo);
                        aNodoActual = aUltimoNodo;
                    }
                    // Se inserta entre 2 nodos
                    else
                    {
                        aNodoActual = IesimoNodo(posicion - 1);
                        // Insertar nuevo nodo
                        aNodoActual.ModificarNodoPosterior(new cNodoListaDoble(aNodoActual, pElemento,
                            aNodoActual.NodoPosterior()));
                        aNodoActual.NodoPosterior().NodoPosterior().ModificarNodoAnterior(aNodoActual.NodoPosterior());
                    }
                }
            }
            else
            {
                Console.WriteLine("Error, posición indicada incorrecta");
            }
        }

        public int Ubicacion(object pElemento)
        {
            int k = 1;
            aNodoActual = PrimerNodo();
            while (!Fin() && !aNodoActual.Elemento().Equals(pElemento))
            {
                k++;
                Posterior();
            }
            // Devolver posición
            return (!Fin() ? k : 0);
        }

        public cNodoListaDoble IesimoNodo(int posicion)
        {
            if (1 <= posicion && posicion <= Longitud())
            {
                // Recorrer lista hasta nodo anterior a posición
                aNodoActual = PrimerNodo();
                for (int i = 1; i < posicion; i++)
                    Posterior();
                // Devolver elemento
                return aNodoActual;
            }
            else
            {
                return null;
            }
        }

        public Object Iesimo(int posicion)
        {
            if (1 <= posicion && posicion <= Longitud())
                return IesimoNodo(posicion).Elemento();
            else
                return null;
        }

        public void Eliminar(int posicion)
        {
            // Eliminar si la posicion señalada se encuentra en el rango que maneja la lista
            if (1 <= posicion && posicion <= Longitud())
            {
                if (Longitud() == 1)
                {
                    // eliminar nodo actualizando los atributos a null
                    aPrimerNodo = null;
                    aUltimoNodo = null;
                    aNodoActual = null;
                }
                else
                {
                    if (posicion == 1)
                    {
                        // Cambia el segundo a primer nodo y modifica este
                        aPrimerNodo = aPrimerNodo.NodoPosterior();
                        aPrimerNodo.ModificarNodoAnterior(null);
                        aNodoActual = aPrimerNodo;
                    }
                    else
                    {
                        if (posicion == Longitud())
                        {
                            // Corta las conexion del penultimo nodo con el ultimo y lo considera como ultimo
                            aUltimoNodo = aUltimoNodo.NodoAnterior();
                            aUltimoNodo.ModificarNodoPosterior(null);
                            aNodoActual = aUltimoNodo;
                        }
                        else
                        {
                            // Se posiciona en un nodo anterio al que se quiere eliminar y se modifica
                            aNodoActual = IesimoNodo(posicion - 1);
                            // Suprimir nodo
                            aNodoActual.ModificarNodoPosterior(aNodoActual.NodoPosterior().NodoPosterior());
                            aNodoActual.NodoPosterior().ModificarNodoAnterior(aNodoActual);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Error, posición indicada incorrecta");
            }
        }
        
        public int Longitud()
        {
            if (EsVacia())
                return 0;
            else
            {
                // Cuenta los nodos de la lista hasta llegar a null
                int nroElementos = 1;
                cNodoListaDoble nodoAux = aPrimerNodo;
                while (nodoAux.NodoPosterior() != null)
                {
                    nroElementos++;
                    nodoAux = nodoAux.NodoPosterior();
                }
                return nroElementos;
            }
        }

        public void Primero()
        {
            aNodoActual = aPrimerNodo;
        }

        public void Ultimo()
        {
            aNodoActual = aUltimoNodo;
        }
        // --- Modifican el nodo actual por el anterior a este o posterior
        public void Anterior()
        {
            if (aNodoActual != null)
            {
                aNodoActual = aNodoActual.NodoAnterior();
            }
        }

        public void Posterior()
        {
            if (aNodoActual != null)
            {
                aNodoActual = aNodoActual.NodoPosterior();
            }
        }
        // ---Verifica que el nodo no este vacio para regresar el elemento
        public Object ObtElemento()
        {
            if (aNodoActual != null)
                return aNodoActual.Elemento();
            else
                return null;
        }

        public bool Inicio()
        {
            return (aNodoActual == null);
        }

        public bool Fin()
        {
            return (aNodoActual == null);
        }

        public void MostrarListaInicioFin()
        {
            aNodoActual = PrimerNodo();
            while (!Fin())
            {
                Console.WriteLine(ObtElemento());
                Posterior();
            }
        }

        public void MostrarListaFinInicio()
        {
            aNodoActual = UltimoNodo();
            while (!Inicio())
            {
                Console.WriteLine(ObtElemento());
                Anterior();
            }
        }
    }
}
