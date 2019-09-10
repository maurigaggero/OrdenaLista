using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMLista.Clases
{
    public class Lista
    {
        #region PROPIEDADES
        private string[] lista = new string[1];

        private int ProximaPosicion = 0;
        #endregion

        #region CONSTRUCTOR
        #endregion

        #region METODOS
        public bool Agregar(string aTexto)
        {
            bool Resp = false;
            try
            {
                if (ProximaPosicion == lista.Length)
                {
                    this.AgregaRegistro(1);
                }

                lista[ProximaPosicion] = aTexto;
                ProximaPosicion++;
                Resp = true;
            }
            catch (Exception err)
            {
                throw err;
            }

            return Resp;
        }

        public string MostrarLista()
        {

            string Respuesta = "";
            if (ProximaPosicion > 0)
            {
                Respuesta = lista[0];
                for (int i = 1; i < ProximaPosicion; i++)
                {
                    Respuesta = Respuesta + "\r\n" + lista[i];
                }
            }
            return Respuesta;
        }

        private void AgregaRegistro(int incremento)
        {
            string[] Temp = new string[lista.Length + incremento];
            lista = this.Copiar(lista, Temp);
        }

        private string[] Copiar(string[] Origen, string[] Destino)
        {
            for (int i = 0; i < ProximaPosicion; i++)
            {
                Destino[i] = Origen[i];
            }
            return Destino;
        }

        /// <summary>
        /// Devuelve la posicion del texto (entero) dentro del arregla, <br/>
        /// la cuenta inicia en 0 (cero).
        /// Devuelve -1 cuando no encuentra Que en la lista.
        /// </summary>
        /// <param name="Que">texto completo a buscar en la lista</param>
        public int BuscarPosicion(string Que)
        {
            int Resp = -1;

            for (int i = 0; i < lista.Length; i++)
            {
                if (lista[i].CompareTo(Que) == 0)
                {
                    Resp = i;
                    break;
                }
            }

            return Resp;
        }

        public string Borrar(string Que)
        {
            string Resp = "";
            int Pos = this.BuscarPosicion(Que);
            if (Pos == -1)
            {
                Resp = Que + " no ha sido encontrado en la lista.";
            }
            else
            {
                for (int i = Pos; i < ProximaPosicion - 1; i++)
                {
                    this.lista[i] = this.lista[i + 1];
                }
                this.lista[ProximaPosicion - 1] = null;
                ProximaPosicion = ProximaPosicion - 1;
                AgregaRegistro(-1);
            }

            return Resp;
        }

        public string Ordenar()
        {
            string[] listaOrden = new string[lista.Length];
            string Respuesta = "";

            Copiar(lista, listaOrden);

            if (listaOrden.Length > 1)
            {
                for (int i = 0; i < listaOrden.Length - 1; i++)
                {
                    for (int j = 0; j < listaOrden.Length - 1; j++)
                    {
                        if ((listaOrden[j].CompareTo(listaOrden[j + 1])) > 0)
                        {
                            string temp2 = "";

                            temp2 = listaOrden[j];
                            listaOrden[j] = listaOrden[j + 1];
                            listaOrden[j + 1] = temp2;
                        }
                    }
                }
            }

            for (int i = 0; i < listaOrden.Length; i++)
            {
                Respuesta = Respuesta + listaOrden[i] + "\r\n";
            }
            return Respuesta;
        }

        #endregion
        //public string MostrarOrdenada()
        //{
        //    string[] listaOrden;
        //    listaOrden = lista.OrderBy(x => x).ToArray();

        //    string Respuesta = "";
        //    if (ProximaPosicion >= 0)
        //    {
        //        Respuesta = listaOrden[0];
        //        for (int i = 1; i < ProximaPosicion; i++)
        //        {
        //            Respuesta = Respuesta + "\r\n" + listaOrden[i];
        //        }
        //    }
        //    return Respuesta;
        //}
    }

}
