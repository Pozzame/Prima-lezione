using System.Data.SQLite;

class Model{
    private SQLiteConnection connection;
    private string path = @"C:\Users\Pozzame\Documents\Corso_2024\Prima lezione\";

    public Model()
    {
        if (!File.Exists($"{path}database.db"))
        {
            connection = new SQLiteConnection($"Data Source={path}database.db");  // Creazione di una connessione al database
            connection.Open(); // Apertura della connessione
            var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Partecipanti (id INTEGER PRIMARY KEY, name TEXT)", connection);
            command.ExecuteNonQuery();  // Esecuzione del comando
            List<string> partecipanti = new List<string>(File.ReadAllLines($"{path}Partecipanti.txt"));
            foreach (var partecipante in partecipanti)
            {
                command = new SQLiteCommand($"insert into Partecipanti (name) values ('{partecipante}')", connection);
                command.ExecuteNonQuery();
            }
        }
    }
    public List<Partecipante> Get()
    {
        var command = new SQLiteCommand("SELECT nome FROM Partecipanti", connection);
        var reader = command.ExecuteReader();
        var users = new List<Partecipante>();
        while (reader.Read())
        {
            users.Add(new Partecipante(reader.GetString(0)));
        }
        return users;
    }
    public List<Partecipante> Sort(char ordinamento)
    {
        string ord = "";
        if (ordinamento == 'd')
            ord = "DESC";
        var command = new SQLiteCommand($"SELECT nome FROM Partecipanti ORDER BY nome {ord}", connection); // Creazione di un comando per leggere gli utenti
        var reader = command.ExecuteReader();   // Esecuzione del comando e creazione di un oggetto per leggere i risultati
        var users = new List<Partecipante>(); // Creazione di una lista per memorizzare i nomi degli utenti
        while (reader.Read())
        {
            users.Add(new Partecipante(reader.GetString(0))); // Aggiunta dell'utente alla lista
        }
        return users;   // Restituzione della lista
    }
    public bool Contains(string name)
    {
        var command = new SQLiteCommand($"SELECT nome FROM Partecipanti WHERE nome = '{name}'", connection); // Creazione di un comando per leggere gli utenti
        var reader = command.ExecuteReader();   // Esecuzione del comando e creazione di un oggetto per leggere i risultati
        return reader.HasRows;
    }

    internal void Add(string name)
    {
        var command = new SQLiteCommand($"INSERT INTO Partecipanti (name) VALUES ('{name}')", connection);
        command.ExecuteNonQuery();  // Esecuzione del comando
    }

    internal void Remove(string name)
    {
        var command = new SQLiteCommand($"DELETE FROM Partecipanti WHERE name = '{name}'", connection);
        command.ExecuteNonQuery(); 
        Console.WriteLine($"{name} è stato rimosso.");
    }

    internal List<string> GetStrings()
    {
        List<string> list = new List<string>();
        List<Partecipante> partecipanti = Get();
        foreach (Partecipante partecipante in partecipanti)
        {
            list.Add(partecipante.Nome);
        }
        return list;
    }
}