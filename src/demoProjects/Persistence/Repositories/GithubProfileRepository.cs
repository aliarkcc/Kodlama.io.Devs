using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class GithubProfileRepository : EfRepositoryBase<GithubProfile, DatabaseContext>, IGithubProfilerRepository
    {
        public GithubProfileRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
