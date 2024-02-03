using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TraineeBioDataOther;
using SchoolManagement.Application.Features.TraineeBioDataOthers.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeBioDataOthers.Handlers.Queries
{
    public class GetTraineeBioDataOtherListByTraineeRequestHandler : IRequestHandler<GetTraineeBioDataOtherListByTraineeRequest, List<TraineeBioDataOtherDto>>

    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeBioDataOther> _TraineeBioDataOtherRepository;
        public GetTraineeBioDataOtherListByTraineeRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeBioDataOther> TraineeBioDataOtherRepository, IMapper mapper)
        {
            _TraineeBioDataOtherRepository = TraineeBioDataOtherRepository;
            _mapper = mapper;
        }
        public async Task<List<TraineeBioDataOtherDto>> Handle(GetTraineeBioDataOtherListByTraineeRequest request, CancellationToken cancellationToken)
        {
            var TraineeBioDataOther = _TraineeBioDataOtherRepository.FilterWithInclude(x => x.TraineeId == request.TraineeId);
            return _mapper.Map<List<TraineeBioDataOtherDto>>(TraineeBioDataOther);
        }
    }

}
