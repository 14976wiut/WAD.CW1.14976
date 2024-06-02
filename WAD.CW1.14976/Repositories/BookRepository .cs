using Microsoft.EntityFrameworkCore;
using WAD.CW1._14976.Data;
using WAD.CW1._14976.Interfaces;
using WAD.CW1._14976.Models;

namespace WAD.CW1._14976.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId)
        {
            return await _context.Books.Where(b => b.AuthorId == authorId).ToListAsync();
        }
    }
}
