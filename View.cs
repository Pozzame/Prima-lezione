using Spectre.Console;
class View
{
    private Model db;
    Random rng = new Random();
    public View(Model db)
    {
        this.db = db;
    }
    public string MainMenu()
    {
        return AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("-----Gestionale classe-----")
            .PageSize(7)
            .MoreChoicesText("[grey](Move up and down to select)[/]")
            .AddChoices(new[] {
                "Visualiza partecipanti", "Ordina", "Ricerca", "Edita",
                "Salva lista", "Menù squadre", "Esci",
            }));
    }
    public void Lista(List<Partecipante> partecipanti)
    {
        var lista = new Table();
        lista.AddColumn("Partecipanti");
        foreach (Partecipante partecipante in partecipanti) lista.AddRow(partecipante.Nome); //Crea una tabella con i partecipanti
        AnsiConsole.Write(lista); //Stampa la tabella
    }
    public void Presente(bool presente)
    {
        if (presente) Console.WriteLine("Presente"); else Console.WriteLine("Assente");
    }

    internal string EditMenu()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("-----Menù edit-----")
                .PageSize(4)
                .MoreChoicesText("[grey](Move up and down to select[/]")
                .AddChoices(new[] {
                    "Aggiunta nome", "Elimina partecipante", "Modifica",
                    "Back",
                    }));
    }

    internal string Select()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("-----Seleziona partecipante-----")
                .PageSize(db.Get().Count)
                .MoreChoicesText("[grey](Move up and down to select)[/]")
                .AddChoices(db.GetStrings()));
    }
}