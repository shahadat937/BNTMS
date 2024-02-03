using AutoMapper;
using SchoolManagement.Application.DTOs.ParentRelative;
using SchoolManagement.Application.Features.ParentRelatives.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace SchoolManagement.Application.Features.ParentRelatives.Handlers.Queries
{
    //public class GetParentRelativeListByTraineeRequestHandler : IRequestHandler<GetParentRelativeListByTraineeRequest, Unit>


    public class GetParentRelativeListByTraineeRequestHandler : IRequestHandler<GetParentRelativeListByTraineeRequest, List<ParentRelativeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ParentRelative> _ParentRelativeRepository;
        public GetParentRelativeListByTraineeRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ParentRelative> ParentRelativeRepository, IMapper mapper)
        {
            _ParentRelativeRepository = ParentRelativeRepository;
            _mapper = mapper;
        }
        public async Task<List<ParentRelativeDto>> Handle(GetParentRelativeListByTraineeRequest request, CancellationToken cancellationToken)
        {
            var ParentRelative = _ParentRelativeRepository.FilterWithInclude(x =>(x.TraineeId == request.Traineeid), "RelationType", "MaritalStatus", "Nationality", "Religion", "Caste", "Occupation", "PreviousOccupation", "Division", "District", "Thana", "DefenseType", "Rank", "SecondNationality", "DeadStatusNavigation");

            return _mapper.Map<List<ParentRelativeDto>>(ParentRelative);

        }
    }
}
