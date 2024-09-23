using Spectre.Console;
class View
{
    private Model db;
    Random rng = new Random();
    public View(Model db)
    {
        this.db = db;
    }
    public void Menu()
    {
        Console.Clear();
        string inserimento;
        do
        {
            inserimento = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("-----Gestionale classe-----")
                .PageSize(7)
                .MoreChoicesText("[grey](Move up and down to select)[/]")
                .AddChoices(new[] {
            "Visualiza partecipanti", "Ordina", "Ricerca", "Edita",
            "Salva lista", "Menù squadre", "Esci",
                }));
            switch (inserimento)
            {
                case "Visualiza partecipanti": //Lista partecipanti
                    Console.Clear();
                    Lista(db.GetPartecipanti());
                    break;
                case "Ordina": //Ordinamento
                    db.Sort();
                    Console.WriteLine("d - Discendente?");
                    if (Console.ReadKey(true).KeyChar == 'd') db.Reverse();
                    break;
                case "Ricerca": //Controlla se già presente
                    if (partecipanti.Contains(Funzioni.ReadNome())) Console.WriteLine("Presente"); else Console.WriteLine("Assente");
                    break;
                case "Edita": //Edita
                    do
                    {
                        inserimento = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("-----Menù edit-----")
                            .PageSize(4)
                            .MoreChoicesText("[grey](Move up and down to select[/]")
                            .AddChoices(new[] {
                        "Aggiunta nome", "Elimina partecipante", "Modifica",
                        "Back",
                            }));
                        switch (inserimento)
                        {
                            case "Aggiunta nome": //Aggiunge nome
                                string nom = Funzioni.ReadNome();
                                if (partecipanti.Contains(nom)) Console.WriteLine($"{nom} è già presente."); else partecipanti.Add(nom); //Controlla che il nome non sia già presente
                                break;
                            case "Elimina partecipante": //Elimina partecipante
                                nom = AnsiConsole.Prompt(
                                    new SelectionPrompt<string>()
                                        .Title("-----Seleziona partecipante-----")
                                        .PageSize(partecipanti.Count)
                                        .MoreChoicesText("[grey](Move up and down to select)[/]")
                                        .AddChoices(partecipanti));
                                partecipanti.Remove(nom);
                                Console.WriteLine($"{nom} è stato rimosso.");
                                break;
                            case "Modifica": //Modifica partecipante
                                nom = Funzioni.ReadNome();
                                if (partecipanti.Contains(nom)) //Verifica che sia presente
                                {
                                    string nuovoNome = Funzioni.ReadNome();
                                    partecipanti[partecipanti.IndexOf(nom)] = nuovoNome; //Sostituisce il nome all'indice del nome vecchio con quello nuovo
                                    Console.WriteLine($"{nom} è stato modificato in {nuovoNome}.");
                                }
                                else Console.WriteLine($"{nom} non è nella lista.");
                                break;
                        }
                    } while (inserimento != "Back"); //Esce con 'b'
                    break;
                case "Salva lista": //Salva lista
                    File.Delete("Partecipanti.txt");
                    File.AppendAllLines("Partecipanti.txt", partecipanti);
                    Console.WriteLine("Nuova lista salvata!");
                    break;
                case "Menù squadre": //Menù squadre
                    List<string> squadra1 = new List<string>();
                    List<string> squadra2 = new List<string>();
                    do
                    {
                        inserimento = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("-----Menù squadre------")
                            .PageSize(5)
                            .MoreChoicesText("[grey](Move up and down to select)[/]")
                            .AddChoices(new[] {
                        "Crea squadre", "Squadre manuali", "Salva squadre", "Ricarica partecipanti",
                        "Back",
                            }));
                        List<string> temp;
                        switch (inserimento)
                        {
                            case "Crea squadre": //Crea squadre
                                temp = new List<string>(partecipanti);
                                Console.Clear();
                                squadra1.Clear();
                                squadra2.Clear();
                                while (partecipanti.Count > 0) //Cicla finché la lista dai partecipanto non si svuota
                                {
                                    int scelto = rng.Next(partecipanti.Count); //Sceglie un partecipante a caso fra i rimanenti
                                    if (squadra1.Count > squadra2.Count) squadra2.Add(partecipanti[scelto]); else squadra1.Add(partecipanti[scelto]); //Lo inserisce nella squadra più cota iniziando dalla 1
                                    partecipanti.RemoveAt(scelto); //Lo rimuove dalla lista iniziale
                                }
                                Funzioni.Lista(temp, squadra1, squadra2);
                                break;
                            case "Squadre manuali":
                                temp = new List<string>(partecipanti);
                                Console.Clear();
                                squadra1 = AnsiConsole.Prompt(
                                    new MultiSelectionPrompt<string>()
                                        .Title("Selezionare squadra 1?")
                                        .PageSize(partecipanti.Count)
                                        .AddChoices(partecipanti));
                                foreach (string item in squadra1) partecipanti.Remove(item);
                                squadra2 = new List<string>(partecipanti);
                                partecipanti.Clear();
                                Funzioni.Lista(temp, squadra1, squadra2);
                                break;
                            case "Salva squadre": //Salva squadre
                                Funzioni.SalvaSquadre("Squadre.txt", squadra1, squadra2);
                                break;
                            case "Ricarica partecipanti": //Ricarica Partecipanti
                                partecipanti = new List<string>(File.ReadAllLines("Partecipanti.txt"));
                                Console.WriteLine("Lista ricaricata!");
                                break;
                        }
                    } while (inserimento != "Back"); //Esce con "Back"
                    break;
            }
        } while (inserimento != "Esci"); //Esce con "Esci"
    }


    public void Lista(List<Partecipante> partecipanti)
    {
        var lista = new Table();
        lista.AddColumn("Partecipanti");
        foreach (Partecipante partecipante in partecipanti) lista.AddRow(partecipante.Nome); //Crea una tabella con i partecipanti
        AnsiConsole.Write(lista); //Stampa la tabella
    }
}