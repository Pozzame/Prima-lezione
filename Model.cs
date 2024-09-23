using System.Data.SQLite;

class Model{
    private SQLiteConnection connection;
    private string dbpath = @"C:\Users\Pozzame\Documents\Corso_2024\Prima lezione\database.db";

    public Model()
    {
        if (!File.Exists(dbpath))
        {
            connection = new SQLiteConnection($"Data Source={dbpath}");  // Creazione di una connessione al database
            connection.Open(); // Apertura della connessione
            var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Partecipanti (id INTEGER PRIMARY KEY, name TEXT)", connection);
            command.ExecuteNonQuery();  // Esecuzione del comando
            List<string> partecipanti = new List<string>(File.ReadAllLines(@"Partecipanti.txt"));
            foreach (var partecipante in partecipanti)
            {
                command = new SQLiteCommand($"insert into Partecipanti (name) values ('{partecipante}')", connection);
                command.ExecuteNonQuery();
            }
        }
    }
}