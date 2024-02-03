using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ParentRelative;
using SchoolManagement.Application.Features.ParentRelatives.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ParentRelatives.Handlers.Queries
{
    public class GetParentRelativeListTypeRequestHandler : IRequestHandler<GetParentRelativeListTypeRequest, List<ParentRelativeDto>>
    {
        private readonly ISchoolManagementRepository<ParentRelative> _ParentRelativeRepository;
        private readonly IMapper _mapper;

        public GetParentRelativeListTypeRequestHandler(ISchoolManagementRepository<ParentRelative> ParentRelativeRepository, IMapper mapper)
        {
            _ParentRelativeRepository = ParentRelativeRepository;
            _mapper = mapper;
        }

        public async Task<List<ParentRelativeDto>> Handle(GetParentRelativeListTypeRequest request, CancellationToken cancellationToken)
        {
            if(request.GroupType == 11) //for children
            {
                IQueryable<ParentRelative> ParentRelatives = _ParentRelativeRepository.FilterWithInclude(x => x.TraineeId == request.TraineeId && (x.RelationTypeId == 23 || x.RelationTypeId == 24), "Gender");

                var ParentRelativeDtos = _mapper.Map<List<ParentRelativeDto>>(ParentRelatives);
                return ParentRelativeDtos;
            }
            else if (request.GroupType == 22) //for brother/sister
            {
                IQueryable<ParentRelative> ParentRelatives = _ParentRelativeRepository.FilterWithInclude(x => x.TraineeId == request.TraineeId && (x.RelationTypeId == 2 || x.RelationTypeId == 7), "Occupation");

                var ParentRelativeDtos = _mapper.Map<List<ParentRelativeDto>>(ParentRelatives);
                return ParentRelativeDtos;
            }
            else
            {
                IQueryable<ParentRelative> ParentRelatives = _ParentRelativeRepository.FilterWithInclude(x => x.IsActive == true);

                var ParentRelativeDtos = _mapper.Map<List<ParentRelativeDto>>(ParentRelatives);
                return ParentRelativeDtos;
            }
            
        }
    }
}
