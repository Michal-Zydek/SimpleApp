using SimpleApp.Database.Configuration.BaseRepository;
using SimpleApp.Database.Models;

namespace SimpleApp.Database.Interfaces
{
    public interface IPersonRepository : IRepository<int, Persons>
    {
    }
}
