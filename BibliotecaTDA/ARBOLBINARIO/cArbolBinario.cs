namespace BibliotecaTDA;

public class cArbolBinario
{
    public delegate bool DelegadoEsValido(object X);
    public delegate void DelegadoProceso(object X);

    //Atributos de objeto
    protected object aRaiz;
    public cArbolBinario aHijoDerecho;
    public cArbolBinario aHijoIzquierdo;

    //Atributos de clase
    protected static DelegadoEsValido deValidar = (object X) => true;
    protected static DelegadoProceso deProcesar = (object X) => { Console.WriteLine(X.ToString()); };

    // CONSTRUCTORES

    public cArbolBinario()
    {
        aRaiz = null;
        aHijoIzquierdo = null;
        aHijoDerecho = null;
    }

    public cArbolBinario(object pRaiz)
    {
        aRaiz = pRaiz;
        aHijoIzquierdo = null;
        aHijoDerecho = null;
    }

    public static cArbolBinario Crear(object pRaiz = null)
    {
        return new cArbolBinario(pRaiz);
    }

    

    // SETTERS Y GETTERS

    public object Raiz
    {
        get { return aRaiz; }
        set { aRaiz = value; }
    }
    public virtual cArbolBinario HijoDerecho
    {
        get { return aHijoDerecho; }
        set { aHijoDerecho = value; }
    }
    public virtual cArbolBinario HijoIzquierdo
    {
        get { return aHijoIzquierdo; }
        set { aHijoIzquierdo = value; }
    }

    public static void CambiarValidacion(DelegadoEsValido pDel) // podremos enviar una funcion lambda para que, por ejemplo, solo acepte numeros positivos
    {
        if (pDel != null)
            deValidar = pDel;
    }
    public static void CambiarProcesar(DelegadoProceso pDel)
    {
        if (pDel != null)
            deProcesar = pDel;
    }

    // METODOS

    public bool EsVacia()
    {
        return aRaiz == null;
    }
    public override string ToString()
    {
        return aRaiz.ToString(); // Imprimira el valor ToString overraideado del objeto que tenga la raiz
    }

    public bool EstaCompleto()
    {
        if (!EsVacia())
        {
            bool Completo = true;
            if ((aHijoDerecho != null && aHijoIzquierdo != null))
            {
                return Completo && aHijoDerecho.EstaCompleto() && aHijoIzquierdo.EstaCompleto();
            }
            else
                if ((aHijoDerecho == null && aHijoIzquierdo == null))
                return true;
            else
                return false;
        }
        else
            return false;
    }

    public virtual void Agregar(object pElem)
    {
        if (pElem != null)
        {
            if (aRaiz == null)
                aRaiz = pElem;

            else
            {
                if (aHijoIzquierdo == null || !aHijoIzquierdo.EsVacia())
                    aHijoIzquierdo = new cArbolBinario(pElem);

                else
                {
                    if (aHijoDerecho == null || !aHijoDerecho.EsVacia())
                        aHijoDerecho = new cArbolBinario(pElem);

                    else
                    {
                        if (aHijoIzquierdo.EstaCompleto())
                        {
                            if (aHijoDerecho.EstaCompleto())
                                aHijoIzquierdo.Agregar(pElem);
                            else
                                aHijoDerecho.Agregar(pElem);
                        }
                        else
                            aHijoIzquierdo.Agregar(pElem);
                    }
                }
            }
        }
    }

    public object Hoja()
    {
        if (aHijoIzquierdo == null || aHijoIzquierdo.EsVacia())
        {
            if (aHijoDerecho == null || aHijoDerecho.EsVacia())
                return aRaiz;
            else
                return aHijoDerecho.Hoja();
        }
        else
            return aHijoIzquierdo.Hoja();

    }

    public bool EsHoja()
    {
        if (aHijoIzquierdo == null || aHijoIzquierdo.EsVacia())
        {
            if (aHijoDerecho == null || aHijoDerecho.EsVacia())
                return true;
            else
                return aHijoDerecho.EsHoja();
        }
        else
            return aHijoIzquierdo.EsHoja();

    }

    public virtual void Eliminar(object pElem)
    {
        if (!EsVacia() && pElem != null)
        {
            if (pElem.Equals(aRaiz))
            {
                if (aHijoDerecho == null && aHijoIzquierdo == null)
                    aRaiz = null;

                else
                {
                    if (aHijoIzquierdo != null)
                    {
                        aRaiz = aHijoIzquierdo.Hoja();
                        aHijoIzquierdo.Eliminar(aRaiz);
                    }
                    else
                    {
                        aRaiz = aHijoDerecho.Hoja();
                        aHijoDerecho.Eliminar(aRaiz);
                    }
                }
            }
            else
            {
                if (aHijoIzquierdo != null)
                    aHijoIzquierdo.Eliminar(pElem);
                if (aHijoDerecho != null)
                    aHijoDerecho.Eliminar(pElem);
            }
        }
    }

    public bool RecorrerNivel(int k)
    {
        bool Aux = false;
        if (k == 0 && !EsVacia())
        {
            if (deValidar(aRaiz))
                deProcesar(aRaiz);
            return true;
        }
        else
        {
            if (EsVacia())
                return false;
            else
            {
                k--;
                if (aHijoIzquierdo != null)
                {
                    Aux = aHijoIzquierdo.RecorrerNivel(k) || Aux;
                }
                if (aHijoDerecho != null)
                {
                    Aux = aHijoDerecho.RecorrerNivel(k) || Aux;
                }
                return Aux;
            }
        }
    }

    public virtual cArbolBinario SubArbol(object pRaiz)
    {

        if (!EsVacia() && pRaiz != null)
        {
            if (aRaiz.Equals(pRaiz))
                return this;
            else
            {
                cArbolBinario Temp = null;
                if (aHijoIzquierdo != null)
                    Temp = aHijoIzquierdo.SubArbol(pRaiz);
                if (Temp == null)
                {
                    if (aHijoDerecho != null)
                        Temp = aHijoDerecho.SubArbol(pRaiz);
                }
                return Temp;
            }
        }
        else
            return null;
    }

    public void Procesar()
    {
        if (!EsVacia())
        {
            if (deValidar(aRaiz))
                deProcesar(aRaiz);
        }
    }

    public void Procesar(object aElem)
    {
        if (aElem != null)
        {
            if (deValidar(aElem))
                deProcesar(aElem);
        }
    }
    public void RecorrerPreOrden()
    {
        Procesar();
        if (aHijoIzquierdo != null)
            aHijoIzquierdo.RecorrerPreOrden();
        if (aHijoDerecho != null)
            aHijoDerecho.RecorrerPreOrden();
    }

    public void RecorrerInOrden()
    {
        if (aHijoIzquierdo != null)
            aHijoIzquierdo.RecorrerInOrden();
        Procesar();
        if (aHijoDerecho != null)
            aHijoDerecho.RecorrerInOrden();
    }
    public void RecorrerPosOrden()
    {

        if (aHijoIzquierdo != null)
            aHijoIzquierdo.RecorrerPosOrden();
        if (aHijoDerecho != null)
            aHijoDerecho.RecorrerPosOrden();
        Procesar();
    }
    public void RecorrerPorNiveles()
    {
        if (aRaiz != null)
        {
            cCola Cola = cCola.Crear();
            Cola.Acolar(this);
            cArbolBinario Aux;
            while (!Cola.EsVacia())
            {
                Aux = Cola.Cima() as cArbolBinario;
                Procesar(Aux.Raiz);
                if (Aux.HijoDerecho != null)
                    Cola.Acolar(Aux.HijoDerecho);
                if (Aux.HijoIzquierdo != null)
                    Cola.Acolar(Aux.aHijoIzquierdo);
                Cola.Desacolar();
            }
        }
    }

    public int Altura()
    {
        int AltIz = 0, AltDer = 0;
        if (aHijoIzquierdo != null)
            AltIz = 1 + aHijoIzquierdo.Altura();
        if (aHijoDerecho != null)
            AltDer = 1 + aHijoDerecho.Altura();
        return AltIz > AltDer ? AltIz : AltDer;
    }
    public void Podar()
    {
        if (!EsVacia())
        {
            if (aHijoIzquierdo != null)
            {
                if (aHijoIzquierdo.EsVacia())
                    aHijoIzquierdo = null;
                else
                    aHijoIzquierdo.Podar();
            }
            if (aHijoDerecho != null)
            {
                if (aHijoDerecho.EsVacia())
                    aHijoDerecho = null;
                else
                    aHijoDerecho.Podar();
            }
        }
    }

    internal object MayorElemento()
    {
        throw new NotImplementedException();
    }

    internal object MenorElemento()
    {
        throw new NotImplementedException();
    }
}