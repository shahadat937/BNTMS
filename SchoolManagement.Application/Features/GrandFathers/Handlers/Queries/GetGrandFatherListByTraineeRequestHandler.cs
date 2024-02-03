using AutoMapper;
using SchoolManagement.Application.DTOs.GrandFather;
using SchoolManagement.Application.Features.GrandFathers.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GrandFathers.Handlers.Queries
{
    //public class GetGrandFatherListByTraineeRequestHandler : IRequestHandler<GetGrandFatherListByTraineeRequest, Unit>


    public class GetGrandFatherListByTraineeRequestHandler : IRequestHandler<GetGrandFatherListByTraineeRequest, List<GrandFatherDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.GrandFather> _GrandFatherRepository;
        public GetGrandFatherListByTraineeRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.GrandFather> GrandFatherRepository, IMapper mapper)
        {
            _GrandFatherRepository = GrandFatherRepository;
            _mapper = mapper;
        }
        public async Task<List<GrandFatherDto>> Handle(GetGrandFatherListByTraineeRequest request, CancellationToken cancellationToken)
        {
            var GrandFather = _GrandFatherRepository.FilterWithInclude(x =>(x.TraineeId == request.Traineeid), "GrandFatherType", "Occupation", "Nationality", "DeadStatusNavigation");
            return _mapper.Map<List<GrandFatherDto>>(GrandFather);
        }
    }
}
