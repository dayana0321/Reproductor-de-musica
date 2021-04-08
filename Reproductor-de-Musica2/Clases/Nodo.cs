using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reproductor_de_Musica2.Clases
{
   public  class Nodo
    {
        public string dato;
        public Nodo enlace;

        public Nodo() 
        {

        }

        public Nodo(string x)
        {
            dato = x;
            //Es el primer nodo por lo tanto no tiene sucesor
            enlace = null;
        }

        public Nodo(string x, Nodo n)
        {
            dato = x;
            enlace = n;
        }

        //Para devolver los valores 
        public string getDato()
        {
            return dato;
        }

        public Nodo getEnlace()
        {
            return enlace;
        }

        //Asignarle valor al enlace
        public void setEnlace(Nodo enlace)
        {
            this.enlace = enlace;
        }


    }
}
