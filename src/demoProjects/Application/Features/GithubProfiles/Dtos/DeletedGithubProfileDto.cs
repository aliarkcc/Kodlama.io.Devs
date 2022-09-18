using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubProfiles.Dtos
{
    public class DeletedGithubProfileDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string ProfileAddress { get; set; }
    }
}
