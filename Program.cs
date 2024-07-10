﻿/*Console.WriteLine("Scrivi qualcosa");
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


string[] students = ["Mattia", "Matteo", "Serghej", "Allison", "Ginevra", "Daniele", "Sharon", "Silvano"];*/
/*
using Spectre.Console;
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
Console.Clear();
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
    Console.WriteLine();
*/
//Console.Clear();
using Spectre.Console;
Random rng = new Random();
List<string> partecipanti = new List<string>() { "Mattia", "Matteo", "Serghej", "Allison", "Ginevra", "Daniele", "Francesco", "Silvano" };
List<string> squadra1 = new List<string>();
List<string> squadra2 = new List<string>();
char inserimento = 'o';
while (inserimento != 'q') //Esce con 'q'
{
    Console.WriteLine("-----Gestionale classe-----\n1 - Visualiza partecipanti\n2 - Ordina\n3 - Ricerca\n4 - Edita\n5 - Crea squadre\nq per uscire"); //Menù principale
    inserimento = Console.ReadKey(true).KeyChar; //hide carattere premuto
    switch (inserimento)
    {
        case '1': //Lista partecipanti
            Console.Clear();
            Console.WriteLine($"Partecipanti: ({partecipanti.Count})");
            foreach (string studente in partecipanti) Console.WriteLine(studente);
            Console.WriteLine();
            break;
        case '2': //Ordinamento
            partecipanti.Sort();
            Console.WriteLine("d - Discendente?");
            if (Console.ReadKey(true).KeyChar == 'd') partecipanti.Reverse();
            Console.Clear();
            break;
        case '3': //Controlla se già presente
            if (partecipanti.Contains(ReadNome())) Console.WriteLine("Presente"); else Console.WriteLine("Assente");
            break;
        case '4': //Edita
            do
            {
                Console.WriteLine("-----Menù edit-----\n1 - Aggiunta nome\n2 - Elimina partecipante\n3 - Modifica\nb - Back"); //Menù edit
                inserimento = Console.ReadKey(true).KeyChar; //hide carattere premuto
                switch (inserimento)
                {
                    case '1': //Aggiunge nome
                        string nom = ReadNome();
                        if (partecipanti.Contains(nom)) Console.WriteLine($"{nom} è già presente."); else partecipanti.Add(nom); //Controlal che il nome non sia già presente
                        break;
                    case '2': //Elimina partecipante
                        nom = ReadNome();
                        if (partecipanti.Contains(nom))
                        {
                            partecipanti.Remove(nom);
                            Console.WriteLine($"{nom} è stato rimosso.");
                        }
                        else Console.WriteLine($"{nom} non è presente");
                        break;
                    case '3': //Modifica partecipante
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
            } while (inserimento != 'b'); //Esce con 'b'
            break;
        case '5': //Crea squadre
            Console.Clear();
            var lista = new Table();
            lista.AddColumn("Partecipanti");
            foreach (string student in partecipanti) lista.AddRow(student); //Crea una tabella con i partecipanti
            AnsiConsole.Write(lista); //Stampa la tabella
            while (partecipanti.Count > 0) //Cicla finché la lista dai partecipanto non si svuota
            {
                int scelto = rng.Next(partecipanti.Count); //Sceglie un partecipante a caso fra i rimanenti
                if (squadra1.Count > squadra2.Count) squadra2.Add(partecipanti[scelto]); else squadra1.Add(partecipanti[scelto]); //Lo inserisce nella squadra più cota iniziando dalla 1
                partecipanti.RemoveAt(scelto); //Lo rimuove dalal lista iniziale
            }
            var table = new Table();
            table.AddColumn("Squadra1");
            table.AddColumn("Squadra2");
            if (squadra1.Count==squadra2.Count) for (int i = 0; i < squadra1.Count; i++) table.AddRow(squadra1[i], squadra2[i]); //Crea la tabella delle squadre se hanno lo stesso numero
            else //Crea la tabella delle squadre se la prima ne ha uno in più
            {
                int i;
                for ( i = 0; i < squadra2.Count; i++) table.AddRow(squadra1[i], squadra2[i]);
                table.AddRow(squadra1[i], ""); 
            }
            AnsiConsole.Write(table); //Stampa la tabella
            break;
        default: //Non valido
            Console.Clear();
            Console.WriteLine("Scelta non valida.\n");
            break;
    }
}
string ReadNome() //Lettura nome con controllo digitazione
{
    Console.WriteLine("Inserire nome");
    string nome = Console.ReadLine()!.Trim(); //Rimuove spazi prima e dopo
    return nome[0].ToString().ToUpper() + nome.Substring(1); //Mette maiuscola solo la prima lettera
}

/*
var colori = new Dictionary<string, string>{
{"rosso", "#FF0000"},
{"verde", "#00FF00"},
{"blu", "#0000FF"}};

foreach (KeyValuePair<string,string> colore in colori) // KeyValuePair è una struttura che rappresenta una coppia chiave-valore
{
    Console.WriteLine($"Il colore {colore.Key} ha il codice {colore.Value}");
}
var listaSpesa = new Dictionary<string, int>();
listaSpesa.Add("pane", 1);
listaSpesa.Add("latte", 2);

// Aggiungere un nuovo articolo
listaSpesa["uova"] = 12;

// Incrementare la quantità di un articolo già presente
listaSpesa["pane"] = listaSpesa["pane"] + 1;

foreach (KeyValuePair<string, int> articolo in listaSpesa)
{
    // Console.WriteLine("Articolo: " + articolo.Key + ", Quantità: " + articolo.Value);
    // oppure utilizzando l'interpolazione di stringa
    Console.WriteLine($"Articolo: {articolo.Key}, Quantità: {articolo.Value}");
}*/