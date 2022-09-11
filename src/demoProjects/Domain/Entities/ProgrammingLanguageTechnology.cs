using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class ProgrammingLanguageTechnology:Entity
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }

        public ProgrammingLanguageTechnology()
        {

        }
        public ProgrammingLanguageTechnology(int id,string name, int programmingLanguageId)
        {
            Id = id;
            Name = name;
            ProgrammingLanguageId = programmingLanguageId;
        }
    }
}
