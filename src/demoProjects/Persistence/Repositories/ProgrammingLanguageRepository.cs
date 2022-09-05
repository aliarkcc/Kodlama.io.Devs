using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ProgrammingLanguageRepository : EfRepositoryBase<ProgrammingLanguage, DatabaseContext>, IProgrammingLanguageRepository
    {
        public ProgrammingLanguageRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
