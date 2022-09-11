using Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnologyCommand;
using Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnologyCommand;
using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Models;
using Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechologies;
using Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnologies;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageTechnologyController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageTechnologyQuery query = new() { PageRequest = pageRequest};
            ProgrammingLanguageTechnologyListModel result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("GetList/ByDynamic")]
        public async Task<IActionResult> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListDynamicProgrammingLanguageTechnologyQuery query = new() { PageRequest = pageRequest, Dynamic = dynamic };
            ProgrammingLanguageTechnologyListModel result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageTechnologyQuery getByIdProgrammingLanguageTechnologyQuery)
        {
            GetByIdProgrammingLanguageTechnologyDto result = await Mediator.Send(getByIdProgrammingLanguageTechnologyQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromQuery] CreateProgrammingLanguageTechnologyModel createProgrammingLanguageTechnologyModel)
        {
            CreateProgrammingLanguageTechnologyCommand technologyQuery = new() { CreateProgrammingLanguageTechnologyModel = createProgrammingLanguageTechnologyModel };
            CreateProgrammingLanguageTechnologyDto result = await Mediator.Send(technologyQuery);
            return Ok(result);
        }
        [HttpPut]
        public  async Task<ActionResult> UpdateAsync([FromQuery]UpdateProgrammingLanguageTechnologyModel updateProgrammingLanguageTechnologyModel)
        {
            UpdateProgrammingLanguageTechnologyCommand updateProgrammingLanguageTechnologyCommand = new() { UpdateProgrammingLanguageTechnologyModel = updateProgrammingLanguageTechnologyModel };
            UpdateProgrammingLanguageTechnologyDto result = await Mediator.Send(updateProgrammingLanguageTechnologyCommand);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingLanguageTechnologyCommand deleteProgrammingLanguageTechnologyCommand)
        {
            DeleteProgrammingLanguageTechnologyDto result = await Mediator.Send(deleteProgrammingLanguageTechnologyCommand);
            return Ok(result);
        }
    }
}
