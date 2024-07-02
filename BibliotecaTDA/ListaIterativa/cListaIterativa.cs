namespace BibliotecaTDA;

public class cListaIterativa
{
    // Atributos
    private cNodo aPrimerNodo;
    private int aNroElementos;

    // Constructores
    public cListaIterativa()
    {
        aPrimerNodo = new cNodo();
        aNroElementos = 0;
    }

    public cListaIterativa(cNodo pPrimerNodo)
    {
        aPrimerNodo = pPrimerNodo;
    }

    public cListaIterativa(cNodo pPrimerNodo, int pNroElementos)
    {
        aPrimerNodo = pPrimerNodo;
        aNroElementos = pNroElementos;
    }

    // Propiedades
    public cNodo PrimerNodo
    {
        get {return aPrimerNodo;}
        set {aPrimerNodo = value;}
    }

    public int NumeroElementos
    {
        get {return aNroElementos;}
    }

    // Metodos
    public bool EsVacio()
    {
        return aPrimerNodo == null;
    }

    public void Listar()
    {
        // Recorre nodos y procesa cada elemento
        cNodo nodoAux = aPrimerNodo;
        while (nodoAux != null)
        {
            Console.WriteLine(nodoAux.Informacion.ToString());
            nodoAux = nodoAux.Siguiente;
        }
    }

    public object Iesimo(int indice)
    {
        cNodo nodoAux = aPrimerNodo;
        int i = 0;
        while (i != indice)
        {
            nodoAux = nodoAux.Siguiente;
            i++;
        }
        return nodoAux;
    }

    public void Agregar(object Informacion)
    {
         if (aPrimerNodo.EsVacio())
        {
            aPrimerNodo = new cNodo(Informacion);
        }
        else
        {
            cNodo nuevo = new cNodo(Informacion);
            cNodo nodoAux = aPrimerNodo;
            while (nodoAux.Siguiente != null)
            {
                nodoAux = nodoAux.Siguiente;
            }
            nodoAux.Siguiente = nuevo;
        }   
    }

    public void Insertar(Object valor, int n)
    {
        cNodo nuevo = new cNodo(valor);
        cNodo aux1 = aPrimerNodo;
        cNodo aux2 = null;
        for (int i = 0; i < n; i++)
        {
            aux1 = aux1.Siguiente;
        }
        aux2 = aux1.Siguiente;
        aux1.Siguiente = nuevo;
        nuevo.Siguiente = aux2;
    }

    public void Eliminar(Object valor)
    {
        cNodo aux1 = aPrimerNodo;
        cNodo aux2 = null;
        while ((valor.Equals(aux1) == false) && (aux1 != null))
        {
            aux2 = aux1;
            aux1 = aux1.Siguiente;
        }
        if (aux1 != null)
        {
            if (aux2 == null)
            {
                aPrimerNodo = aux1.Siguiente;
            }
            else
            {
                aux2.Siguiente = aux1.Siguiente;
            }
        }
    }

    public int Ubicacion(Object valor)
    {
        cNodo aux = aPrimerNodo;
        int posicion = 0;
        while ((valor.Equals(aux) == false) && (aux != null))
        {
            aux = aux.Siguiente;
            posicion++;
        }
        if (aux == null)
        {
            return -1;
        }
        return posicion;
    }

    public int Longitud()
        {
            int contador = 1;
            cNodo aux = aPrimerNodo;
            while (aux.Siguiente != null)
            {
                aux = aux.Siguiente;
                contador++;
            }
            return contador;
        }
}
