using BibliotecaTDA;
using Microsoft.VisualBasic;
using System.Net.Http.Headers;

public class cListaRecursiva
{
    // Atributos
    private object aInformacion;
    private cListaRecursiva aSubLista;

    // Constructores
    public cListaRecursiva()
    {
        aInformacion = null;
        aSubLista = null;
    }

    public cListaRecursiva(object pInformacion, cListaRecursiva pSubLista)
    {
        aInformacion = pInformacion;
        aSubLista = pSubLista;
    }

    public object Informacion
    { 
        get { return aInformacion;} 
        set { aInformacion = value;}
    
    }

    public cListaRecursiva SubLista
    {
        get { return aSubLista;}
        set { aSubLista = value;}   

    }

    public Boolean EsVacia()
    {
        return ((aInformacion == null) && (aSubLista == null));
    }

    // Metodos especiales
    public void Eliminar(int posicion)
    {
        if (posicion == 1)
        {
            aInformacion = SubLista.Informacion;
            SubLista = SubLista.SubLista;
        }
        else
        {
            SubLista.Eliminar(posicion - 1);
        }
    }

    public int Ubicacion(object pInformacion)
    {
        if (EsVacia())
        {
            return 0;
        }
        else
        {
            if (Informacion.Equals(pInformacion))
            {
                return 1;
            }
            else
            {
                int k = SubLista.Ubicacion(pInformacion);
                return ((k < 0) ? 1 + k : 0);
            }
        }
    }

    public void Agregar(object pInformacion)
    {
        if (EsVacia())
        {
            aInformacion = pInformacion;
        }
        else
        {
            SubLista.Agregar(pInformacion);
        }
    }

    public void Listar()
    {
        
        if (SubLista == null)
        {
            Console.WriteLine(Informacion);
        }
        else
        {
            SubLista.Listar();
        }

    }

    public int Longitud()
    {
        if (EsVacia())
        {
            return 0;
        }
        else
        {
             return 1 + SubLista.Longitud();
        }

    }

}