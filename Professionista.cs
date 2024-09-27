class Professionista : Partecipante
{
    public Professionista(string nome, int score) : base(nome)
    {
        Score=score;
    }

    public int Score { get; set; }

    public override string VisScore()
    {
        return Convert.ToString(Score) ?? "-";
    }
}

