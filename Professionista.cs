class Professionista : Partecipante
{
    private string nome;

    public Professionista(string nome, int score) : base(nome)
    {
        Score=score;
    }

    public int Score { get; set; }
    // public string Nome { get => base.Nome; set => base.Nome = value; }

    public override string VisScore()
    {
        return Convert.ToString(Score) ?? "-";
    }
}

