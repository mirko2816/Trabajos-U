using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafo;

namespace AppCaminosMInimoss
{
    class Program
    {

        public static void merge_(ref ArrayList arr, int ini, int mid, int fin)
        {
            /*
             * el arreglo esta dividido en 2, 
             * arr[ini, mid]  arr[mid + 1, fin]
             * ademas, ambos arreglos estan ordenados
             */
            
            ArrayList aux = new ArrayList();

            for (int m = 0; m < fin - ini + 1; m++)
            {
                aux.Add(0);
            }

            int i = ini;
            int j = mid + 1;
            int k = 0;
            while (i <= mid && j <= fin)
            {
                if ((arr[i] as CArista).Peso < (arr[j] as CArista).Peso)
                {
                    aux[k++] = arr[i++];
                }
                else
                {
                    aux[k++] = arr[j++];
                }
            }
            if (i <= mid)
            {
                // copiar elementos sobrantes de la izquierda en aux
                for (int l = i; l <= mid; l++)
                {
                    aux[k++] = arr[l];
                }
            }

            if (j <= fin)
            {
                // copiar elementos sobrantes de derecha en aux 
                for (int l = j; l <= fin; l++)
                {
                    aux[k++] = arr[l];
                }
            }
            // vaciamos los elementos de aux en arr
            for (int l = 0; l < aux.Count; l++)
            {
                arr[ini + l] = aux[l];
            }
        }
        public static void merge_sort_( ArrayList arr, int ini, int fin)
        {
            // se garantiza que hay elementos en arr y ademas es dividible
            if (ini < fin)
            {
                int mid = (ini + fin) / 2;
                merge_sort_(arr, ini, mid);
                merge_sort_(arr, mid + 1, fin);
                merge_(ref arr, ini, mid, fin);

            }
        }
        static void Main(string[] args)
        {


            // -- Crear objeto CaminosMInimos
            // cCaminosMinimos G = new cCaminosMinimos();
            // -- Leer CaminosMInimos de archivo
            // G.LeerDeArchivo("Grafo02.csv");
            // -- Ejecutar Dijkstra
            //G.Dijkstra();
            // -- Mostrar cammino minimo y costo
            //G.MostrarCaminosMinimos();

            /*
            // -- Mostrar CaminosMInimos
            G.Mostrar();
            */
            // -- Pausa


            // leemos el grafo del archivo
            cGrafo grafo = new cGrafo();
            grafo.LeerDeArchivo("grafo.txt");
            grafo.Mostrar();

            ArrayList lista = new ArrayList();

            for (int i = 0; i < grafo.NroVertices; i++)
            {
                for (int j = i; j < grafo.NroVertices; j++)
                {
                    if (i != j)
                        lista.Add(new CArista(i, j, grafo.getPeso(i, j)));
                }
            }




            merge_sort_(lista, 0, lista.Count - 1);

            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine(lista[i].ToString());
            }


            ///

            int k = 0;
            while (k < lista.Count)
            {
                // seleccionamos la arista de menor peso
                CArista ar = (CArista)lista[k];
            
                // verifiamos que los extemos i, j no esten en el mismo arbol
                

                // aplicar DSU  - Union find 

                k = k + 1;
            }
            
            /* construimos nuestra nueva matriz de adyacencia 
             * para nuestro MST kruskal
             */

            Console.ReadKey();
        }
    }
}
