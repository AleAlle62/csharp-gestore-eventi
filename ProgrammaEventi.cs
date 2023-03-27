using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class ProgrammaEventi
    {
        public string Titolo { get; set; }
        public List<Evento> Eventi { get; set; }
        public ProgrammaEventi(string Titolo)
        {
            Titolo = Titolo;
            Eventi = new List<Evento>();
        }

        //metodi

        //CREA EVENTO
        public void CreaEvento(Evento evento)
        {
            Eventi.Add(evento);
        }

        //LISTA EVENTI
        public List<Evento> EventiInData(DateTime data)
        {
            List<Evento> eventiInData = new List<Evento>();
            foreach (Evento evento in Eventi)
            {
                if (evento.Data.Date == data.Date)
                {
                    eventiInData.Add(evento);
                }
            }
            return eventiInData;
        }


        //STAMPA DELLA LISTA
        public static string StampaEventi(List<Evento> eventi)
        {
            string output = "";
            foreach (Evento evento in eventi)
            {
                output += evento.ToString() + "\n";
            }
            return output;
        }

        //EVENTI PRESENTI
        public int NumeroEventi()
        {
            return Eventi.Count;
        }


        //SVUOTA LISTA
        public void SvuotaEventi()
        {
            Eventi.Clear();
        }

        //TITOLO DEL PROGRAMMA
        public string StampaProgramma()
        {
            string output = "Nome programma Evento:" + Titolo + "\n";
            foreach (Evento evento in Eventi)
            {
                output += evento.Data.ToString("gg/MM/yyyy") + "-" + evento.Titolo + "\n";
            }
            return output;
        }
    }
}
