using WAD.CW1._14976.Interfaces.BaseInterfaces;
using WAD.CW1._14976.Models;

namespace WAD.CW1._14976.Interfaces
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<IEnumerable<Author>> GetAuthorsWithBooksAsync();
    }
}
