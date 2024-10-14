class Professionista : Partecipante
{
    public Professionista(string nome, int score) : base(nome)
    {
        Score = score;
    }

    public int Score { get; set; }

    public override string VisScore()
    {
        return Convert.ToString(Score) ?? "-";
    }
}

static class EstensioniArrayProfessionisti
{
    public static string[] ToArrays(this List<Professionista> profs)
    {
        string[] righe = new string[profs.Count];

        for (int i = 0; i < righe.Length; i++)
            righe[i] = $"{profs[i].Nome},{profs[i].Score}";
        return righe;
    }
}