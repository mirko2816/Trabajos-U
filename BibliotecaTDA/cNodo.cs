namespace BibliotecaTDA;

public class cNodo
{
    // Atributos 
    private object aInfo;
    private cNodo aSgte;

    // Constructores
    public cNodo()
    {
        aInfo = null;
        aSgte = null;
    }

    public cNodo(object pInfo)
    {
        aInfo = pInfo;
        aSgte = null;
    }

    public cNodo(object pInfo, cNodo pSgte)
    {
        aInfo = pInfo;
        aSgte = pSgte;
    }

    // Propiedades
    public object Informacion 
    {
        get {return aInfo;}
        set {aInfo = value;}
    }

    public cNodo Siguiente
    {
        get {return aSgte;}
        set {aSgte = value;}
    }

    public bool EsVacio()
    {
        if(aInfo == null && aSgte == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}