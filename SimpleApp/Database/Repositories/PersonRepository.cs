using SimpleApp.Database.Configuration.BaseRepository;
using SimpleApp.Database.Interfaces;
using SimpleApp.Database.Models;

namespace SimpleApp.Database.Repositories
{
    public class PersonRepository : Repository<int, Persons>, IPersonRepository
    {
        public PersonRepository(SimpleAppContext context) : base(context)
        {
        }
    }
}
