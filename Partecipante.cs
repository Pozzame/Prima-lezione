class Partecipante{
    public Partecipante(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; set; }
    public virtual int VisScore()
    {
        return 0;
    }
}