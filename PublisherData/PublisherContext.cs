using Microsoft.EntityFrameworkCore;
using PublisherDomain;

namespace PublisherData;
public class PublisherContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Hard codding the database connectionstring for the demo. Will inject it with asp.net later in the run time.
        optionsBuilder.UseSqlServer(
            "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PubDatabase"
            );
    }
}
