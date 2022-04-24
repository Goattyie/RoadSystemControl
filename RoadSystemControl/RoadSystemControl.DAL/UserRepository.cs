using RoadSystemControl.DAL.Interfaces;
using RoadSystemControl.Database;
using RoadSystemControl.Domains.Models;

namespace RoadSystemControl.DAL;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(RscContext context) : base(context)
    {
        
    }
}