class Professionisti : Partecipante
{
    private int score;
    public Professionisti(string nome, int score) : base(nome)
    {
        Score=score;
    }

    public int Score { get; set; }
}