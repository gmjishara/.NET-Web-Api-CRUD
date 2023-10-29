using BookInventorySystem.Data;
using BookInventorySystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookInventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public BooksController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            if (book != null)
            {
                _appDbContext.Books.Add(book);
                await _appDbContext.SaveChangesAsync();
                return Ok(book);
            }

            return BadRequest();
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books=await _appDbContext.Books.ToListAsync();
            if(books != null)
            {
                return Ok(books);
            }

            return NotFound("No Records Found");

        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var book = await _appDbContext.Books.FindAsync(id);
            if(book != null)
            {
                return Ok(book);
            }

            return NotFound($"The Book Id {id} is not found");
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            var product= await _appDbContext.Books.FindAsync(id);
            if(product != null)
            {
                product.Title = book.Title;
                product.Author = book.Author;
                product.ISBN= book.ISBN;
                product.Year = book.Year;
                product.quantity = book.quantity;
                product.price = book.price;

                await _appDbContext.SaveChangesAsync();
                return Ok(product);
            }

            return NotFound($"Prodcut Id {id} is not found");
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var product = await _appDbContext.Books.FindAsync(id);
            if(product != null)
            {
                _appDbContext.Books.Remove(product);
                await _appDbContext.SaveChangesAsync();
                return Ok(product);
            }

            return NotFound($"The Book Id {id} is not found");

        }


    }

    


}
