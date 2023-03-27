using csharp_gestore_eventi;
using System;

class Program
{
    static void Main(string[] args)
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

        // Chiedi all'utente di effettuare delle prenotazioni
        while (true)
        {
            Console.Write("Vuoi prenotare dei posti? (s/n): ");
            string risposta = Console.ReadLine();
            if (risposta.ToLower() == "n")
                break;
            Console.Write("Quanti posti vuoi prenotare? ");
            int postiDaPrenotare;
            if (!int.TryParse(Console.ReadLine(), out postiDaPrenotare))
            {
                Console.WriteLine("Numero di posti non valido.");
                continue;
            }
            if (evento.PrenotaPosti(postiDaPrenotare))
            {
                Console.WriteLine("Prenotazione effettuata.");
                Console.WriteLine("Posti prenotati: " + evento.NumeroPostiPrenotati);
                Console.WriteLine("Posti disponibili: " + (evento.capienzaMassima - evento.NumeroPostiPrenotati));
            }
            else
            {
                Console.WriteLine("Prenotazione non effettuata.");
            }
        }


        // Chiedi all'utente di disdire dei posti
        while (true)
        {
            Console.Write("Vuoi disdire dei posti? (s/n): ");
            string risposta = Console.ReadLine();
            if (risposta.ToLower() == "n")
                break;
            Console.Write("Quanti posti vuoi disdire? ");
            int postiDaDisdire;
            if (!int.TryParse(Console.ReadLine(), out postiDaDisdire))
            {
                Console.WriteLine("Numero di posti non valido.");
                continue;
            }
            if (evento.DisdiciPosti(postiDaDisdire))
            {
                Console.WriteLine("Disdetta effettuata.");
                Console.WriteLine("Posti prenotati: " + evento.NumeroPostiPrenotati);
                Console.WriteLine("Posti disponibili: " + (evento.capienzaMassima - evento.NumeroPostiPrenotati));
            }
            else
            {
                Console.WriteLine("Disdetta non effettuata.");
            }
        }


        //stampa dei dati inseriti
        Console.WriteLine("");
        Console.WriteLine("Titolo:" + evento.Titolo);
       
        Console.WriteLine("");
        Console.WriteLine("Data:" + evento.Data.ToString("dd/MM/yyyy"));

        Console.WriteLine("");
        Console.WriteLine("Capienza massima:" + evento.capienzaMassima);

        Console.WriteLine("");
        Console.WriteLine("POsti prenotati:" + evento.NumeroPostiPrenotati);

        Console.ReadLine();
    }
}


