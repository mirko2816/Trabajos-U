public class cGrafo
{

    #region *********************** ATRIBUTOS ************************
    protected int aNroVertices;
    protected object[] aVertices;
    protected float[,] aMatrizAdyacencia;
    #endregion *********************** ATRIBUTOS ************************

    #region *********************** METODOS ************************
    #region ==================== CONSTRUCTORES =======================
    // ----------------------------------------------------------------
    public cGrafo()
    {
        aNroVertices = 10;
        aVertices = new object[aNroVertices];
        aMatrizAdyacencia = new float[aNroVertices, aNroVertices];
    }

    // ----------------------------------------------------------------
    public cGrafo(int pNroVertices)
    {
        aNroVertices = pNroVertices;
        aVertices = new object[aNroVertices];
        aMatrizAdyacencia = new float[aNroVertices, aNroVertices];
    }
    #endregion ==================== CONSTRUCTORES =======================

    #region ==================== PROPIEDADES =======================
    // ----------------------------------------------------------------
    public int NroVertices
    {
        get { return aNroVertices; }
        set { aNroVertices = value > 0 ? value : aNroVertices; }
    }
    #endregion ==================== PROPIEDADES =======================

    #region ==================== MÉTODOS PROCESO =======================
    // ----------------------------------------------------------------
    public void InicializarMatrizAdyacencia()
    {
        // -- Redimensionar la matriz de adyacencia */
        aMatrizAdyacencia = new float[aNroVertices, aNroVertices];
        // -- Inicializar valores de la matriz de adyacencia
        for (int F = 0; F < aNroVertices; F++)
            for (int C = 0; C < aNroVertices; C++)
                aMatrizAdyacencia[F, C] = float.NaN;
    }

    // ----------------------------------------------------------------
    public void LeerDeArchivo(String Archivo)
    {
        // -- Abrir archivo
        StreamReader SR = new StreamReader(Archivo);
        // -- Leer Número de vertices
        aNroVertices = int.Parse(SR.ReadLine());
        // -- Inicializar la matriz de adyacencia */            
        InicializarMatrizAdyacencia();
        // -- Leer relaciones entre vertices
        for (int V = 0; V < aNroVertices; V++)
        {
            // -- Recuperar valores de la V-ésima fila
            string[] Valores = SR.ReadLine().Split(',');
            // -- Recuperar valor de cada elemento de la celda
            for (int C = 0; C < aNroVertices; C++)
                if (Valores[C] == "NaN")
                    aMatrizAdyacencia[V, C] = float.NaN;
                else
                    aMatrizAdyacencia[V, C] = float.Parse(Valores[C]);
        }
        // -- Cerrar archivo
        SR.Close();
    }

    // ----------------------------------------------------------------
    public void Leer()
    {
        // -- Mostrar titulo
        Console.WriteLine("INGRESAR DATOS DEL GRAFO");
        // -- Nro de vertices */
        Console.Write("Ingrese número de vértices: ");
        aNroVertices = int.Parse(Console.ReadLine());
        // -- Inicializar la matriz de adyacencia */            
        InicializarMatrizAdyacencia();
        // -- Leer aristas 
        bool FlagMasAristas = true;
        Console.WriteLine("INGRESAR ARISTAS");
        do
        {
            // -- Leer datos de arista
            Console.WriteLine();
            Console.WriteLine("Ingrese datos de una arista: ");
            Console.Write("Ingrese vértice Origen: ");
            int VOrigen = int.Parse(Console.ReadLine());
            Console.Write("Ingrese vértice Destino: ");
            int VDestino = int.Parse(Console.ReadLine());
            Console.Write("Ingrese valor de la arista: ");
            float ValorArista = float.Parse(Console.ReadLine());
            // -- Almacenar en la matriz de adyacencia
            aMatrizAdyacencia[VOrigen, VDestino] = ValorArista;
            aMatrizAdyacencia[VDestino, VOrigen] = ValorArista;
            // -- Determinar si hay mas aristas
            Console.WriteLine();
            Console.Write("¿Hay más aristas? <S>: ");
            string Rpta = Console.ReadLine();
            FlagMasAristas = (Rpta == "s") || (Rpta == "S");
        } while (FlagMasAristas);
    }
    // ----------------------------------------------------------------
    public void Mostrar()
    {
        // Limpiar pantalla
        Console.Clear();

        // Mostrar Matriz de adycencia
        Console.WriteLine("MATRIZ DE ADYACENCIA DEL GRAFO");
        Console.WriteLine();

        // -- Mostrar Vertices 
        for (int V = 0; V < aNroVertices; V++)
        {
            // -- Poner vertices al inicio de las columnas
            Console.SetCursorPosition((V + 1) * 10, 1);
            Console.WriteLine("V" + (V + 1));
            // -- Poner vertices al inicio de las filas
            Console.SetCursorPosition(2, V + 2);
            Console.WriteLine("V" + (V + 1));
        }

        // -- Mostrar valor de las aristas
        for (int F = 0; F < aNroVertices; F++)
        {
            for (int C = 0; C < aNroVertices; C++)
            {
                Console.SetCursorPosition((C + 1) * 10, F + 2);
                Console.WriteLine(aMatrizAdyacencia[C, F]);
            }
        }

    }

    // ----------------------------------------------------------------
    public void GrabarEnArchivo(String Archivo)
    {
        // -- Abrir archivo
        StreamWriter SW = new StreamWriter(Archivo);
        // -- Grabar Número de vertices
        SW.WriteLine(aNroVertices.ToString());
        // -- Grabar matriz de adyacencia
        for (int V = 0; V < aNroVertices; V++)
        {
            // -- Generar texto con datos de cada fila
            string TextoFila = "";
            string Separador = "";
            for (int C = 0; C < aNroVertices; C++)
            {
                if (float.IsNaN(aMatrizAdyacencia[V, C]))
                    TextoFila = Separador + "NaN";
                else
                    TextoFila = Separador + aMatrizAdyacencia[V, C].ToString();
            }
            // -- Grabar texto fila
            SW.WriteLine(TextoFila);
        }
        // -- Cerrar archivo
        SW.Close();
    }

    public float getPeso(int i, int j)
    {

        return aMatrizAdyacencia[(int)i, (int)j];
    }

    #endregion ==================== MÉTODOS PROCESO =======================

    #endregion *********************** METODOS ************************
}