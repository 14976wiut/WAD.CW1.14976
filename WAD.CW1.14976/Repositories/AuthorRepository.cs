using Microsoft.EntityFrameworkCore;
using WAD.CW1._14976.Data;
using WAD.CW1._14976.Interfaces;
using WAD.CW1._14976.Models;

namespace WAD.CW1._14976.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Author>> GetAuthorsWithBooksAsync()
        {
            return await _context.Authors.Include(a => a.Books).ToListAsync();
        }
    }
}
