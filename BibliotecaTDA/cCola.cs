namespace BibliotecaTDA;
public class cCola
{
    #region *************  ATRIBUTOS    ****************
    //**ATRIBUTOS DE METODO
    private Object aElemento;
    private cCola aSubCola;

    #endregion*********

    #region********CONSTRUCTORES*********
    public cCola()
    {
        aElemento = null;
        aSubCola = null;
    }
    public cCola(Object pElem, cCola pSubCola)
    {
        aElemento = pElem;
        aSubCola = pSubCola;
    }
    #endregion***********

    #region ************METODOS DE CLASE************
    public static cCola Crear()
    {
        return new cCola();
    }
    public static cCola Crear(Object pElem, cCola pSub)
    {
        return new cCola(pElem, pSub);
    }
    #endregion ****metodos

    #region ////////PROPIEDADES--

    public Object Elemento
    {
        get
        {
            return aElemento;
        }
        set
        {
            aElemento = value;
        }
    }
    public cCola SubCola
    {
        get
        {
            return aSubCola;
        }
        set
        {
            aSubCola = value;
        }
    }
    #endregion************propiedades
    #region******METODOS DE PROCESO******
    /* --------------------------------------------- */
    public bool EsVacia()
    {
        return ((aElemento == null) && (aSubCola == null));
    }
    public Object Cima()
    {
        return aElemento;
    }
    public void Acolar(Object pElemento)
    {
        if (EsVacia())
        {
            aElemento = pElemento;
            aSubCola = new cCola();
        }
        else
            aSubCola.Acolar(pElemento);
    }
    public void Desacolar()
    {
        if (!EsVacia())
        {
            aElemento = aSubCola.Elemento;
            aSubCola = aSubCola.SubCola;
        }
    }

    public void Listar()
    {
        if(!EsVacia())
        {
            Console.WriteLine(Cima().ToString());
            aSubCola.Listar();
        }
    }
    #endregion**********
}