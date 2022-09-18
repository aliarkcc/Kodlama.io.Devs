using Application.Features.GithubProfiles.Commands.CreateGithubProfileCommands;
using Application.Features.GithubProfiles.Commands.DeleteGithubProfileCommands;
using Application.Features.GithubProfiles.Commands.UpdateGithubProfileCommands;
using Application.Features.GithubProfiles.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GithubProfileController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] CreateGitubProfileCommand createGitubProfileCommand)
        {
            CreateGithubProfileDto createGithubProfileDto = await Mediator.Send(createGitubProfileCommand);
            return Ok(createGithubProfileDto);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGithubProfileCommand updateGithubProfileCommand)
        {
            UpdateGithubProfileCommand updateGithubProfile = new() { Id = updateGithubProfileCommand.Id , ProfileName=updateGithubProfileCommand.ProfileName };
            UpdatedGithubProfileDto result = await Mediator.Send(updateGithubProfile);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            DeleteGithubProfileCommand deleteGithubProfile = new() { Id = id };
            DeletedGithubProfileDto result = await Mediator.Send(deleteGithubProfile);
            return Ok(result);
        }
    }
}
