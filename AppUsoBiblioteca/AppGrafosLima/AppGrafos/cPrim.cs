public class cPrim : cGrafo
{
    public cPrim(int pNroVertices) : base(pNroVertices) { }

    public List<CArista> Prim()
    {
        List<CArista> mst = new List<CArista>();
        bool[] visitado = new bool[aNroVertices];
        float[] costo = new float[aNroVertices];
        int[] padre = new int[aNroVertices];

        for (int i = 0; i < aNroVertices; i++)
        {
            costo[i] = float.MaxValue;
            padre[i] = -1;
        }

        costo[0] = 0;

        for (int i = 0; i < aNroVertices - 1; i++)
        {
            int u = MinCostoVertice(costo, visitado);
            visitado[u] = true;

            for (int v = 0; v < aNroVertices; v++)
            {
                if (!visitado[v] && !float.IsNaN(aMatrizAdyacencia[u, v]) && aMatrizAdyacencia[u, v] < costo[v])
                {
                    padre[v] = u;
                    costo[v] = aMatrizAdyacencia[u, v];
                }
            }
        }

        for (int i = 1; i < aNroVertices; i++)
        {
            mst.Add(new CArista(padre[i], i, aMatrizAdyacencia[padre[i], i]));
        }

        return mst;
    }

    private int MinCostoVertice(float[] costo, bool[] visitado)
    {
        float min = float.MaxValue;
        int minIndex = -1;

        for (int v = 0; v < aNroVertices; v++)
        {
            if (!visitado[v] && costo[v] < min)
            {
                min = costo[v];
                minIndex = v;
            }
        }

        return minIndex;
    }
}