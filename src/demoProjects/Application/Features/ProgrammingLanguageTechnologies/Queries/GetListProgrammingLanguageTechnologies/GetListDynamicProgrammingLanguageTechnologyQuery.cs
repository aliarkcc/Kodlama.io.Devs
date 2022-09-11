using Application.Features.ProgrammingLanguageTechnologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnologies
{
    public class GetListDynamicProgrammingLanguageTechnologyQuery:IRequest<ProgrammingLanguageTechnologyListModel>
    {
        public Dynamic  Dynamic{ get; set; }
        public PageRequest PageRequest{ get; set; }

        public class GetListProgrammingLanguageTechnologyQueryHandler : IRequestHandler<GetListDynamicProgrammingLanguageTechnologyQuery, ProgrammingLanguageTechnologyListModel>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;

            public GetListProgrammingLanguageTechnologyQueryHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingLanguageTechnologyListModel> Handle(GetListDynamicProgrammingLanguageTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguageTechnology> programmingLanguageTechnologies= await _programmingLanguageTechnologyRepository.GetListByDynamicAsync(dynamic: request.Dynamic,include:x=>x.Include(y=>y.ProgrammingLanguage), index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                ProgrammingLanguageTechnologyListModel programmingLanguageTechnologyListModel = _mapper.Map<ProgrammingLanguageTechnologyListModel>(programmingLanguageTechnologies);
                return programmingLanguageTechnologyListModel;
            }
        }
    }
}
