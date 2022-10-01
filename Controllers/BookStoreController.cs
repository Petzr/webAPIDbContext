
using Microsoft.AspNetCore.Mvc;

namespace probeersel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookStoreController : ControllerBase
{
    private BookStoreDbContext db;
    public BookStoreController(BookStoreDbContext db)
    {
        this.db = db;
    }

    [HttpGet]
    [Route("GetPublishers")]
    public IEnumerable<Publisher> GetPublishers()
    {
        return db.Publishers.ToList();
    }

    [HttpGet]
    [Route("GetBooks")]
    public IEnumerable<Book> GetBooks()
    {
        return db.Books.ToList();
    }

    [HttpGet("{id}")]
    public Publisher? GetPublisherWithId(int id)
    {
        return db.Publishers.SingleOrDefault(p => p.Id == id);
    }

    [HttpPost]
    [Route("AddPublisher")]
    public void Post(Publisher p)
    {
        db.Add(p);
        db.SaveChanges();
        Console.WriteLine("Publisher toegevoegd");
    }

    [HttpPost]
    [Route("AddBook")]
    public void Post(Book p)
    {
        db.Add(p);
        db.SaveChanges();
        Console.WriteLine("Book toegevoegd");
    }

}