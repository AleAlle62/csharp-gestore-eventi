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
        private string _titolo;
        private DateTime _data;
        private int _capienzaMassima;
        private int _numeroPostiPrenotati;

        public Evento(string titolo, DateTime data, int CapienzaMassima)
        {
            Titolo = titolo;
            Data = data;
            CapienzaMassima = CapienzaMassima;
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
                    throw new ArgumentException("Il titolo non può essere vuoto.");
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
                    throw new ArgumentException("La data non può essere nel passato.");
                _data = value;
            }
        }

        // 3) capienza massima
        public int CapienzaMassima
        {
            get { return _capienzaMassima; }
            set
            {
                // controllo che non sia un numero sotto lo 0
                if (value <= 0)
                    throw new ArgumentException("La capienza massima deve essere un numero positivo.");
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
                throw new InvalidOperationException("L'evento è già passato.");
            if (_numeroPostiPrenotati >= _capienzaMassima)
                throw new InvalidOperationException("L'evento ha raggiunto la capienza massima.");
            if (_numeroPostiPrenotati + postiDaPrenotare > _capienzaMassima)
                throw new InvalidOperationException("Non ci sono abbastanza posti disponibili per l'evento.");
            _numeroPostiPrenotati += postiDaPrenotare;
            return true;
        }


        //2) DISDICI POSTI
        public bool DisdiciPosti(int postiDaDisdire)
        {
            if (Data < DateTime.Now)
                throw new InvalidOperationException("L'evento è già passato.");
            if (_numeroPostiPrenotati <= 0)
                throw new InvalidOperationException("Non ci sono posti prenotati per l'evento.");
            if (_numeroPostiPrenotati - postiDaDisdire < 0)
                throw new InvalidOperationException("Non ci sono abbastanza posti prenotati da disdire.");
            _numeroPostiPrenotati -= postiDaDisdire;
            return true;
        }

        public override string ToString()
        {
            return _data.ToString("dd/MM/yyyy") + "-" + _titolo;
        }
    }
}
