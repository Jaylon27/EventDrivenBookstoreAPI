using System.Threading.Tasks;
using EventDrivenBookstoreAPI.Models;

namespace EventDrivenBookstoreAPI.Interface
{
    public interface IBookService
    {
        Task<Book> CreateBookAsync(Book book);
       
        Task<Book> GetBookByIdAsync(string bookId);
        
    }
}