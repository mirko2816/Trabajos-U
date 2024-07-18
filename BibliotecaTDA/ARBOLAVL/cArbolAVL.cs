namespace BibliotecaTDA;

public class cArbolAVL : cArbolBB
{
#region ***********************  Atributos   *************************
    private int aFE; // -- Factor de equilibrio, necesario para determinar si un nodo está o no balanceado
    #endregion Atributos  

    #region  ======================  Constructores  ======================= 
    /* -------------------------------------------------------------- */
    public cArbolAVL() : base()
    {
        aFE = 0;
    }

    /* -------------------------------------------------------------- */
    public cArbolAVL(Object pRaiz) : base(pRaiz)
    {
        aFE = 0;
    }

    /* -------------------------------------------------------------- */
    public cArbolAVL(cArbolAVL pSubArbolIzq, Object pRaiz, cArbolAVL pSubArbolDer)
        : base(pSubArbolIzq, pRaiz, pSubArbolDer)
    {
        aFE = 0;
    }


    /* -------------------------------------------------------------- */
    public static cArbolAVL CrearAVL()
    {
        return new cArbolAVL();
    }

    /* -------------------------------------------------------------- */
    public static cArbolAVL CrearAVL(Object pRaiz)
    {
        return new cArbolAVL(pRaiz);
    }

    /* -------------------------------------------------------------- */
    public static cArbolAVL CrearAVL(cArbolAVL pSubArbolIzq, Object pRaiz, cArbolAVL pSubArbolDer)
    {
        return new cArbolAVL(pSubArbolIzq, pRaiz, pSubArbolDer);
    }
    #endregion Constructores

    #region *********************  Propiedades  ***********************
    /* ---------------------------------------------------------- */
    public int FE
    {
        get
        {
            return aFE;
        }
        set
        {
            aFE = value;
        }
    }

    #endregion *********************  Propiedades  ***********************

    #region ====================   Metodos    ====================== 

    /* -------------------------------------------------------------- */
    /*
        private bool EstaBalanceado()
        {
            int Altura1 = (aHijoIzquierdo==null ? 0 :1+aHijoIzquierdo.Altura()); 
            int Altura2 = (aHijoDerecho==null ? 0 :1+aHijoDerecho.Altura()); 
            return (Math.Abs(Altura1-Altura2)<2);
        }
    */

    /* -------------------------------------------------------------- */
    protected void RotacionSimpleIzq(bool FlagFE = true)
    {
        // La rotación se efectuara primero creando un nuevo arbol y reordenando los enlaces de los arboles
        aHijoDerecho = cArbolAVL.CrearAVL(aHijoIzquierdo.aHijoDerecho as cArbolAVL, Raiz, aHijoDerecho as cArbolAVL);
        Raiz = aHijoIzquierdo.Raiz;
        aHijoIzquierdo = aHijoIzquierdo.aHijoIzquierdo;
        // -- Actualizar FE
        if (FlagFE)
        {
            FE = 0; // -- El nodo donde se realizaó la rotación, está balanceado
            (aHijoDerecho as cArbolAVL).FE = 0; // -- El nodo rotado también está balanceado
        }
    }

    /* -------------------------------------------------------------- */
    protected void RotacionDobleIzq(Object Elemento)
    {
        // -- Determinar condicones para actualizar FE
        bool FlagHoja = aHijoIzquierdo.aHijoDerecho.EsHoja();
        bool FlagIzqDerIzq = false;
        if (!FlagHoja)
            FlagIzqDerIzq = (Elemento.ToString().CompareTo(aHijoIzquierdo.aHijoDerecho.Raiz.ToString()) < 0);
        // -- Efectuar rotaciones
        ((cArbolAVL)aHijoIzquierdo).RotacionSimpleDer(false);
        RotacionSimpleIzq(false);
        // -- Actualizar factor de equilibrio
        FE = 0; // -- El nodo donde se efectúa la rotación está balanceado
        if (FlagHoja)
            (aHijoDerecho as cArbolAVL).FE = 0;
        else if (FlagIzqDerIzq)
        {
            (aHijoIzquierdo as cArbolAVL).FE = 0;
            (aHijoDerecho as cArbolAVL).FE = 1;
        }
        else
        {
            (aHijoIzquierdo as cArbolAVL).FE = -1;
            (aHijoDerecho as cArbolAVL).FE = 0;
        }
    }

    /* -------------------------------------------------------------- */
    protected void RotacionSimpleDer(bool FlagFE = true)
    {
        // La rotación se efectuara primero creando un nuevo arbol y reordenando los enlaces de los arboles
        aHijoIzquierdo = cArbolAVL.CrearAVL(aHijoIzquierdo as cArbolAVL, Raiz, aHijoDerecho.aHijoIzquierdo as cArbolAVL);
        Raiz = aHijoDerecho.Raiz;
        aFE = 0;
        aHijoDerecho = aHijoDerecho.aHijoDerecho;
        // -- Actualizar FE
        if (FlagFE)
        {
            FE = 0; // -- El nodo donde se realizaó la rotación, está balanceado
            (aHijoIzquierdo as cArbolAVL).FE = 0; // -- El nodo rotado también está balanceado
        }
    }

    /* -------------------------------------------------------------- */
    protected void RotacionDobleDer(Object Elemento)
    {
        // -- Determinar condicones para actualizar FE
        bool FlagHoja = aHijoDerecho.aHijoIzquierdo.EsHoja();
        bool FlagDerIzqDer = false;
        if (!FlagHoja)
            FlagDerIzqDer = (Elemento.ToString().CompareTo(aHijoDerecho.aHijoIzquierdo.Raiz.ToString()) > 0);
        // -- Efectuar rotaciones
        ((cArbolAVL)aHijoDerecho).RotacionSimpleIzq(false);
        RotacionSimpleDer(false);
        // -- Actualizar factor de equilibrio
        FE = 0; // -- El nodo donde se efectúa la rotación está balanceado
        if (FlagHoja)
            (aHijoIzquierdo as cArbolAVL).FE = 0;
        else if (FlagDerIzqDer)
        {
            (aHijoIzquierdo as cArbolAVL).FE = -1;
            (aHijoDerecho as cArbolAVL).FE = 0;
        }
        else
        {
            (aHijoIzquierdo as cArbolAVL).FE = 0;
            (aHijoDerecho as cArbolAVL).FE = 1;
        }
    }

    /* -------------------------------------------------------------- */
    public int Agregar(object Elemento)
    {
        int Ind = 0;
        if (Raiz == null)
            Raiz = Elemento;
        else
            if (Elemento.ToString().CompareTo(Raiz.ToString()) < 0)
        {   // Agregar el nuevo elemento como hijo Izq
            if (aHijoIzquierdo == null)
            {
                aHijoIzquierdo = cArbolAVL.CrearAVL(null, Elemento, null);
                aFE--;
                Ind = 1;
            }
            else
            {
                Ind = (aHijoIzquierdo as cArbolAVL).Agregar(Elemento);
                if (Ind != 0)
                {
                    aFE -= Ind;
                    // Balancear arbol si esta desbalanceado 
                    if (aFE == -2) // Si el Factor de equilibrio es -2 entonces hay desbalance
                    {
                        if (Elemento.ToString().CompareTo(aHijoIzquierdo.Raiz.ToString()) < 0)
                            RotacionSimpleIzq();
                        else
                            RotacionDobleIzq(Elemento);
                        Ind = 0;
                    }
                }
            }
        }
        else
        {   // Agregar el nuevo elemento como hijo Der
            if (aHijoDerecho == null)
            {
                aHijoDerecho = cArbolAVL.CrearAVL(null, Elemento, null);
                aFE++;
                Ind = 1;
            }
            else
            {
                Ind = (aHijoDerecho as cArbolAVL).Agregar(Elemento);
                if (Ind != 0)
                {
                    aFE++;
                    // Balancear arbol si esta desbalanceado 
                    if (aFE == 2)
                    {
                        if (Elemento.ToString().CompareTo(aHijoDerecho.Raiz.ToString()) > 0)
                            RotacionSimpleDer();
                        else
                            RotacionDobleDer(Elemento);
                        Ind = 0;
                    }
                }
            }
        }
        return Ind;
    }

    /* -------------------------------------------------------------- */
    public void PreOrdenFE()
    {
        if (Raiz != null)
        {
            // ----- Procesar la raiz
            Console.WriteLine(Raiz.ToString() + "- " + aFE.ToString());
            // ----- Procesar hijo Izq 
            if (aHijoIzquierdo != null)
                (aHijoIzquierdo as cArbolAVL).PreOrdenFE();
            // ----- Procesar hijo Der 
            if (aHijoDerecho != null)
                (aHijoDerecho as cArbolAVL).PreOrdenFE();
        }
    }
    #endregion Metodos
    
}
