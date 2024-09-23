/*Console.WriteLine("Scrivi qualcosa");
string a = Console.ReadLine()!; //null-forgiving sopprime il warning
Console.WriteLine("Come ti chiami di nome?");
string? nome = Console.ReadLine(); //make nullable a non-nullable type
Console.WriteLine("Cognome?");
string? cognome = Console.ReadLine();
Console.WriteLine("Soprannome?");
string? soprannome = Console.ReadLine();
Console.WriteLine($"{nome} {soprannome} {cognome} Hai scritto: " + a); //Interpolazione e concatenazione stringhe

Console.WriteLine("Scrivi un numero.");
int num = Convert.ToInt32(Console.ReadLine()); //Se stringa restituisce 0
//int num = int.Parse(Console.ReadLine()!); //Se stringa genera eccezione

int ver = 13;

if (num == ver){
    Console.Write("{0:D3}", num);
    Console.WriteLine(" è uguale a " + ver);}
else if (num < ver)
    Console.WriteLine($"{num} è minore di {ver}");
else if (num > ver)
    Console.WriteLine($"{num} è maggiore di {ver}");

switch (num) {
    case 1:
        Console.WriteLine("Lunedì");
        break;
    case 2:
        Console.WriteLine("Martedì");
        break;
    case 3:
        Console.WriteLine("Mercoledì");
        break;
    case 4:
        Console.WriteLine("Giovedì");
        break;
    case 5:
        Console.WriteLine("Venerdì");
        break;
    case 6:
        Console.WriteLine("Sabato");
        break;
    case 7:
        Console.WriteLine("Domenica");
        break;
    default:
        Console.WriteLine($"{num} Non è un giorno della settimana.");
        break;
}

Console.WriteLine("Con che tasto vuoi uscire?");
ConsoleKeyInfo c = Console.ReadKey(true); //hide carattere premuto
Console.WriteLine("\nHai scelto: " + c.KeyChar + ". Provalo! :-D");

while (Console.ReadKey() != c) { }*/
/*
string[] nomi = new string[3];
//foreach (string nome in nomi) nome = Console.Read();
for (int i = 0; i<nomi.Length;i++)
    nomi[i] = Console.ReadLine()!;
foreach (string nome in nomi) Console.WriteLine(nome);

List<string?> names = new List<string?>();
string quit = "o";
while (quit != "q")
{
    Console.WriteLine("inserimentoerisci il nome. ('q' per uscire)");
    string? inserimento = Console.ReadLine();
    if (inserimento == "q")
        quit = inserimento;
    else names.Add(inserimento);
}
Console.WriteLine($"Hai inserimentoerito {names.Count} nomi.");
foreach (string? name in names) Console.WriteLine(name);
*/

/*
using Spectre.Console;
//string[] students = ["Mattia", "Matteo", "Serghej", "Allison", "Ginevra", "Daniele", "Sharon", "Silvano"];
List<string> studenti = new List<string> {"Mattia", "Matteo", "Serghej", "Allison", "Ginevra", "Daniele", "Francesco", "Silvano"};
Random rng = new Random();
List<string> squadra1 = new List<string>();
List<string> squadra2 = new List<string>();
/*Console.WriteLine(" - Studenti:");
foreach (string student in studenti) Console.WriteLine(student);/*
Console.WriteLine(" - Array:");
foreach (string student in students) Console.WriteLine(student);

Console.WriteLine($"E' stato sorteggiato {studenti[rng.Next(studenti.Count)]} dalla List.\nE' stato sorteggiato {studenti[rng.Next(students.Length)]} dall'Array.");
var lista = new Table();
lista.AddColumn("Studenti");
foreach (string student in studenti) lista.AddRow(student);
AnsiConsole.Write(lista);
while (studenti.Count > 0)
{
    int scelto = rng.Next(studenti.Count);
    if (studenti.Count%2==0)
    {
        squadra1.Add(studenti[scelto]);
        //Console.WriteLine($"E' stato sorteggiato {studenti[scelto]} dalla List, e sarà inserito nella squadra1");
    } else 
    {
        squadra2.Add(studenti[scelto]);
        //Console.WriteLine($"E' stato sorteggiato {studenti[scelto]} dalla List, e sarà inserito nella squadra2");
    }
    studenti.RemoveAt(scelto);
}
Console.WriteLine(" - Squadra1:");
foreach (string student in squadra1) Console.WriteLine(student);
Console.WriteLine(" - Squadra2:");
foreach (string student in squadra2) Console.WriteLine(student);
// esempio di tabella
var table = new Table();
table.AddColumn("Squadra1");
table.AddColumn("Squadra2");
for (int i=0; i<squadra1.Count;i++) table.AddRow(squadra1[i], squadra2[i]);
AnsiConsole.Write(table);

int eleList = rng.Next(studenti.Count);
Console.WriteLine($"E' stato sorteggiato {studenti[scelto]} dalla List, e sarà rimosso");
studenti.RemoveAt(eleList);
foreach (string student in studenti) Console.WriteLine(student);
*/

/*
using Spectre.Console;
            var table6 = new Table();
            table6.AddColumn("Nome");
            table6.AddColumn("Soprannome");
            table6.AddColumn("Cognome");
            table6.AddColumn("Anno");

            var partecipanti2 = new Dictionary<(string, string), (string, int)>
            {
                {("Mario", "Cane"), ("Rossi", 1990)},
                {("Luca", "Nonno"), ("Verdi", 1980)},
                {("Paolo", "Ciccio"), ("Bianchi", 1970)}
            };
            foreach (var partecipante in partecipanti2)
                table6.AddRow(partecipante.Key.Item1, partecipante.Key.Item2, partecipante.Value.Item1, partecipante.Value.Item2.ToString());
            AnsiConsole.Write(table6);
*/

/*

List<string> partecipanti = new List<string> {"Mattia", "Matteo", "Serghej", "Allison", "Ginevra", "Daniele", "Sharon", "Silvano"}; //Dichiarazione e popolamento lista con costruttore
List<string> sorteggiati = new List<string>(); //Lista sorteggiati creata vuota
Random rng = new Random();

while(partecipanti.Count > 0) //Cicla finché ci sono elementi nella lista
{
    Console.WriteLine("Studenti rimanenti:");
    foreach (string student in partecipanti) Console.WriteLine(student); //Stampa lista partecipanti rimanenti
    Console.WriteLine("\nStudenti sorteggiati:");
    foreach (string student in sorteggiati) Console.WriteLine(student); //Stampa lista partecipanti sorteggiati
    int eleList = rng.Next(partecipanti.Count); //Genera un num casuale tra 0 e la dimensione della lista-1
    Console.WriteLine($"\nE' stato sorteggiato {partecipanti[eleList]} dalla List, e sarà spsotato nei sorteggiati");
    sorteggiati.Add(partecipanti[eleList]); //Aggiunge studente sorteggiato nella lista dei sorteggiati
    partecipanti.RemoveAt(eleList); //Rimuove elemento dalla lista
    Console.ReadKey(true);
    
}
    Console.WriteLine("Studenti rimanenti:");
    foreach (string student in partecipanti) Console.WriteLine(student); //Stampa lista rimanente
    Console.WriteLine("\nStudenti sorteggiati:");
    foreach (string student in sorteggiati) Console.WriteLine(student); //Stampa lista sorteggiati
    Console.WriteLine();
*/
//TODO: Lettura da csv e storage in un json della rubrica. Calendario (Calendar d spectre e Date d c#) condiviso con persistenza.
using Spectre.Console;
class Program
{
    private static void Main()
    {
        Model db = new Model();
        View view= new View(db);
        var controller = new Controller(db, view);

        view.Menu();
    }       
}

