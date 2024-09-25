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