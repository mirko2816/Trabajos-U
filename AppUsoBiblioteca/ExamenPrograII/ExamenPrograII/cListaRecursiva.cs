namespace BibliotecaTDA;
public class cListaRecursiva
{
    private object aElemento;
    private cListaRecursiva aSublista;

    // Constructores
    public cListaRecursiva()
    {
        aElemento = null;
        aSublista = null;
    }
    public cListaRecursiva(object pElemento)
    {
        aElemento = pElemento;
        aSublista = null;
    }
    public cListaRecursiva(object pElemento, cListaRecursiva pSubLista)
    {
        aElemento = pElemento;
        aSublista = pSubLista;
    }
    // Getters y Setters
    public object Elemento
    {
        get { return aElemento; }
        set { aElemento = value; }
    }
    public cListaRecursiva SubLista
    {
        get { return aSublista; }
        set { aSublista = value; }
    }

    // Metodos
    public bool EsVacia()
    {
        return (aElemento == null && aSublista == null);
    }
    public void Agregar(object valor)
    {
        if (EsVacia())
        {
            aElemento = valor;
        }
        else
        {
            if (aSublista == null)
            {
                aSublista = new cListaRecursiva(valor);
            }
            else
            {
                aSublista.Agregar(valor);
            }
        }
    }

    public void Listar()
    {
        if (!EsVacia())
        {
            Console.WriteLine(aElemento.ToString());
            if (aSublista != null)
            {
                aSublista.Listar();
            }
        }
    }

    public int Ubicacion(Object valor)
    {
        if (aElemento.Equals(valor))
        {
            return 1;
        }
        else
        {
            return 1 + SubLista.Ubicacion(valor);
        }
    }
    public void Insertar(object valor, int n)
    {
        if (!EsVacia() && (n > 0 && n <= Longitud()))
        {
            if (n == 1)
            {
                object temp = aElemento;
                cListaRecursiva temp2 = aSublista;
                aElemento = valor;
                aSublista = new cListaRecursiva(temp, temp2);
            }
            else
            {
                Insertar(valor, n - 1);
            }
        }
    }
    public void Eliminar(int n)
    {
        if (!EsVacia() && (n > 0 && n <= Longitud()))
        {
            if (n == 1)
            {
                aElemento = aSublista.Elemento;
                aSublista = aSublista.SubLista;
            }
            else
            {
                aSublista.Eliminar(n - 1);
            }
        }
    }
    public void Eliminar(object valor)
    {
        if (ExisteElemento(valor))
        {
            int ubi = Ubicacion(valor);
            Eliminar(ubi);
        }
    }

    public bool ExisteElemento(object valor)
    {
        if (EsVacia())
        {
            return false;
        }
        else
        {
            if (aElemento == valor)
            {
                return true;
            }
            else
            {
                return SubLista.ExisteElemento(valor);
            }
        }
    }

    public object Iesimo(int n)
    {
        if (n == 0)
        {
            return aElemento;
        }
        else
        {
            return SubLista.Iesimo(n - 1);
        }
    }

    public int Longitud()
    {
        if (EsVacia())
        {
            return 0;
        }
        else if (aSublista != null)
        {
            return 1 + aSublista.Longitud();
        }
        else
        {
            return 1;
        }
    }


}