using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MilitaryTraining;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.MilitaryTrainings.Requests.Queries;
using SchoolManagement.Application.DTOs.CodeValues;

namespace SchoolManagement.Application.Features.MilitaryTrainings.Handlers.Queries
{  
    public class GetMilitaryTrainingDetailRequestHandler : IRequestHandler<GetMilitaryTrainingDetailRequest, MilitaryTrainingDto>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<MilitaryTraining> _MilitaryTrainingRepository;       
        public GetMilitaryTrainingDetailRequestHandler(ISchoolManagementRepository<MilitaryTraining> MilitaryTrainingRepository, IMapper mapper)
        {
            _MilitaryTrainingRepository = MilitaryTrainingRepository;    
            _mapper = mapper; 
        } 
        public async Task<MilitaryTrainingDto> Handle(GetMilitaryTrainingDetailRequest request, CancellationToken cancellationToken)
        {
            var MilitaryTraining = await _MilitaryTrainingRepository.FindOneAsync(x => x.MilitaryTrainingId == request.Id);    
            return _mapper.Map<MilitaryTrainingDto>(MilitaryTraining);    
        }
    }
}
