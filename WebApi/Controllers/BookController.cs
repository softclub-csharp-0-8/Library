using Microsoft.AspNetCore.Mvc;
using WebApi.Context;
using WebApi.Dtos;
using WebApi.Entities;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly BookService _service;

    public BookController(BookService service)
    {
        _service = service;
    }

    [HttpGet("GetBooks")]
    public List<Book> GetBooks()
    {
        return _service.Books();
    }
    
    [HttpGet("GetBookById")]
    public Book GetBookById(int id)
    {
        return _service.GetBookById(id);
    }
    
    [HttpPost("AddBook")]
    public AddBookDto AddBook(AddBookDto book)
    {
        return _service.AddBook(book);
    }

    [HttpPut("UpdateBook")]
    public Book UpdateBook(Book book)
    {
        return _service.UpdateBook(book);
    }
    
    [HttpDelete("DeleteBook")]
    public bool DeleteBook(int id)
    {
        return _service.DeleteBook(id);
    }
    
    
}