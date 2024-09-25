using Spectre.Console;
class View
{
    private Model db;
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
    public void Lista(List<Partecipante> partecipanti, List<Partecipante> squadra1, List<Partecipante> squadra2)
    {
        var table = new Table();
        table.AddColumn("Partecipanti");
        table.AddColumn("Squadra1");
        table.AddColumn("Squadra2");
        for (int i = 0; i < partecipanti.Count; i++)
            table.AddRow(partecipanti[i].Nome, squadra1.Count>i ? squadra1[i].Nome : "", squadra2.Count>i ? squadra2[i].Nome : "");
        AnsiConsole.Write(table); //Stampa la tabella
    }
        public void Lista(List<Partecipante> partecipanti)
    {
        var lista = new Table();
        lista.AddColumn("Partecipanti");
        lista.AddColumn("Score");
        foreach (Partecipante partecipante in partecipanti) 
            lista.AddRow(partecipante.Nome, partecipante.VisScore()); //Crea una tabella con i partecipanti
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
                .PageSize(6)
                .MoreChoicesText("[grey](Move up and down to select[/]")
                .AddChoices(new[] {
                    "Aggiunta nome", "Elimina partecipante", "Modifica nome", "Rendi professionista", "Modifica score Pro",
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
    internal string Select(List<Professionista> pro)
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("-----Seleziona partecipante-----")
                .PageSize(pro.Count)
                .MoreChoicesText("[grey](Move up and down to select)[/]")
                .AddChoices(pro.ToList()));
    }

    internal string SquadreMenu()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("-----Menù squadre------")
                .PageSize(5)
                .MoreChoicesText("[grey](Move up and down to select)[/]")
                .AddChoices(new[] {
                    "Crea squadre", "Squadre manuali", "Back",
                    }));
    }

    internal List<string> SelSquadra()
    {
        return AnsiConsole.Prompt(
            new MultiSelectionPrompt<string>()
                .Title("Selezionare squadra 1?")
                .PageSize(db.Get().Count)
                .AddChoices(db.GetStrings()));
    }
}