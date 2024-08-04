namespace BibliotecaTDA;

public class cPila
{
    // Atributos
    private object aElemento;
    private cPila aSubPila;

    // Constructores
    public cPila()
    {
        aElemento = null;
        aSubPila = null;
    }
    public cPila(object pElem, cPila pSubPila)
        : base()
    {
        aElemento = pElem;
        aSubPila = pSubPila;
    }
    

    // Metodos de clase
    public static cPila Crear()
    {
        return new cPila();
    }
    public static cPila Crear(object pElem, cPila pSub)
    {
        return new cPila(pElem, pSub);
    }
    

    // Setters y Getters
    public object Elemento
    {
        get { return aElemento; }
        set { aElemento = value; }
    }
    public cPila SubPila
    {
        get { return aSubPila; }
        set { aSubPila = value; }
    }
    
    // Metodos
    public bool EsVacia()
    {
        return (aElemento == null) && (aSubPila == null);
    }
    public object Cima()
    {
        return aElemento;
    }
    public void Apilar(object pElemento)
    {
        aSubPila = new cPila(aElemento, aSubPila);
        aElemento = pElemento;
    }
    public void Desapilar()
    {
        if (!EsVacia())
        {
            aElemento = aSubPila.Elemento;
            aSubPila = aSubPila.SubPila;
        }
    }

}
