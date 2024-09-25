class Partecipante : IComparable<Partecipante>
{
    public Partecipante(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; set; }
    public virtual string VisScore()
    {
        return "-";
    }

//Metodi per implementare IComparable e rendere le list<Partecipanti> sortabili
    public int CompareTo(Object? x, Object? y)
    {
        Partecipante p1 = (Partecipante)x!;
        Partecipante p2 = (Partecipante)y!;
        if (p1.Nome!=p2.Nome)
            return 1;
        return 0;
    }
    int IComparable<Partecipante>.CompareTo(Partecipante? other)
    {
        return Nome.CompareTo(other!.Nome);
    }
}
