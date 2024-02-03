using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TrainingSyllabus;
using SchoolManagement.Application.Features.TrainingSyllabuss.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TrainingSyllabuss.Handlers.Queries
{
    public class GetTrainingSyllabusDetailRequestHandler : IRequestHandler<GetTrainingSyllabusDetailRequest, TrainingSyllabusDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TrainingSyllabus> _TrainingSyllabusRepository;
        public GetTrainingSyllabusDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TrainingSyllabus> TrainingSyllabusRepository, IMapper mapper)
        {
            _TrainingSyllabusRepository = TrainingSyllabusRepository;
            _mapper = mapper;
        }
        public async Task<TrainingSyllabusDto> Handle(GetTrainingSyllabusDetailRequest request, CancellationToken cancellationToken)
        {
            var TrainingSyllabus = _TrainingSyllabusRepository.FinedOneInclude(x=>x.TrainingSyllabusId == request.TrainingSyllabusId, "CourseName");
            return _mapper.Map<TrainingSyllabusDto>(TrainingSyllabus);
        }
    }
}
