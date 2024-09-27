using Microsoft.EntityFrameworkCore;

//     //Inizializzazione DB da files nomi
//         //Inserisce i partecipanti nel db da file
//         List<string> partecipanti = new List<string>(File.ReadAllLines($"{path}Partecipanti.txt")); //Legge il file nomi e li inseriesce in una List
//         foreach (var partecipante in partecipanti)
//         {
//             command = new SQLiteCommand($"insert into Partecipanti (name) values ('{partecipante}');", connection);
//             command.ExecuteNonQuery();
//         }
//         //Inserisce i professionisti nel db da csv
//         var reader = new StreamReader(File.OpenRead($"{path}Professionisti.csv"));
//         List<Professionista> pro = new List<Professionista>();
//         while (!reader.EndOfStream) 
//         {
//             var line = reader.ReadLine();
//             var values = line!.Split(',');
//             pro.Add(new Professionista(values[0], Convert.ToInt32(values[1])));
//         }
//         foreach (var element in pro) 
//         {
//             command = new SQLiteCommand($"insert into Professionisti (name, score) values ('{element.Nome}', {element.Score});", connection);
//             command.ExecuteNonQuery();
//         }

class Model : DbContext
{
    public DbSet<Partecipante> Partecipanti { get; set; }
    public DbSet<Professionista> Professionisti { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder option)
    {
        option.UseSqlite("Data Source = db.db");
    }
}