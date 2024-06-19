Console.WriteLine("Scrivi qualcosa");
string a = Console.ReadLine()!;
Console.WriteLine("Hai scritto: " + a);

Console.WriteLine("Con che tasto vuoi uscire?");
ConsoleKeyInfo c = Console.ReadKey();
Console.WriteLine("\nHai scelto: " + c.KeyChar + ". Prova! :-D");

while (Console.ReadKey() != c) {}