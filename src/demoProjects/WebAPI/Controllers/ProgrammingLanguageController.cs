using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.UpdatedProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            CreatedProgrammingLanguageDto result = await Mediator.Send(createProgrammingLanguageCommand);
            return Created("", result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new() { PageRequest = pageRequest };
            ProgrammingLanguageListModel programmingLanguageListModel = await Mediator.Send(getListProgrammingLanguageQuery);
            return Ok(programmingLanguageListModel);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetListById([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery)
        {
            GetByIdProgrammingLanguageDto getByIdProgrammingLanguageDto = await Mediator.Send(getByIdProgrammingLanguageQuery);
            return Ok(getByIdProgrammingLanguageDto);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatedProgrammingLanguageModel updatedProgrammingLanguageCommand)
        {
            UpdatedProgrammingLanguageCommand setModel = new() { UpdatedProgrammingLanguageModel = updatedProgrammingLanguageCommand };
            UpdatedProgrammingLanguageDto result = await Mediator.Send(setModel);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            DeletedProgrammingLanguageDto result = await Mediator.Send(deleteProgrammingLanguageCommand);
            return Ok(result);
        }
    }
}
