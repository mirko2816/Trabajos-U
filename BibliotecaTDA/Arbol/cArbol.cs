namespace BibliotecaTDA;

/// <summary>
/// Representa un arbol simple
/// </summary>
public class cArbol
{
    // Atributos 
    private object aRaiz;
    private cArbol aHijo;
    private cArbol aHermano;

    // Constructores
    public cArbol()
    {
        aRaiz = null;
        aHijo = null;
        aHermano = null;        
    }

    public cArbol(object pInfo)
    {
        aRaiz = pInfo;
        aHijo  = null;
        aHermano = null;
    }

    // Setters y Getters
    public object Raiz
    {
        get {return aRaiz;} // no pueden tener set puesto que esto se manejara recursivamente
    }

    public cArbol Hijo
    {
        get {return aHijo;} // no pueden tener set puesto que esto se manejara recursivamente
    }

    public cArbol Hermano
    {
        get {return aHermano;}
    }

    // Metodos especiales

    /// <summary>
    /// Retorna true si los 3 atributos de nuestro arbol
    /// (Raiz, Hijo y Hermano) son nulos.
    /// </summary>
    /// <returns>Si el arbol es vacio</returns>
    public bool EsVacio()
    {
        return (aHijo == null && aHermano == null && aRaiz == null);
    }

    /// <summary>
    /// Agrega un hijo al arbol. Si el arbol es vacio agrega en este el objeto
    /// y si no es vacio aplica el metodo al hijo.
    /// </summary>
    public void Agregar(object pObjeto)
    {
        if (EsVacio())
        {
            aRaiz = pObjeto;
        }
        else
        {
            aHijo.Agregar(pObjeto);
        }
    }
}
