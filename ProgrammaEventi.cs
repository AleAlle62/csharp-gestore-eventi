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
    }
}
