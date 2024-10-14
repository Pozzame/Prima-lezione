using Microsoft.EntityFrameworkCore;



class Model : DbContext
{
    public DbSet<Partecipante> Partecipanti { get; set; }
    public DbSet<Professionista> Professionisti { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder option)
    {
        option.UseSqlite("Data Source = database.db");
    }
}