using Microsoft.EntityFrameworkCore;

class Model : DbContext
{
    string path = @"C:\Users\pozza\Documents\VisualStudioCode\Prima-lezione\";
    public DbSet<Partecipante> Partecipanti { get; set; }
    public DbSet<Professionista> Professionisti { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder option)
    {
        option.UseSqlite($"Data Source = {path}database.db");
    }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configura la strategia TPT (Table Per Type)
        modelBuilder.Entity<Partecipante>()
            .ToTable("Partecipanti");

        // Configura Professionista come entità concreta con tutte le sue proprietà
        modelBuilder.Entity<Professionista>()
            .ToTable("Professionisti");

        // Aggiungi il campo Nome anche nella tabella Professionisti
        modelBuilder.Entity<Professionista>()
            .Property(p => p.Nome)
            .IsRequired();  // Nome sarà obbligatorio in Professionisti
    }
}