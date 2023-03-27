using csharp_gestore_eventi;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Inserisci il titolo del programma di eventi: ");
        string titoloProgramma = Console.ReadLine();

        ProgrammaEventi programma = new ProgrammaEventi(titoloProgramma);

        Console.Write("Vuoi creare un nuovo evento? (s/n): ");
        string rispostaCreazione = Console.ReadLine();
        if (rispostaCreazione.ToLower() == "s")
        {
            // Chiedi all'utente di inserire i dati per un nuovo evento
            Console.WriteLine("Inserisci i dati per un nuovo evento:");
            Console.Write("Titolo: ");
            string titolo = Console.ReadLine();
            Console.Write("Data (formato dd/MM/yyyy): ");
            string dataStringa = Console.ReadLine();
            DateTime data;
            if (!DateTime.TryParseExact(dataStringa, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out data))
            {
                Console.WriteLine("Data non valida.");
                return;
            }
            Console.Write("Capienza massima: ");
            int capienzaMassima;
            if (!int.TryParse(Console.ReadLine(), out capienzaMassima))
            {
                Console.WriteLine("Capienza massima non valida.");
                return;
            }

            // Crea un nuovo evento con i dati inseriti dall'utente
            Evento evento = new Evento(titolo, data, capienzaMassima);

            // Aggiungi l'evento al programma di eventi
            programma.CreaEvento(evento);
        }

        Console.Write("Quanti eventi vuoi aggiungere? ");
        int numeroEventi = int.Parse(Console.ReadLine());

        int eventiInseriti = 0;
        while (eventiInseriti < numeroEventi)
        {
            Console.WriteLine("Inserimento evento " + (eventiInseriti + 1));
            Console.Write("Titolo: ");
            string titoloEvento = Console.ReadLine();
            Console.Write("Data (formato dd/MM/yyyy): ");
            DateTime dataEvento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Capienza massima: ");
            int capienzaMassima = int.Parse(Console.ReadLine());

            try
            {
                Evento evento = new Evento(titoloEvento, dataEvento, capienzaMassima);
                programma.CreaEvento(evento);
                Console.WriteLine("Evento aggiunto correttamente");
                eventiInseriti++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore: " + ex.Message);
            }
        }

        Console.WriteLine("Numero di eventi presenti nel programma: " + programma.NumeroEventi());
        Console.WriteLine("Lista di eventi inseriti nel programma:");
        Console.WriteLine(ProgrammaEventi.StampaEventi(programma.Eventi));

        Console.Write("Inserisci una data (formato dd/MM/yyyy): ");
        DateTime dataCercata = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Console.WriteLine("Eventi in data " + dataCercata.ToString("dd/MM/yyyy") + ":");
        Console.WriteLine(ProgrammaEventi.StampaEventi(programma.EventiInData(dataCercata)));

        programma.SvuotaEventi();
        Console.WriteLine("Tutti gli eventi sono stati eliminati dal programma");

        Console.ReadLine();
    }
}