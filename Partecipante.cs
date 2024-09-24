using System.Collections;

class Partecipante : IComparable<Partecipante>
{
    public Partecipante(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; set; }
    public virtual int VisScore()
    {
        return 0;
    }

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
static class EstensioniListaProfessionisti
{
    public static List<string> ToList(this List<Professionista> persone)
    {
        List<string> nomi = new List<string>();
        
        foreach (Professionista persona in persone)
        {
            if (persona != null)
            {
                nomi.Add(persona.Nome);
            }
        }
        return nomi;
    }
}