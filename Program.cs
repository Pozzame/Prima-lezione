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
    Console.WriteLine("Inserisci il nome. ('q' per uscire)");
    string? ins = Console.ReadLine();
    if (ins == "q")
        quit = ins;
    else names.Add(ins);
}
Console.WriteLine($"Hai inserito {names.Count} nomi.");
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
//Console.Clear();
List<string> partecipanti = new List<string> {"Mattia", "Matteo", "Serghej", "Allison", "Ginevra", "Daniele", "Sharon", "Silvano"}; //Dichiarazione e poplamento lista con costruttore
List<string> sorteggiati = new List<string>();
Random rng = new Random();
Console.WriteLine("START!!!!!");
foreach (string student in partecipanti) Console.WriteLine(student); //Stampa lista iniziale

while(partecipanti.Count > 0) //Cicla finché ci sono elementi nella lista
{
    int eleList = rng.Next(partecipanti.Count); //Genera un num casuale tra 0 e la dimensione della lista-1
    Console.WriteLine($"E' stato sorteggiato {partecipanti[eleList]} dalla List, e sarà spsotato nei sorteggiati");
    sorteggiati.Add(partecipanti[eleList]); //Aggiunge studente sorteggiato nella lista dei sorteggiati
    partecipanti.RemoveAt(eleList); //Rimuove elemento dalla lista
    Console.WriteLine("Studenti rimanenti:");
    foreach (string student in partecipanti) Console.WriteLine(student); //Stampa lista rimanente
    Console.WriteLine("Studenti sorteggiati:");
    foreach (string student in sorteggiati) Console.WriteLine(student); //Stampa lista sorteggiati
}