using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPGRAFO
{
    public class cKruskal : cGrafo
    {
        public cKruskal(int pNroVertices) : base(pNroVertices) { }

        public List<CArista> Kruskal()
        {
            List<CArista> aristas = new List<CArista>();
            List<CArista> mst = new List<CArista>();
            int[] padre = new int[aNroVertices];
            int[] rango = new int[aNroVertices];

            // Inicializar estructura para union-find
            for (int i = 0; i < aNroVertices; i++)
            {
                padre[i] = i;
                rango[i] = 0;
            }

            // Crear lista de aristas
            for (int i = 0; i < aNroVertices; i++)
            {
                for (int j = i + 1; j < aNroVertices; j++)
                {
                    if (!float.IsNaN(aMatrizAdyacencia[i, j]))
                    {
                        aristas.Add(new CArista(i, j, aMatrizAdyacencia[i, j]));
                    }
                }
            }

            // Ordenar aristas por peso
            aristas.Sort((a, b) => a.Peso.CompareTo(b.Peso));

            // Procesar aristas
            foreach (var arista in aristas)
            {
                int u = Encontrar(padre, arista.I);
                int v = Encontrar(padre, arista.J);

                if (u != v)
                {
                    mst.Add(arista);
                    Union(padre, rango, u, v);
                }
            }

            return mst;
        }

        private int Encontrar(int[] padre, int u)
        {
            if (padre[u] != u)
            {
                padre[u] = Encontrar(padre, padre[u]);
            }
            return padre[u];
        }

        private void Union(int[] padre, int[] rango, int u, int v)
        {
            int raizU = Encontrar(padre, u);
            int raizV = Encontrar(padre, v);

            if (rango[raizU] > rango[raizV])
            {
                padre[raizV] = raizU;
            }
            else
            {
                padre[raizU] = raizV;
                if (rango[raizU] == rango[raizV])
                {
                    rango[raizV]++;
                }
            }
        }
    }
}