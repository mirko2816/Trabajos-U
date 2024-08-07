﻿using System.Runtime.InteropServices.ObjectiveC;

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
        set {aHijo = value;}
    }

    public cArbol Hermano
    {
        get {return aHermano;}
        set {aHermano = value;}
    }

    public void ModificarHijo(cArbol hijo)
    {
        aHijo = hijo;
    }

    public void ModificarHermano(cArbol hermano)
    {
        aHermano = hermano;
    }

    // Metodos especiales

    /// <summary>
    /// Determina si la raiz del arbol apunta a null.
    /// </summary>
    /// <returns>Si el arbol es vacio</returns>
    public bool EsVacio()
    {
        return aRaiz == null;
    }
    
    /// <summary>
    /// Agrega un subarbol hijo al subarbol padre y asigna el objeto
    /// pObjeto como raiz del subarbol creado
    /// </summary>
    /// <param name="pSubarbolPadre">Subarbol a buscar en el arbol</param>
    /// /// <param name="pObjeto">Objeo a agregar en el sub arbol padre.</param>
    public void Agregar(cArbol pSubarbolPadre, object pObjeto)
    {
        // Si el arbol esta vacio y el subarbolpadre es nulo
        if (EsVacio() && pSubarbolPadre == null)
        {
            aRaiz = pObjeto;
        }
        else
        {
            if(pSubarbolPadre == SubArbol(pSubarbolPadre.Raiz))
            {
                pSubarbolPadre.AgregarHijo(pObjeto);
            }
            else
            {
                Console.WriteLine("El subarbol padre no pertenece al arbol.");
            }
        }
    }

    /// <summary>
    /// Busca en el arbol el SubArbol en el que la raiz es igual a pObjeto
    /// </summary>
    /// <param name="pObjeto">Objeo a buscar en nuestro arbol.</param>
    public cArbol SubArbol(object pObjeto)
    {
        if(EsVacio())
        {
            return null;
        }
        else
        {
            // Verificamos si la raiz es del subarbol buscado
            if (aRaiz.Equals(pObjeto))
            {
                return this;
            }
            else
            {
                // Busca el primer hijo (si existe)
                cArbol arbolAux = null;
                if (aHijo != null)
                {
                    arbolAux = aHijo.SubArbol(pObjeto);
                }
                if ((arbolAux == null) && (aHermano != null))
                {
                    arbolAux = aHermano.SubArbol(pObjeto);
                }
                return arbolAux;
            }
        }
    }

    /// <summary>
    /// Agrega un subarbol hijo al arbol acutal, como hijo y si este ya tiene hijo
    /// se agrega como hermano y asigna el objeto pObjeto a la raiz del subarbol agregado.
    /// </summary>
    /// <param name="pObjeto">Objeto a agregar en el subarbol agregado</param>
    public cArbol AgregarHijo(object pObjeto)
    {
        if (aHijo == null)
        {
            aHijo = new cArbol(pObjeto);
            return aHijo;
        }
        else
        {
            return aHijo.AgregarHermano(pObjeto);
        }
    }

    /// <summary>
    /// Agrega un subarbol hermano al arbol acutal, como hijo y si este ya tiene un hermano,
    /// aplica la operacion al siguiente hermano.
    /// </summary>
    /// <param name="pObjeto">Objeto a agregar en el subarbol agregado</param>
    public cArbol AgregarHermano(object pObjeto)
    {
        if (aHermano == null)
        {
            aHermano = new cArbol(pObjeto);
            return aHermano;
        }
        else
        {
            return aHermano.AgregarHermano(pObjeto);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pObjeto"> </param>
    public cArbol Padre(object pObjeto)
    {
        if (EsVacio())
        {
            return null;
        }
        else
        {
            if (EsHijo(pObjeto))
            {
                return this;
            }
            else
            {
                cArbol arbolAux = null;
                if(aHijo != null)
                {
                    arbolAux = aHijo.Padre(pObjeto);
                }
                if(arbolAux == null && aHermano != null)
                {
                    arbolAux = aHermano.Padre(pObjeto);
                }
                return arbolAux;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pObjeto"> </param>
    public bool EsHijo(object pObjeto)
    {
        if (EsVacio() || aHijo == null)
        {
            return false;
        }
        else
        {
            return (aHijo.Raiz.Equals(pObjeto) ? true : aHijo.EsHermano(pObjeto));
        }
    }

    public bool EsHermano(object pObjeto)
    {
        if (EsVacio() || aHermano == null)
        {
            return false;
        }
        else
        {
            return (aHermano.Raiz.Equals(pObjeto)) ? true : aHermano.EsHermano(pObjeto);
        }
    }

    public void Eliminar(cArbol pArbol)
    {
        if ( pArbol != null && pArbol == SubArbol(pArbol.Raiz))
        {
            cArbol arbolPadre = Padre(pArbol.Raiz);
            if(arbolPadre == null)
            {
                aRaiz = null;
                aHijo = null;
                aHermano = null;
            }
            else
            {
                if (pArbol == arbolPadre.Hijo)
                {
                    cArbol arbolAux = arbolPadre.Hijo.Hermano;
                    arbolPadre.ModificarHijo(arbolAux);
                }
                else
                {
                    arbolPadre.Hijo.EliminarHermano(pArbol);
                }
            }
        }
    }

    protected void EliminarHermano(cArbol pArbol)
    {
        if (pArbol == aHermano)
        {
            ModificarHermano(aHermano.Hermano);
        }
        else
        {
            aHermano.EliminarHermano(pArbol);
        }
    }

    public void Procesar()
    {
        if (!EsVacio())
        {
            Console.WriteLine(Raiz);
        }
    }

    public void PreOrden()
    {
        if (!EsVacio())
        {
            Procesar();
            if (aHijo != null)
            {
                aHijo.PreOrden();
                aHijo.RecorrerHermanoPreorden();
            }
        }
    }

    protected void RecorrerHermanoPreorden()
    {
        if (aHermano != null)
        {
            aHermano.PreOrden();
            aHermano.RecorrerHermanoPreorden();
        }
    }

    public void InOrden()
    {
        if(!EsVacio())
        {
            if(aHijo != null)
            {
                aHijo.InOrden();

                Procesar();

                if(aHijo != null)
                {
                    aHijo.RecorrerHermanoInOrden();
                }
            }
        }
    }

    protected void RecorrerHermanoInOrden()
    {
        if(aHermano != null)
        {
            aHermano.InOrden();
            aHermano.RecorrerHermanoInOrden();
        }
    }

    public void PosOrden()
    {
        if (!EsVacio())
        {
            if(aHijo != null)
            {
                aHijo.PosOrden();
                aHijo.RecorrerHermanoPosOrden();
            }

            Procesar();
        }
    }

    protected void RecorrerHermanoPosOrden()
    {
        if(aHermano != null)
        {
            aHermano.RecorrerHermanoPosOrden();
            aHermano.PosOrden();
        }
    }

    public int Altura()
    {
        if(EsVacio())
        {
            return 0;
        }
        else
        {
            if(aHijo != null)
            {
                int altura1 = 1 + aHijo.Altura();
                int altura2 = 1 + aHijo.AlturaHermanos();
                return (altura1>altura2?altura1:altura2);
            }
            else
            {
                return 0;
            }
        }
    }

    protected int AlturaHermanos()
    {
        if(aHermano == null)
        {
            return 0;
        }
        else
        {
            int altura1 = aHermano.Altura();
            int altura2 = aHermano.AlturaHermanos();
            return (altura1 > altura2 ? altura1 : altura2);
        }
    }
}

