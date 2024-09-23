class Controller
{
    private Model db;
    private View view;

    public Controller(Model db, View view){
        this.db = db;
        this.view = view;
    }

    public void Menu()
    {
        Console.Clear();
        string inserimento;
        do
        {
            inserimento = view.MainMenu();
            switch (inserimento)
            {
                case "Visualiza partecipanti": //Lista partecipanti
                    Console.Clear();
                    view.Lista(db.Get());
                    break;
                case "Ordina": //Ordinamento
                    Console.WriteLine("d - Discendente?");
                    view.Lista(db.Sort(Console.ReadKey(true).KeyChar));
                    break;
                case "Ricerca": //Controlla se già presente
                    view.Presente(db.Contains(Funzioni.ReadNome()));
                    break;
                case "Edita": //Edita
                    do
                    {
                        inserimento = view.EditMenu();
                        switch (inserimento)
                        {
                            case "Aggiunta nome": //Aggiunge nome
                                string nom = ReadNome();
                                if (db.Contains(nom)) Console.WriteLine($"{nom} è già presente."); else db.Add(nom); //Controlla che il nome non sia già presente
                                break;
                            case "Elimina partecipante": //Elimina partecipante

                                nom = view.Select();
                                db.Remove(nom);
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

    public string ReadNome() //Lettura nome con controllo digitazione
    {
        Console.WriteLine("Inserire nome");
        string nome = Console.ReadLine()!.Trim(); //Rimuove spazi prima e dopo
        return nome[0].ToString().ToUpper() + nome.Substring(1); //Mette maiuscola solo la prima lettera
    }
}