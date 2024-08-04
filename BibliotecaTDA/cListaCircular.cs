using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaTDA
{
    public class cListaCircular
    {
        // Atributos
        // Se usa como unico atributo un cNodo
        private cNodo aNodo;

        // Constructores
        public cListaCircular()
        {
            aNodo = null;
        }

        // Metodos
        // Metodo para comprobar que está vacio
        public bool EstaVacia()
        {
            return aNodo.Esvacio();
        }
        public int Longitud()
        {
            if (aNodo == null)
            {
                return 0;
            }

            // Crea una cNodo (nodoActual) y se le asigna el valor de aNodo
            cNodo nodoActual = aNodo;
            int longitud = 0;

            do
            {
                longitud++;
                nodoActual = nodoActual.SgteNodo; //asigna el sguiente nodo a nodoActual
            }
            while (nodoActual != aNodo);

            return longitud;
        }

        public void Agregar(object obj)
        {
            // Crea un nuevo nodo con el objeto obj
            cNodo nuevoNodo = new cNodo(obj);

            if (aNodo == null)
            {
                aNodo = nuevoNodo;
                aNodo.SgteNodo = aNodo;
            }
            else
            {
                // Crea una referencia al segundo nodo de la lista
                cNodo ultimoNodo = aNodo.SgteNodo;

                while (ultimoNodo.SgteNodo != aNodo)
                {
                    ultimoNodo = ultimoNodo.SgteNodo;
                }
                // Conecta el último nodo con el nuevo nodo
                ultimoNodo.SgteNodo = nuevoNodo;
                // Conecta el nuevo nodo con el primer nodo
                nuevoNodo.SgteNodo = aNodo;
            }
        }

        public void Insertar(object obj, int pos)
        {
            if (pos < 1 || pos > Longitud() + 1)
            {
                Console.WriteLine("ERROR: Posición incorrecta");
                return;
            }

            cNodo nuevoNodo = new cNodo(obj);

            if (pos == 1)
            {
                nuevoNodo.SgteNodo = aNodo;
                aNodo = nuevoNodo;

                cNodo ultimoNodo = aNodo.SgteNodo;
                // Busca el último nodo en la lista enlazada
                while (ultimoNodo.SgteNodo != aNodo)
                {
                    ultimoNodo = ultimoNodo.SgteNodo;
                }
                // Conecta el último nodo con el nuevo primer nodo
                ultimoNodo.SgteNodo = aNodo;
            }
            else
            {
                cNodo nodoAnterior = aNodo;
                int posicionActual = 1;
                // Busca el nodo anterior a la posición de inserción
                while (posicionActual < pos - 1)
                {
                    nodoAnterior = nodoAnterior.SgteNodo;
                    posicionActual++;
                }
                // Conecta el nuevo nodo con el nodo siguiente al nodo anterior y el nodo anterior con el nuevo nodo
                nuevoNodo.SgteNodo = nodoAnterior.SgteNodo;
                nodoAnterior.SgteNodo = nuevoNodo;
            }
        }

        public object Iesimo(int pos)
        {
            // Verifica si la posición es válida
            if (pos < 1 || pos > Longitud())
            {
                Console.WriteLine("ERROR: Posición incorrecta");
                return null;
            }

            cNodo nodoActual = aNodo;
            int posicionActual = 1;
            // Busca el nodo en la posición especificada
            while (posicionActual < pos)
            {
                // Asigna el siguiente nodo a nodoActual
                nodoActual = nodoActual.SgteNodo;
                posicionActual++;
            }
            // Devuelve el elemento del nodo actual o null si es nulo
            return nodoActual?.Elemento;
        }

        public int Ubicacion(object obj)
        {
            if (aNodo == null)
            {
                //Devuelve -1 para indicar que el elemento no se encontró
                return -1;
            }
            // Crea una referencia nodoActual y la inicializa con aNodo
            cNodo nodoActual = aNodo;
            // Variable para almacenar la posición actual
            int posicion = 1;
            // Busca la primera aparición del objeto en la lista enlazada
            do
            {
                if (nodoActual.Elemento.Equals(obj))
                {
                    return posicion;
                }

                nodoActual = nodoActual.SgteNodo;
                posicion++;
            }
            while (nodoActual != aNodo);

            return 0;
        }
        /* Método Eliminar para un objeto teniendo como
         * parametro la posicion del mismo */
        public void Eliminar(int pos)
        {
            if (pos < 1 || pos > Longitud())
            {
                Console.WriteLine("ERROR: Posición incorrecta");
                return;
            }
            // Si la posición es 1, se elimina el primer nodo
            if (pos == 1)
            {
                if (Longitud() == 1)    //Si la lista tiene solo un nodo devuelve vacio
                {
                    aNodo = null;
                }
                else
                {
                    // Crea una cNodo (nodoActual) y se le asigna el valor de aNodo
                    cNodo ultimoNodo = aNodo.SgteNodo;
                    // Recorre la lista hasta llegar al último nodo
                    while (ultimoNodo.SgteNodo != aNodo)
                    {
                        ultimoNodo = ultimoNodo.SgteNodo;
                    }
                    /* El segundo nodo se convierte en el primer nodo
                     * y conecta el ultimo nodo con el primero */
                    aNodo = aNodo.SgteNodo;
                    ultimoNodo.SgteNodo = aNodo;
                }
            }
            else
            {
                cNodo nodoAnterior = aNodo;
                int posicionActual = 1;
                // Recorre la lista hasta llegar al nodo anterior al nodo a eliminar
                while (posicionActual < pos - 1)
                {
                    nodoAnterior = nodoAnterior.SgteNodo;
                    posicionActual++;
                }

                cNodo nodoEliminar = nodoAnterior.SgteNodo;
                nodoAnterior.SgteNodo = nodoEliminar.SgteNodo;
            }
        }
        /* Método Eliminar para eliminar un objeto pasandole como 
         * parametro ese mismo objeto */
        public void Eliminar(object obj)
        {
            int posicion = Ubicacion(obj);

            if (posicion != 0)
            {
                Eliminar(posicion);
            }
            else
            {
                Console.WriteLine("ERROR: El elemento no existe en la lista");
            }
        }
        // Método Mostrar para mostrar los elementos de la lista
        public void Mostrar()
        {
            if (aNodo == null)
            {
                Console.WriteLine("Lista vacía");
            }
            else
            {
                cNodo nodoActual = aNodo;
                // Muestra los elementos de la lista enlazada en orden
                do
                {
                    Console.WriteLine(nodoActual.Elemento.ToString());
                    nodoActual = nodoActual.SgteNodo;
                }
                while (nodoActual != aNodo);
            }
        }

    }
}
