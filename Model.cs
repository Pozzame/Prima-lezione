using System.Data.SQLite;
using Microsoft.EntityFrameworkCore;

class Model{
    private SQLiteConnection connection;
    private string path = @"C:\Users\Pozzame\Documents\Corso_2024\Prima lezione\"; 
    //private string path = @"C:\Users\pozza\Documents\VisualStudioCode\Prima-lezione\";

    public Model()
    {
        // Verifica se il database esiste già.
        // Se no lo crea, lo inizializza leggendo da un file di nomi e apre la connessione.
        // Se c'è già, apre la connessione.
        if (!File.Exists($"{path}database.db"))
        {
            connection = new SQLiteConnection($"Data Source={path}database.db");  // Creazione di una connessione al database
            connection.Open(); // Apertura della connessione
        //Creazione tabelle
            SQLiteCommand command = new SQLiteCommand(@"CREATE TABLE IF NOT EXISTS Partecipanti 
                                                        (id INTEGER PRIMARY KEY, name TEXT UNIQUE, 
                                                        FOREIGN KEY (name) REFERENCES Professionisti (name));"
                                                        , connection);
            command.ExecuteNonQuery();  // Esecuzione del comando
            command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Professionisti (id INTEGER PRIMARY KEY, name TEXT UNIQUE, score INTEGER);", connection);
            command.ExecuteNonQuery();  // Esecuzione del comando
        //
        //Inizializzazione DB da files nomi
            //Inserisce i partecipanti nel db da file
            List<string> partecipanti = new List<string>(File.ReadAllLines($"{path}Partecipanti.txt")); //Legge il file nomi e li inseriesce in una List
            foreach (var partecipante in partecipanti)
            {
                command = new SQLiteCommand($"insert into Partecipanti (name) values ('{partecipante}');", connection);
                command.ExecuteNonQuery();
            }
            //Inserisce i professionisti nel db da csv
            var reader = new StreamReader(File.OpenRead($"{path}Professionisti.csv"));
            List<Professionista> pro = new List<Professionista>();
            while (!reader.EndOfStream) {
                var line = reader.ReadLine();
                var values = line!.Split(',');
                pro.Add(new Professionista(values[0], Convert.ToInt32(values[1])));
            }
            foreach (var element in pro) {
                command = new SQLiteCommand($"insert into Professionisti (name, score) values ('{element.Nome}', {element.Score});", connection);
                command.ExecuteNonQuery();
            }
        //
        }
        else // Apre connessione col DB
        {
            connection = new SQLiteConnection($"Data Source={path}database.db");  // Creazione di una connessione al database
            connection.Open(); // Apertura della connessione
        }
    }

    //Restituisce il nome di un partecipante a partire dall'ID
    public Partecipante Get(int id)
    {
        SQLiteCommand command = new SQLiteCommand($"SELECT name FROM Partecipanti WHERE ID = '{id}';", connection);
        var reader = command.ExecuteReader();
        return new Partecipante(reader.GetString(0));
    }

    //Estrapola i Partedipanti dal DB
    //Quindi crea una List di Partecipanti che contiene anche Professionisti
    public List<Partecipante> Get()
    {
        //Usando una LEFT JOIN restituisce una tabella 
        //  contenente tutti i partecipanti e il relativo score, se professionisti
        var command = new SQLiteCommand(@"SELECT Partecipanti.name name, score 
                                            FROM Partecipanti 
                                            LEFT JOIN Professionisti 
                                            ON Partecipanti.name == Professionisti.name;", connection);
        var reader = command.ExecuteReader();
        var users = new List<Partecipante>();
        // Popola la lista, usando il polimorfismo, e la restituisce
        while (reader.Read())
        {
            //Se la seconda colonna della tupla non è nulla, 
            //  significa che è un Professionista, altrimenti è un Partecipante
            if (!reader.IsDBNull(1))
                users.Add(new Professionista(reader.GetString(0), reader.GetInt32(1)));
            else
                users.Add(new Partecipante(reader.GetString(0)));
        }
        return users;
    }  

    //Ordinamento
    //Crea una List<Partecipanti> e la ordina in base alla chiave di ordinamento
    //E' stato possibile perchè Partecipante implementa l'interfaccia IComparable
    public List<Partecipante> Sort(char ordinamento)
    {
        List<Partecipante> lista = Get();
        if (ordinamento == 'd')
            lista.Reverse();
        else
            lista.Sort();
        return lista;
    }

    //Verifica se nel DB è presente un partecipante
    public bool Contains(string name)
    {
        // Creazione di un comando per leggere dal db l'utente ricercato
        SQLiteCommand command = new SQLiteCommand($"SELECT name FROM Partecipanti WHERE name = '{name}';", connection);
        var reader = command.ExecuteReader();   // Esecuzione del comando e creazione di un oggetto per leggere i risultati
        return reader.HasRows; //Restituisce un bool se la ricerca ha trovato un emlemento
    }

    //Inserisce nel db un partecipante nuovo
    internal void Add(string name)
    {
        SQLiteCommand command = new SQLiteCommand($"INSERT INTO Partecipanti (name) VALUES ('{name}');", connection);
        command.ExecuteNonQuery();  // Esecuzione del comando
    }

    //Rimuove un partecipante sia dai partecipanti che dai professionisti
    //Se il partecipante non è un profesisonista, la DELETE non da errore

    internal void Remove(string name)
    {
        SQLiteCommand command = new SQLiteCommand($"DELETE FROM Partecipanti WHERE name = '{name}';", connection);
        command.ExecuteNonQuery(); 
        command = new SQLiteCommand($"DELETE FROM Professionisti WHERE name = '{name}';", connection);
        command.ExecuteNonQuery(); 
        Console.WriteLine($"{name} è stato rimosso.");
    }

    //Restituisce una List<string> che contiene i soli nomi di tutti i partecipanti
    // internal List<string> GetStrings()
    // {
    //     List<string> list = new List<string>();
    //     List<Partecipante> partecipanti = Get();
    //     foreach (Partecipante partecipante in partecipanti)
    //         list.Add(partecipante.Nome);
    //     return list;
    // }

    //Sostituisce il nome di un partecipante
    internal void Edit(string nome, string nuovoNome)
    {
        SQLiteCommand command = new SQLiteCommand($"UPDATE Partecipanti SET name = '{nuovoNome}' WHERE name = '{nome}';", connection);
        command.ExecuteNonQuery();
    }

    //Restituisce la lista dei soli professionisti
    internal List<Professionista> GetPro()
    {
        var command = new SQLiteCommand("SELECT Partecipanti.name, score FROM Partecipanti JOIN Professionisti ON Partecipanti.name == Professionisti.name;", connection);
        var reader = command.ExecuteReader();
        List<Professionista> users = new List<Professionista>();
        while (reader.Read())
        {
            int score;
            string nome = reader.GetString(0);
            if (reader.IsDBNull(1))
                score = -1;
            else
                score= reader.GetInt32(1);
            users.Add(new Professionista(nome, score));
        }
            // users.Add(new Professionista(reader.GetString(0), reader.GetInt32(1)));
        return users;
    }

    //Aggiunge un Professionista
    internal void RendiPro(string name)
    {
        Console.WriteLine("Score?");
        int score = Convert.ToInt32(Console.ReadLine());
        SQLiteCommand command = new SQLiteCommand($"INSERT INTO Professionisti (name, score) VALUES ('{name}', {score});", connection);
        try{
            command.ExecuteNonQuery();
        }catch (SQLiteException){
            Console.WriteLine("Partecipante già Professionista.");
        }
    }

    //Cambia lo score di un professionista
    internal void EditScore(string name)
    {
        Console.WriteLine("Insert new score:");
        int newScore = Convert.ToInt32(Console.ReadLine());
        SQLiteCommand command = new SQLiteCommand($"UPDATE Professionisti SET score = {newScore} WHERE name = '{name}';", connection);
        command.ExecuteNonQuery();
    }
}