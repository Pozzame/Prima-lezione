using System.Runtime.Intrinsics.Arm;

class Controller
{
    private Model db;
    private View view;
    Random rng = new Random();

    public Controller(Model db, View view){
        this.db = db;
        this.view = view;
    }

    public void Menu()
    {
        Console.Clear();
        string inserimento;
        do
        {
            inserimento = view.MainMenu();
            switch (inserimento)
            {
                case "Visualiza partecipanti": //Lista partecipanti
                    Console.Clear();
                    view.Lista(db.Get());
                    break;
                case "Ordina": //Ordinamento
                    Console.WriteLine("d - Discendente?");
                    view.Lista(db.Sort(Console.ReadKey(true).KeyChar));
                    break;
                case "Ricerca": //Controlla se già presente
                    view.Presente(db.Contains(ReadNome()));
                    break;
                case "Edita": //Edita
                    do
                    {
                        inserimento = view.EditMenu();
                        switch (inserimento)
                        {
                            case "Aggiunta nome": //Aggiunge nome
                                string nom = ReadNome();
                                if (db.Contains(nom)) Console.WriteLine($"{nom} è già presente."); else db.Add(nom); //Controlla che il nome non sia già presente
                                break;
                            case "Elimina partecipante": //Elimina partecipante
                                db.Remove(view.Select());
                                break;
                            case "Modifica nome": //Modifica partecipante
                                nom = ReadNome();
                                if (db.Contains(nom)) //Verifica che sia presente
                                {
                                    string nuovoNome = ReadNome();
                                    db.Edit(nom, nuovoNome); //Sostituisce il nome all'indice del nome vecchio con quello nuovo
                                    Console.WriteLine($"{nom} è stato modificato in {nuovoNome}.");
                                }
                                else Console.WriteLine($"{nom} non è nella lista.");
                                break;
                            case "Rendi professionista":
                                db.RendiPro(view.Select());
                                break;
                            case "Modifica score Pro":
                                db.EditScore(view.Select(db.GetPro()));
                                break;
                        }
                    } while (inserimento != "Back"); //Esce con 'b'
                    break;
                case "Salva lista": //Salva lista
                    File.Delete("Partecipanti.txt");
                    File.AppendAllLines("Partecipanti.txt", db.GetStrings());
                    Console.WriteLine("Nuova lista salvata!");
                    break;
                case "Menù squadre": //Menù squadre
                    List<Partecipante> squadra1 = new List<Partecipante>();
                    List<Partecipante> squadra2 = new List<Partecipante>();
                    do
                    {
                        inserimento = view.SquadreMenu();
                        List<Partecipante> temp;
                        switch (inserimento)
                        {
                            case "Crea squadre": //Crea squadre
                                temp = new List<Partecipante>(db.Get());
                                Console.Clear();
                                squadra1.Clear();
                                squadra2.Clear();
                                List<Partecipante> pro= new List<Partecipante>(db.GetPro());
                                while (pro.Count > 0) //Cicla finché la lista dei Professionisti non si svuota
                                {
                                    int scelto = rng.Next(pro.Count); //Sceglie un partecipante a caso fra i rimanenti
                                    if (squadra1.Count > squadra2.Count) squadra2.Add(pro[scelto]); else squadra1.Add(pro[scelto]); //Lo inserisce nella squadra più cota iniziando dalla 1
                                    RemovePartecipante(temp, pro[scelto].Nome); //Lo rimuove dalla lista iniziale
                                    pro.RemoveAt(scelto);
                                }
                                while (temp.Count > 0) //Cicla finché la lista dai partecipanto non si svuota
                                {
                                    int scelto = rng.Next(temp.Count); //Sceglie un partecipante a caso fra i rimanenti
                                    if (squadra1.Count > squadra2.Count) squadra2.Add(temp[scelto]); else squadra1.Add(temp[scelto]); //Lo inserisce nella squadra più cota iniziando dalla 1
                                    temp.RemoveAt(scelto); //Lo rimuove dalla lista iniziale
                                }
                                view.Lista(db.Get(), squadra1, squadra2);
                                break;
                            case "Squadre manuali":
                                temp = new List<Partecipante>(db.Get());
                                Console.Clear();
                                squadra1.Clear();
                                squadra2.Clear();
                                List<string> squadra1S = view.SelSquadra();
                                foreach (string item in squadra1S) 
                                {
                                    squadra1.Add(new Partecipante(item));
                                    RemovePartecipante(temp, item);
                                }
                                //foreach (Partecipante item in squadra1) temp.Remove(item);
                                squadra2 = new List<Partecipante>(temp);
                                view.Lista(db.Get(), squadra1, squadra2);
                                break;
                        }
                    } while (inserimento != "Back"); //Esce con "Back"
                    break;
            }
        } while (inserimento != "Esci"); //Esce con "Esci"
    }

    public string ReadNome() //Lettura nome con controllo digitazione
    {
        Console.WriteLine("Inserire nome");
        string nome = Console.ReadLine()!.Trim(); //Rimuove spazi prima e dopo
        return nome[0].ToString().ToUpper() + nome.Substring(1); //Mette maiuscola solo la prima lettera
    }
    public void RemovePartecipante(List<Partecipante> partecipanti, string nome)
    {
        for (int i = 0; i < partecipanti.Count; i++)
            if (partecipanti[i].Nome == nome)
                partecipanti.RemoveAt(i);

    }
}