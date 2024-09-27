using System.Runtime.Intrinsics.Arm;

class Controller
{
    private Model db;
    private View view;
    Random rng = new Random();

    public Controller(Model db, View view)
    {
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
                    view.Lista(db.Partecipanti.ToList());
                    break;
                case "Ordina": //Ordinamento
                    Console.WriteLine("d - Discendente?");
                    view.Lista(Sort(Console.ReadKey(true).KeyChar));
                    break;
                case "Ricerca": //Controlla se già presente
                    view.Presente(Search(ReadNome()));
                    break;
                case "Edita": //Edita
                    do
                    {
                        inserimento = view.EditMenu();
                        switch (inserimento)
                        {
                            case "Aggiunta nome": //Aggiunge nome
                                AddNome(ReadNome());
                                break;
                            case "Elimina partecipante": //Elimina partecipante
                                RemoveNome(view.Select());
                                break;
                            case "Modifica nome": //Modifica partecipante
                                string oldNome = ReadNome();
                                string NewNome = ReadNome();
                                EditNome(oldNome, NewNome);
                                break;
                            case "Rendi professionista":
                                RendiPro(view.Select());
                                break;
                            case "Modifica score Pro":
                                EditScore(view.Select(db.Professionisti.ToList()));
                                break;
                        }
                    } while (inserimento != "Back"); //Esce con 'b'
                    break;
                case "Salva lista": //Salva lista
                    File.Delete("Partecipanti.txt");
                    File.AppendAllLines("Partecipanti.txt", db.Partecipanti.ToList().ToList());
                    Console.WriteLine("Nuova lista salvata!");
                    break;
                case "Menù squadre": //Menù squadre
                    List<Partecipante> squadra1 = new List<Partecipante>();
                    List<Partecipante> squadra2 = new List<Partecipante>();
                    do
                    {
                        inserimento = view.SquadreMenu();
                        switch (inserimento)
                        {
                            case "Crea squadre": //Crea squadre
                                SquadreAuto(squadra1, squadra2);
                                break;
                            case "Squadre manuali":
                                SquadreManuali(squadra1, squadra2);
                                break;
                        }
                    } while (inserimento != "Back"); //Esce con "Back"
                    break;
            }
        } while (inserimento != "Esci"); //Esce con "Esci"
    }

    private void SquadreManuali(List<Partecipante> squadra1, List<Partecipante> squadra2)
    {
        List<Partecipante> temp = new List<Partecipante>(db.Partecipanti.ToList());
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
        view.Lista(db.Partecipanti.ToList(), squadra1, squadra2);
    }

    private void SquadreAuto(List<Partecipante> squadra1, List<Partecipante> squadra2)
    {
        List<Partecipante> temp = new List<Partecipante>(db.Partecipanti.ToList());
        Console.Clear();
        squadra1.Clear();
        squadra2.Clear();
        List<Partecipante> pro = new List<Partecipante>(db.Professionisti.ToList());
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
        view.Lista(db.Partecipanti.ToList(), squadra1, squadra2);
    }

    private void EditScore(string nom)
    {
        Professionista professionista = null;
        foreach (var u in db.Professionisti)
        {
            if (u.Nome == nom)
            {
                professionista = u;
                break;
            }
        }
        if (professionista != null)
        {
            Console.WriteLine("New score?");
            professionista.Score = Convert.ToInt32(Console.ReadLine());
            db.SaveChanges();
        }
    }

    private void RendiPro(string nom)
    {
        Console.WriteLine("Score?");
        int score = Convert.ToInt32(Console.ReadLine());
        db.Professionisti.Add(new Professionista(nom, score));
        db.SaveChanges();
    }

    private void EditNome(string oldNome, string newNome)
    {
        Partecipante partecipante = null;
        foreach (var u in db.Partecipanti)
        {
            if (u.Nome == oldNome)
            {
                partecipante = u;
                break;
            }
        }
        if (partecipante != null)
        {
            partecipante.Nome = newNome;
            Professionista professionista = null;
            foreach (var u in db.Professionisti)
            {
                if (u.Nome == oldNome)
                {
                    professionista = u;
                    break;
                }
            }
            if (professionista != null)
                professionista.Nome = oldNome;
            Console.WriteLine($"{oldNome} è stato modificato in {newNome}.");
            db.SaveChanges();
        }
        else Console.WriteLine($"{oldNome} non è nella lista.");
    }

    private void RemoveNome(string nom)
    {
        Partecipante partecipante = null;
        foreach (var u in db.Partecipanti)
        {
            if (u.Nome == nom)
            {
                partecipante = u;
                break;
            }
        }
        if (partecipante != null)
        {
            db.Partecipanti.Remove(partecipante);
            Professionista professionista1 = null;
            foreach (var u in db.Professionisti)
            {
                if (u.Nome == nom)
                {
                    professionista1 = u;
                    break;
                }
                if (professionista1 != null)
                {
                    db.Professionisti.Remove(professionista1);
                }
            }
            db.SaveChanges();
        }
        else
            Console.WriteLine("Partecipante non presente.");
    }

    private void AddNome(string nom)
    {
        Partecipante partecipante = null;
        foreach (var u in db.Partecipanti)
        {
            if (u.Nome == nom)
            {
                partecipante = u;
                break;
            }
        }
        if (partecipante == null)
        {
            db.Partecipanti.Add(new Partecipante(nom));
            db.SaveChanges();
        }
        else
            Console.WriteLine($"{nom} è già presente.");
    }

    private bool Search(string nom)
    {
        Partecipante partecipante = null;
        foreach (var u in db.Partecipanti)
        {
            if (u.Nome == nom)
            {
                partecipante = u;
                break;
            }
        }
        if (partecipante == null)
        {
            return false;
        }
        else
            return true;
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

    public List<Partecipante> Sort(char ordinamento)
    {
        List<Partecipante> lista = db.Partecipanti.ToList();
        if (ordinamento == 'd')
            lista.Reverse();
        else
            lista.Sort();
        return lista;
    }
}