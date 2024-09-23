using Spectre.Console;
public static class Funzioni
{
    public static string ReadNome() //Lettura nome con controllo digitazione
    {
        Console.WriteLine("Inserire nome");
        string nome = Console.ReadLine()!.Trim(); //Rimuove spazi prima e dopo
        return nome[0].ToString().ToUpper() + nome.Substring(1); //Mette maiuscola solo la prima lettera
    }
    public static void Lista(List<Partecipante> partecipanti)
    {
        var lista = new Table();
        lista.AddColumn("Partecipanti");
        foreach (Partecipante partecipante in partecipanti) lista.AddRow(partecipante.Nome); //Crea una tabella con i partecipanti
        AnsiConsole.Write(lista); //Stampa la tabella
    }
    public static void Lista(List<Partecipante> partecipanti, List<Partecipante> squadra1, List<Partecipante> squadra2)
    {
        var table = new Table();
        table.AddColumn("Partecipanti");
        table.AddColumn("Squadra1");
        table.AddColumn("Squadra2");
        for (int i = 0; i < partecipanti.Count; i++)
            table.AddRow(partecipanti[i], squadra1.Count>i ? squadra1[i] : "", squadra2.Count>i ? squadra2[i] : "");
        AnsiConsole.Write(table); //Stampa la tabella
    }
    public static void SalvaSquadre(string path, List<Partecipante> squadra1, List<Partecipante> squadra2)
    {
        if (File.Exists(path))
            File.Delete(path);
        File.AppendAllText(path, $"Squadra 1\n");
        File.AppendAllLines(path, squadra1);
        File.AppendAllText(path, $"\nSquadra 2\n");
        File.AppendAllLines(path, squadra2);
        Console.WriteLine("Squadre salvate!");
    }
}