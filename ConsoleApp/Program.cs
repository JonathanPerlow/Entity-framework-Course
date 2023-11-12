using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

using(PublisherContext context = new())
{
    context.Database.EnsureCreated();
}

//GetAuthors();
AddAuthor();
//GetAuthors();
AddAuthorWithBook();
GetAuthorsWithBooks();


void AddAuthorWithBook()
{
    Author author = new() { FirstName = "J.R.R", LastName = "Tolkien" };
    author.Books.Add(new()
    {
        Title = "Lord of the rings",
        PublishedDate = new DateTime(1954, 6, 29)
    });
    using PublisherContext context = new();
    context.Authors.Add(author);
    context.SaveChanges();
}

void GetAuthorsWithBooks()
{
    using PublisherContext context = new();
    // Include method: for each of the autors you find also bring back their books.
    List<Author> authors = context.Authors.Include(author => author.Books).ToList();

    foreach(Author author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
        foreach(Book book in author.Books)
        {
            Console.WriteLine("*"+ book.Title);
        }
    }
}

void AddAuthor()
{
    Author author = new() { FirstName = "J.R.R", LastName = "Tolkien" };
    using PublisherContext context = new();
    context.Authors.Add(author);
    context.SaveChanges();
}

void GetAuthors()
{
    using PublisherContext context = new PublisherContext();
    List<Author> authors = context.Authors.ToList();
    foreach (Author author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }

}

