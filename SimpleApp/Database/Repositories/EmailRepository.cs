using SimpleApp.Database.Configuration.BaseRepository;
using SimpleApp.Database.Interfaces;
using SimpleApp.Database.Models;

namespace SimpleApp.Database.Repositories
{
    public class EmailRepository : Repository<int, Emails>, IEmailRepository
    {
        public EmailRepository(SimpleAppContext context) : base(context)
        {
        }
    }
}
