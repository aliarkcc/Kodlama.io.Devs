using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities
{
    public class GithubProfile : Entity
    {
        public string ProfileUserName { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public GithubProfile()
        {

        }
        public GithubProfile(int id, int userId, string profileUserName):this()
        {
            Id = id;
            ProfileUserName = profileUserName;
            UserId = userId;
        }
    }
}
