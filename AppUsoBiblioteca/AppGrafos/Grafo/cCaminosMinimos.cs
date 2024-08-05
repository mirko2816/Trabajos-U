using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo
{
    /*
    Esta clase implementa el algoritmo de Dijkstra
    */
    public class cCaminosMinimos : cGrafo
    {
        #region *********************** ATRIBUTOS ************************
        private float[,] aDijkstra;
        #endregion *********************** ATRIBUTOS ************************

        #region *********************** METODOS ************************
        #region ==================== CONSTRUCTORES =======================
        // ----------------------------------------------------------------
        public cCaminosMinimos() : base()
        {
            aDijkstra = new float[aNroVertices, 3];
        }

        // ----------------------------------------------------------------
        public cCaminosMinimos(int pNroVertices) : base(pNroVertices)
        {
            aDijkstra = new float[pNroVertices, 3];
        }
        #endregion ==================== CONSTRUCTORES =======================

        #region ==================== PROPIEDADES =======================

        #endregion ==================== PROPIEDADES =======================

        #region ==================== MÉTODOS PROCESO =======================
        // ----------------------------------------------------------------
        public void InicializarDijkstra()
        {
            // -- Dimensionar estructura
            aDijkstra = new float[aNroVertices, 3];
            // -- Inicializar estado
            for (int V = 0; V < aNroVertices; V++)
            {
                aDijkstra[V, 0] = float.NaN;
                aDijkstra[V, 1] = float.NaN;
                aDijkstra[V, 2] = float.NaN;
            }

        }

        // ----------------------------------------------------------------
        public int DeterminarNuevoVerticeProceso()
        {
            int Vertice = -1;
            float Ponderacion = float.MaxValue;
            for (int K = 0; K < aNroVertices; K++)
                if (aDijkstra[K, 2] != 1)
                    if (aDijkstra[K, 1] < Ponderacion)
                    {
                        Vertice = K;
                        Ponderacion = aDijkstra[K, 1];
                    }
            return Vertice;
        }

        // ----------------------------------------------------------------
        public void EstablecerCaminosMinimosDesdeVertice(int Vertice)
        {
            // -- Recorrer matriz de adyacencia 
            for (int V = 0; V < aNroVertices; V++)
                // -- No procesar el mismo vértice, ni los vértices ya procesados 
                if ((V != Vertice) && (aDijkstra[V, 2] != 1))
                {
                    // -- Verificar si existe arista entre vértices denotados por: Vertice y V
                    if (!float.IsNaN(aMatrizAdyacencia[Vertice, V]))
                        // -- Procesar vértice si V aun no tiene camino mínimo
                        if (float.IsNaN(aDijkstra[V, 1]) ||
                            (aDijkstra[V, 1] > aDijkstra[Vertice, 1] + aMatrizAdyacencia[Vertice, V]))
                        {
                            // -- Establecer en vertice V ponderación y vertice de llegada
                            if (float.IsNaN(aDijkstra[Vertice, 1]))
                                aDijkstra[V, 1] = aMatrizAdyacencia[Vertice, V];
                            else
                                aDijkstra[V, 1] = aDijkstra[Vertice, 1] + aMatrizAdyacencia[Vertice, V];
                            aDijkstra[V, 0] = Vertice;
                        }
                }
            // -- Marcar vértice como procesado
            aDijkstra[Vertice, 2] = 1;
        }

        // ----------------------------------------------------------------
        public void Dijkstra()
        {   /* ******** Algoritmo de rutas mínimas ******** */
            // -- Inicializar aDijkstra
            InicializarDijkstra();

            // -- Establecer vertice inicial
            int VerticeProceso = 0;

            // -- Efectuar el proceso iterativo            
            while (VerticeProceso != -1)
            {
                // -- Determinar nuevos vertices a los que se puede alcanzar desde vertice en proceso
                EstablecerCaminosMinimosDesdeVertice(VerticeProceso);
                // -- Establecer nuevo vertice de proceso
                VerticeProceso = DeterminarNuevoVerticeProceso();
            }
        }

        // ----------------------------------------------------------------
        public void RecuperarCaminoMinimo(int Vertice, out string Camino, out float Costo)
        {   /* ******** Algoritmo que devuelve camino mínimo y costo ******** */
            // -- Inicializar Camino y costo
            Camino = "";
            Costo = aDijkstra[Vertice, 1];

            // -- Determinar Camino y costo
            while (Vertice != 0)
            {
                // -- Argear nodo a camino y acumular costo
                Camino = " -> " + Vertice.ToString() + Camino;
                // -- Recuperar vertice desde donde se llega al vertice objetivo
                Vertice = (int)aDijkstra[Vertice, 0];
            }
            // -- Agregar al camino el vertice origen 
            Camino = "0" + Camino;
        }

        // ----------------------------------------------------------------
        public void MostrarCaminosMinimos()
        {
            // -- Recuperar camminos minimos y costos
            String Camino;
            float Costo;
            Console.WriteLine();
            Console.WriteLine("".PadRight(30, '='));
            Console.WriteLine("        CAMINOS MÍNIMOS");
            Console.WriteLine("    (Algoritmo de Dijkstra)");
            Console.WriteLine("".PadRight(30,'='));
            Console.WriteLine("Vertice".PadRight(8)+"Costo".PadRight(8) + "Camino".PadRight(8));
            for (int V = 1; V < aNroVertices; V++)
            {
                RecuperarCaminoMinimo(V, out Camino, out Costo);
                Console.WriteLine(V.ToString().PadRight(8)+Costo.ToString().PadRight(8)+Camino.ToString().PadRight(8));                
            }
        }

        // ----------------------------------------------------------------
        public void MostrarCaminoMinimo(int Vertice)
        {
            // -- Recuperar cammino minimo y costo
            String Camino;
            float Costo;
            RecuperarCaminoMinimo(Vertice, out Camino, out Costo);
            Console.WriteLine("Camino: " + Camino);
            Console.WriteLine("Costo: " + Costo);
        }

        #endregion ==================== MÉTODOS PROCESO =======================

        #endregion *********************** METODOS ************************

    }
}
