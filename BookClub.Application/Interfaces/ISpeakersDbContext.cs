using BookClub.Domains;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace BookClub.Application.Interfaces
{
    public interface ISpeakersDbContext
    {
        DbSet<Speaker> Speakers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
