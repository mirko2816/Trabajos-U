namespace BibliotecaTDA;

public delegate bool DelegadoEsValido(object X);
public delegate void DelegadoProceso(object X);
public class cArbolBB : cArbolBinario
{
    //Atributos de clase
    protected static new DelegadoEsValido deValidar = (object X) => true;
    protected static new DelegadoProceso deProcesar = (object X) => { Console.WriteLine(X.ToString()); };

    public cArbolBB()
    {
        aRaiz = null;
        aHijoIzquierdo = null;
        aHijoDerecho = null;
    }

    // Constructores

    public cArbolBB(object pRaiz)
    {
        aRaiz = pRaiz;
        aHijoIzquierdo = null;
        aHijoDerecho = null;
    }
    public static cArbolBB Crear(object pRaiz = null)
    {
        return new cArbolBB(pRaiz);
    }

    // Metodos

    public override void Agregar(Object E)
    {
        if (EsVacia())
            aRaiz = E;
        else
            if (E.ToString().CompareTo(aRaiz.ToString()) < 0)
            // -- Agregar objeto en el SubArbolIzq
            if (aHijoIzquierdo == null)
                aHijoIzquierdo = new cArbolBB(E);
            else
                aHijoIzquierdo.Agregar(E);
        else
                // -- Agregar objeto en el SubArbolDer
                if (aHijoDerecho == null)
            aHijoDerecho = new cArbolBB(E);
        else
            aHijoDerecho.Agregar(E);
    }
    
}
