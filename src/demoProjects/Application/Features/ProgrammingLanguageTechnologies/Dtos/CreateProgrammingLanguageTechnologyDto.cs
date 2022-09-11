namespace Application.Features.ProgrammingLanguageTechnologies.Dtos
{
    public class CreateProgrammingLanguageTechnologyDto
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
    }
}
