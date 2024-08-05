public class cDijkstra : cGrafo
{
    public cDijkstra(int pNroVertices) : base(pNroVertices) { }

    public float[] Dijkstra(int origen)
    {
        float[] distancias = new float[aNroVertices];
        bool[] visitado = new bool[aNroVertices];
        PriorityQueue<int, float> pq = new PriorityQueue<int, float>();

        // Inicializa distancias y añade el vértice de origen a la cola de prioridad
        for (int i = 0; i < aNroVertices; i++)
        {
            distancias[i] = float.MaxValue;
            visitado[i] = false;
        }
        distancias[origen] = 0;
        pq.Enqueue(origen, 0);

        while (pq.Count > 0)
        {
            int u = pq.Dequeue();

            if (visitado[u]) continue;
            visitado[u] = true;

            // Actualiza las distancias de los vértices adyacentes
            for (int v = 0; v < aNroVertices; v++)
            {
                if (!float.IsNaN(aMatrizAdyacencia[u, v]))
                {
                    float peso = aMatrizAdyacencia[u, v];
                    if (!visitado[v] && distancias[u] + peso < distancias[v])
                    {
                        distancias[v] = distancias[u] + peso;
                        pq.Enqueue(v, distancias[v]);
                    }
                }
            }
        }

        return distancias;
    }
}