namespace BibliotecaTDA;

public class cArbol
{
    // Atributos 
    private object aRaiz;
    private cArbol aHijoIzq;
    private cArbol aHermano;

    // Constructores
    public cArbol()
    {
        aRaiz = null;
        aHijoIzq = null;
        aHermano = null;        
    }

    public cArbol(object pInfo)
    {
        aRaiz = pInfo;
        aHijoIzq  = null;
        aHermano = null;
    }

    // Metodos 


}
