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

    
}
