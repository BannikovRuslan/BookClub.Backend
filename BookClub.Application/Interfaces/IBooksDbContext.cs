using BookClub.Domains;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BookClub.Application.Interfaces
{
    public interface IBooksDbContext
    {
        DbSet<Book> Books { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
