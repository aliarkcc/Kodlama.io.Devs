namespace Application.Features.GithubProfiles.Dtos
{
    public class UpdatedGithubProfileDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ProfileAddress { get; set; }
    }
}