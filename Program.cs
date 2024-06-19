Console.WriteLine("Scrivi qualcosa");
string a = Console.ReadLine()!;
Console.WriteLine("Come ti chiami di nome?");
string nome = Console.ReadLine()!;
Console.WriteLine("Cognome?");
string cognome = Console.ReadLine()!;
Console.WriteLine("Soprannome?");
string soprannome = Console.ReadLine()!;
Console.WriteLine($"{nome} {soprannome} {cognome} Hai scritto: " + a);

Console.WriteLine("Con che tasto vuoi uscire?");
ConsoleKeyInfo c = Console.ReadKey();
Console.WriteLine("\nHai scelto: " + c.KeyChar + ". Provalo! :-D");

while (Console.ReadKey() != c) {}