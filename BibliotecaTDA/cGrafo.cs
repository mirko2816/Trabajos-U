using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaTDA
{
    public class cGrafo
    {
        //Atributos
        private Object aVertice;
        cListaOrdenada aLista;
        cGrafo aSgte;

        public cGrafo()
        {
            aVertice = null;
            aLista = new cListaOrdenada();
            aSgte = null;
        }

        public cGrafo(Object pVertice, cListaOrdenada pLista, cGrafo pSgte)
        {
            aVertice = pVertice;
            aLista = pLista;
            aSgte = pSgte;
        }

        //propiedades
        public Object Vertice
        {
            set { aVertice = value; }
            get { return aVertice; }
        }

        public cListaOrdenada Lista
        {
            set { aLista = value; }
            get { return aLista; }
        }

        public cGrafo Sgte
        {
            set { aSgte = value; }
            get { return aSgte; }
        }

        //métodos
        public bool esVacio()
        {
            return (aVertice == null);
        }

        public bool existeVertice(Object pVertice)
        {
            if (esVacio())
                return false;
            else
            {
                if (Vertice.Equals(pVertice))
                    return true;
                else
                    return Sgte.existeVertice(pVertice);
            }

        }

        public int NumVertices()
        {
            if (esVacio())
                return 0;
            else
                return 1 + aSgte.NumVertices();
        }

        public void agregarVertice(Object pVertice)
        {
            if (!existeVertice(pVertice))
            {
                if (esVacio() || (!pVertice.Equals(Vertice)))
                {
                    aSgte = new cGrafo(aVertice, aLista, aSgte);
                    aVertice = pVertice;
                    aLista = new cListaOrdenada();
                }
                else
                    aSgte.agregarVertice(pVertice);
            }
            else
            {
                Console.WriteLine("El vertice {0} ya esta en el grafo", pVertice);
            }

        }

        public void mostrarVertices()
        {
            if (!esVacio())
            {
                Console.WriteLine(Vertice);
                aSgte.mostrarVertices();
            }
        }

        public void AgregarArco(Object pVertice1, Object pVertice2)
        {
            if ((existeVertice(pVertice1)) && (existeVertice(pVertice2)))
            {
                AgregarArcoEnLista(pVertice1, pVertice2);
            }
        }
        public void AgregarArcoEnLista(Object pVertice1, Object pVertice2)
        {
            if ((pVertice1.Equals(Vertice)))
            {
                if (Lista.EsVacia())
                {
                    aLista = new cListaOrdenada();
                }
                else
                {
                    if (!Lista.ExisteElemento(pVertice2))
                    {
                        aLista.Agregar(pVertice2);
                    }
                }
            }
            else
            {
                aSgte.AgregarArcoEnLista(pVertice1, pVertice2);
            }
        }

        public bool existeArco(Object pVertice1, Object pVertice2)
        {
            if ((existeVertice(pVertice1)) && (existeVertice(pVertice2)))
            {
                return existeArcoEnLista(pVertice1, pVertice2);
            }
            else
                return false;
        }

        public bool existeArcoEnLista(Object pVertice1, Object pVertice2)
        {
            if ((pVertice1.Equals(Vertice)))
            {
                return Lista.ExisteElemento(pVertice2);
            }
            else
            {
                return aSgte.existeArcoEnLista(pVertice1, pVertice2);
            }
        }

        public int gradoSaliente(Object pVertice)
        {
            if ((pVertice.Equals(Vertice)))
            {
                return Lista.Longitud();
            }
            else
            {
                return aSgte.gradoSaliente(pVertice);
            }
        }

        public Object iesimoSucesor(Object pVertice, int n)
        {
            if ((pVertice.Equals(Vertice)))
            {
                return Lista.Iesimo(n);
            }
            else
            {
                return Sgte.iesimoSucesor(pVertice, n);
            }
        }
        public int nroVert(Object pVertice)
        {
            if ((pVertice.Equals(Vertice)))
            {
                return 1;
            }
            else
            {
                return 1 + Sgte.nroVert(pVertice);
            }
        }

        public Object nroVertice(int i)
        {
            if (i == 1)
            {
                return Vertice;
            }
            else
            {
                return Sgte.nroVertice(i - 1);
            }
        }
        public void MostrarGrafo()
        {
            if (!esVacio())
            {
                Console.WriteLine("Para el vértice {0} :", Vertice);
                Console.WriteLine("Sus Arcos son:");
                //aLista.MostrarLista();
                aSgte.MostrarGrafo();
            }
        }
    }
}
