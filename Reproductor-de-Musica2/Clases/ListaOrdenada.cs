using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reproductor_de_Musica2.Clases
{
   public class ListaOrdenada : clsLista
    {
        public ListaOrdenada() : base()
        {
            //base();
        }


        public ListaOrdenada insertaOrden(string entrada)
        {
            Nodo nuevo;
            nuevo = new Nodo(entrada);

            if (primero == null)
            {
                primero = nuevo;
            }
            else if (entrada.CompareTo(primero.getDato())<0)
            {
                nuevo.setEnlace(primero);
                primero = nuevo;
            }
            else
            {
                //Busqueda del nodo anterior a partir de aqui
                Nodo anterior, p;
                anterior = p = primero;

                while ((p.getEnlace() != null) && (entrada.CompareTo(p.getDato()) >0))
                {
                    anterior = p;
                    p = p.getEnlace();
                }
                if (entrada.CompareTo(p.getDato()) >0)
                {
                    anterior = p;
                }
                nuevo.setEnlace(anterior.getEnlace());
                anterior.setEnlace(nuevo);
            }
            return this;
        }

    }
}
