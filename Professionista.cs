class Professionista : Partecipante
{
    private int score;
    public Professionista(string nome, int score) : base(nome)
    {
        this.score=score;
    }

    public int Score { get => score; set => score = value; }

    public override string VisScore()
    {
        return Convert.ToString(score);
    }
}

static class EstensioniListaProfessionisti
{
    public static List<string> ToList(this List<Professionista> persone)
    {
        List<string> nomi = new List<string>();
        
        foreach (Professionista persona in persone)
            if (persona != null)
            nomi.Add(persona.Nome);
        return nomi;
    }
}