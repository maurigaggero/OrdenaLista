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
        public string[] notas = new string[1];

        private int ProximaPosicion = 0;
        private int prox = 0;
        #endregion

        #region CONSTRUCTOR
        #endregion

        #region METODOS
        public bool Agregar(string nombre)
        {
            bool Resp = false;
            try
            {
                if (ProximaPosicion == lista.Length)
                {
                    this.AgregaRegistro(1);
                }

                lista[ProximaPosicion] = nombre;
                ProximaPosicion++;
                Resp = true;
            }
            catch (Exception err)
            {
                throw err;
            }

            return Resp;
        }

        public bool AgregarNota(string nota)
        {
            bool Resp = false;
            try
            {
                if (prox == notas.Length)
                {
                    this.AgregaNota(1);
                }

                notas[prox] = nota;
                prox++;
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
        public string MostrarNotas()
        {

            string Respuesta = "";
            if (prox > 0)
            {
                Respuesta = notas[0];
                for (int i = 1; i < prox; i++)
                {
                    Respuesta = Respuesta + "\r\n" + notas[i];
                }
            }
            return Respuesta;
        }


        private void AgregaNota(int incremento)
        {
            string[] TempX = new string[notas.Length + incremento];
            notas = this.Copiar(notas, TempX);
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

                for (int i = Pos; i < prox - 1; i++)
                {
                    this.notas[i] = this.notas[i + 1];
                }
                this.notas[prox - 1] = null;
                prox = prox - 1;
                AgregaNota(-1);
            }

            return Resp;
        }

        public string Ordenar()
        {
            string[] listaOrden = new string[lista.Length];
            string[] notasOrden = new string[notas.Length];

            string Respuesta = "";

            Copiar(lista, listaOrden);
            Copiar(notas, notasOrden);

            if (listaOrden.Length > 1)
            {
                for (int i = 0; i < listaOrden.Length - 1; i++)
                {
                    for (int j = 0; j < listaOrden.Length - 1; j++)
                    {
                        if ((listaOrden[j].CompareTo(listaOrden[j + 1])) > 0)
                        {
                            string temp2 = "";
                            string temp3 = "";

                            temp2 = listaOrden[j];
                            temp3 = notasOrden[j];

                            notasOrden[j] = notasOrden[j + 1];
                            notasOrden[j + 1] = temp3;

                            listaOrden[j] = listaOrden[j + 1];
                            listaOrden[j + 1] = temp2;
                        }
                    }
                }
            }

            for (int i = 0; i < listaOrden.Length; i++)
            {
                Respuesta = Respuesta + listaOrden[i] + " = " + notasOrden[i] + "\r\n";
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
