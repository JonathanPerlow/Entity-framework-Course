using Microsoft.EntityFrameworkCore;
using PublisherDomain;

namespace PublisherData;
public class PublisherContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}
