using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class ProgrammingLanguage:Entity
    {
        public string ProgrammingLanguageName { get; set; }
        public virtual ICollection<ProgrammingLanguageTechnology> ProgrammingLanguageTechnologies { get; set; }

        public ProgrammingLanguage()
        {

        }
        public ProgrammingLanguage(int id, string programmingLanguageName):this()
        {
            Id = id;
            ProgrammingLanguageName = programmingLanguageName;
        }
    }
}
