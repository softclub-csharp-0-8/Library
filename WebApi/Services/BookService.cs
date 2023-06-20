using WebApi.Context;
using WebApi.Dtos;
using WebApi.Entities;

namespace WebApi.Services;

public class BookService
{
    private readonly DataContext _context;

    public BookService(DataContext context)
    {
        _context = context;
    }

    public List<Book> Books()
    {
        return _context.Books.ToList();
    }
    
    public Book GetBookById(int id)
    {
        return _context.Books.Find(id);
    }
    

    public AddBookDto AddBook(AddBookDto model)
    {
        var book = new Book()
        {
            Advance = model.Advance,
            Isbn = model.Isbn,
            Price = model.Price,
            PublishedDate = model.PublishedDate,
            Title = model.Title,
            YtdSales = model.YtdSales,
            Type = model.Type,
            PublisherId = model.PublisherId
        };
        _context.Books.Add(book);
        _context.SaveChanges();
        return model;
    }
    
    public Book UpdateBook(Book book)
    {
        _context.Books.Update(book);
        _context.SaveChanges();
        return book;
    }
    
    public bool DeleteBook(int id)
    {
       var book =  _context.Books.Find(id);
       _context.Books.Remove(book);
       var result =  _context.SaveChanges();
        return result == 1;
    }
    
    
}