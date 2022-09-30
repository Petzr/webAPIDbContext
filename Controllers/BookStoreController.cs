
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
    public IEnumerable<Publisher> Get()
    {
        return db.Publishers.ToList();
    }

    [HttpGet("{id}")]
    public Publisher Get(int id)
    {
        return db.Publishers.SingleOrDefault(p => p.Id == id);
    }

    [HttpPost]
    public void Post(Publisher p)
    {
        db.Add(p);
        db.SaveChanges();
        Console.WriteLine("publisher toegevoegd");
    }

}