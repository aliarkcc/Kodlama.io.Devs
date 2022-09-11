using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguageTechnologies.Models
{
    public class ProgrammingLanguageTechnologyListModel : BasePageableModel
    {
        public IList<ProgrammingLanguageTechnologyListDto> Items { get; set; }
    }
}
