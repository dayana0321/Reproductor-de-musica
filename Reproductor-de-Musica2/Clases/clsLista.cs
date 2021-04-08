using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reproductor_de_Musica2.Clases
{
    public class clsLista
    {
        public Nodo primero;

        public clsLista()
        {
            primero = null;
        }

        //NUEVOS MÉTODOS

        //Busca el dato entre toda la lista el
        public Nodo buscarPosicion(int posicion)
        {
            Nodo indice;
            int i;

            if (posicion < 0)
            {
                return null;
            }

            indice = primero;

            //Va a incremetar el indice, realiza la iteración
            for (i = 1; (i < posicion) && (indice != null); i++)
            {
                indice = indice.enlace;
            }

            return indice;
        }

        //Insertar de último; inserta por la cola
        public clsLista insertarUltimo(Nodo ultimo, string entrada)
        {
            ultimo.enlace = new Nodo(entrada);
            ultimo = ultimo.enlace;
            return this;
        }

        /* public clsLista insertarCabeza(Nodo cabeza, string valor)
         {
             cabeza.enlace = new Nodo(valor);
             cabeza = cabeza.enlace;
             return this;
         }*/

        public void insertarCabeza1(String valor)
        {
            Nodo auxiliar = new Nodo();//Nodo temporal que después se agrega a la lista
            auxiliar.dato = valor;//Almacena valor en el atributo dato
            auxiliar.enlace = null;//Hacemos que el puntero enlace señale a null

            if (primero == null)
            {
                primero = auxiliar;//Al estar vacía la cola lo hacemos la cabeza
            }
            else
            {
                Nodo puntero; //Para recorrer la lista
                puntero = primero; //Dos apuntadores señalando al mismo nodo
                primero = auxiliar; //Asignamos como cabeza al nodo auxiliar
                auxiliar.enlace = puntero; //El puntero auxiliar que ahora es cabeza se enlaza con
                //el nodo que era antes la cabeza y que tiene apuntador puntero
            }
        }

        //Nuevo método para insertar por la cola

        public void insertarCola1(String valor) 
        {
            Nodo auxiliar = new Nodo();//Nodo temporal que todavía no pertenece a la lista
            auxiliar.dato = valor; //Almacena en el atributo dato el valor recibido en el parámetro
            auxiliar.enlace = null; //Hace que el apuntador señale a null

            if(primero == null) //Verifica si la lista está vacía
            {
                primero = auxiliar; //Hacemos que nodo sea parte de la lista, lo hacemos cabeza
            }
            else 
            {
                Nodo puntero; //Utilizamos este nodo para recorrer la lista, así no se mueve la cabeza
                puntero = primero; //Situamos a puntero señalando al mismo nodo que inicio

                while (puntero.enlace != null) 
                {
                    puntero = puntero.enlace; //Se desplaza por todos los nodos de la lista
                }

                puntero.enlace = auxiliar; //Hacemos que el último nodo ahora señale al auxiliar
            }
        }

        //Método para eliminar nodo que está a la cabeza de la lista

        public void EliminarCabeza() 
        {
            if (primero == null)
            {
                MessageBox.Show("Lista vacía, no se puede eliminar elemento");
            }
            else 
            {
                primero = primero.enlace;
            }
        }

        //Método para eliminar nodo al final de la lista
        public void EliminarCola() 
        {
            if (primero == null) 
            {
                MessageBox.Show("Lista vacia, no se puede eliminar elemento");
            }
            else 
            {
                Nodo punteroAnt, punteroPost;
                punteroAnt = primero;
                punteroPost = primero;

                while(punteroPost.enlace != null) 
                {
                    punteroPost = punteroPost;
                    punteroPost = punteroPost.enlace;
                }
                punteroAnt.enlace = null;
            }
        }

        //Buscar elemento en la lista, devuelve el nodo

        public Nodo buscarLista(string destino)
        {
            Nodo indice;

            for (indice = primero; indice != null; indice = indice.enlace)
            {
                if (destino.Equals(indice.dato)) //destino.equals(indic.dato) si queremos buscar un nombre
                {
                    return indice;
                }
            }

            return null;
        }

        //Eliminar una lista, 
        public void eliminar(string entrada)
        {
            Nodo actual, anterior;
            bool encontrado;
            //Inicializa los apuntadores de memoria
            actual = primero;
            anterior = null;
            encontrado = false;

            //Busqueda del nodo anterior
            while ((actual != null) && (!encontrado))
            {
                encontrado = (actual.dato.Equals(entrada));

                if (!encontrado)
                {
                    anterior = actual;
                    actual = actual.enlace;
                }

            }//end while

            //Enlace del nodo anterior con el siguiente

            if (actual != null)
            {
                //Distinguir si es el ndo inicial o cabeza o si es cualquier otro nodo de la lista

                if (actual.Equals(primero))
                {
                    primero = actual.enlace;
                }
                else
                {
                    anterior.enlace = actual.enlace;
                }
                actual = null;
            }
        }//end eliminar

        //Insertar Lista
        public clsLista insertarLista(string testigo, string entrada)
        {
            Nodo nuevo, anterior;
            anterior = buscarLista(testigo);

            if (anterior != null)
            {
                nuevo = new Nodo(entrada);
                nuevo.enlace = anterior.enlace;
                anterior.enlace = nuevo;
            }
            return this;
        }

        public void visualizar()
        {
            Nodo n;
            int k = 0;

            n = primero;

            while (n != null)
            {
                Console.WriteLine(n.dato + "");
                n = n.enlace;
                k++;
                Console.WriteLine((k % 15 != 0 ? "" : "\n"));
            }
        }
        public void visualizar1(ListBox prueba)
        {
            Nodo n;
            int k = 0;

            n = primero;

            while (n != null)
            {
                /*MessageBox.Show(n.dato + "");
                n = n.enlace;
                k++;
                MessageBox.Show((k % 15 != 0 ? "" : "\n"));*/
                
                prueba.Items.Add(n.dato);
                n = n.enlace;

                //k++;

            }
            
        }

    }
}
