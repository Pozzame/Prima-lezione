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
string[] students = ["Mattia", "Matteo", "Serghej", "Allison", "Ginevra", "Daniele", "Sharon", "Silvano"];
List<string> studenti = new List<string>(students);
Random rng = new Random();
Console.WriteLine(" - Lista:");
foreach (string student in studenti) Console.WriteLine(student);
Console.WriteLine(" - Array:");
foreach (string student in students) Console.WriteLine(student);

Console.WriteLine($"E' stato sorteggiato {studenti[rng.Next(studenti.Count)]} dalla List.\nE' stato sorteggiato {studenti[rng.Next(students.Length)]} dall'Array.");

int eleList = rng.Next(studenti.Count);
Console.WriteLine($"E' stato sorteggiato {studenti[eleList]} dalla List, e sarà rimosso");
studenti.RemoveAt(eleList);
foreach (string student in studenti) Console.WriteLine(student);
*/
/*Console.Clear();
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
    Console.Clear();
}
    Console.WriteLine("Studenti rimanenti:");
    foreach (string student in partecipanti) Console.WriteLine(student); //Stampa lista rimanente
    Console.WriteLine("\nStudenti sorteggiati:");
    foreach (string student in sorteggiati) Console.WriteLine(student); //Stampa lista sorteggiati
    Console.WriteLine();*/

//Console.Clear();
List<string> partecipanti = new List<string>() {"Mattia", "Matteo", "Serghej", "Allison", "Ginevra", "Daniele", "Sharon", "Silvano"};
char inserimento = 'o';
while (inserimento != 'q') //Esce con 'q'
{
    Console.WriteLine("-----Gestionale classe-----\n1 - Inserimento partecipante\n2 - Visualiza partecipanti\n3 - Ordina\n4 - Ricerca\n5 - Rimuovi\n6 - Modifica\nq per uscire"); //Menù
    inserimento = Console.ReadKey(true).KeyChar; //hide carattere premuto
    switch (inserimento)
    {
        case '1': //Aggiunge nome
            string nom = ReadNome();
            if (partecipanti.Contains(nom)) Console.WriteLine($"{nom} è già presente."); else partecipanti.Add(nom); //Controlal che il nome non sia già presente
            break;
        case '2': // Lista partecipanti
            Console.Clear();
            Console.WriteLine($"Partecipanti: ({partecipanti.Count})");
            foreach (string studente in partecipanti) Console.WriteLine(studente);
            Console.WriteLine();
            break;
        case '3': //Ordinamento
            partecipanti.Sort();
            Console.WriteLine("d - Discendente?");
            if (Console.ReadKey(true).KeyChar == 'd') partecipanti.Reverse();
            Console.Clear();
            break;
        case '4': //Controlla se già presente
            if (partecipanti.Contains(ReadNome())) Console.WriteLine("Presente"); else Console.WriteLine("Assente");
            break;
        case '5': //Elimina partecipante
            nom = ReadNome();
            if (partecipanti.Contains(nom)) partecipanti.Remove(nom); else Console.WriteLine($"{nom} non è presente");
            break;
        case '6': //Modifica partecipante
            nom = ReadNome();
            if (partecipanti.Contains(nom)) //Verifica che sia presente
            {
                string nuovoNome = ReadNome();
                partecipanti[partecipanti.IndexOf(nom)] = nuovoNome; //Sostituisce il nome all'indice del nome vecchio con quello nuovo
                Console.WriteLine($"{nom} è stato modificato in {nuovoNome}");
            }
            else Console.WriteLine($"{nom} non è nella lista.");
            break;
        default: //Non valido
            Console.Clear();
            Console.WriteLine("Scelta non valida.\n");
            break;
    }
}
string ReadNome()
{
    Console.WriteLine("Inserire nome");
    string nome = Console.ReadLine()!.Trim(); //Rimuove spazi prima e dopo
    return nome[0].ToString().ToUpper() + nome.Substring(1); //Mette maiuscola solo la prima lettera
}