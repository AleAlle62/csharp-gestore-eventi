using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Evento 
    {
        //attributi 
        public string _titolo;
        public DateTime _data;
        public int _capienzaMassima;
        public int _numeroPostiPrenotati;

        public Evento(string titolo, DateTime data, int capienzaMassima)
        {
            Titolo = titolo;
            Data = data;
            _capienzaMassima = capienzaMassima;
            _numeroPostiPrenotati = 0;
        }

        // 1) titolo 
        public string Titolo
        {
            get { return _titolo; }
            set
            {
                //controllo che il titolo non sia vuoto 
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Il titolo non può essere vuoto.");
                _titolo = value;
            }
        }

        // 2) data 
        public DateTime Data
        {
            get { return _data; }
            set
            {
                // controllo che la data non sia nel passato
                if (value < DateTime.Now)
                    throw new Exception("La data non può essere nel passato.");
                _data = value;
            }
        }

        // 3) capienza massima
        public int capienzaMassima
        {
            get { return _capienzaMassima; }
            set
            {
                // controllo che non sia un numero sotto lo 0
                if (value <= 0)
                    throw new Exception("La capienza massima deve essere un numero positivo.");
                _capienzaMassima = value;
            }
        }


        // 4) numero di posti
        public int NumeroPostiPrenotati
        {
            get { return _numeroPostiPrenotati; }
        }


        // metodi 


        //1) PRENOTA POSTI

        public bool PrenotaPosti(int postiDaPrenotare)
        {
            if (Data < DateTime.Now)
                throw new Exception("L'evento è già passato.");
            if (_numeroPostiPrenotati > _capienzaMassima)
                throw new Exception("L'evento ha raggiunto la capienza massima.");
            if (_numeroPostiPrenotati + postiDaPrenotare > _capienzaMassima)
                throw new Exception("Non ci sono abbastanza posti disponibili per l'evento.");
            _numeroPostiPrenotati += postiDaPrenotare;
            return true;
        }


        //2) DISDICI POSTI
        public bool DisdiciPosti(int postiDaDisdire)
        {
            if (Data < DateTime.Now)
                throw new Exception("L'evento è già passato.");
            if (_numeroPostiPrenotati <= 0)
                throw new Exception("Non ci sono posti prenotati per l'evento.");
            if (_numeroPostiPrenotati - postiDaDisdire < 0)
                throw new Exception("Non ci sono abbastanza posti prenotati da disdire.");
            _numeroPostiPrenotati -= postiDaDisdire;
            return true;
        }

        public override string ToString()
        {
            return _data.ToString("dd/MM/yyyy") + "-" + _titolo;
        }
    }
}

