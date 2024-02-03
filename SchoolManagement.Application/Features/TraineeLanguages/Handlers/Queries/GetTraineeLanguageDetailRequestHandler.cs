using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.TraineeLanguages;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Features.Branchs.Requests.Queries;
using SchoolManagement.Application.Features.Complexions.Requests.Queries;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.TraineeLanguages.Requests.Queries;

namespace SchoolManagement.Application.Features.TraineeLanguages.Handlers.Queries
{  
    public class GetTraineeLanguagesDetailRequestHandler : IRequestHandler<GetTraineeLanguageDetailRequest, TraineeLanguageDto>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<TraineeLanguage> _TraineeLanguageRepository;       
        public GetTraineeLanguagesDetailRequestHandler(ISchoolManagementRepository<TraineeLanguage> TraineeLanguageRepository, IMapper mapper)
        {
            _TraineeLanguageRepository = TraineeLanguageRepository;    
            _mapper = mapper; 
        } 
        public async Task<TraineeLanguageDto> Handle(GetTraineeLanguageDetailRequest request, CancellationToken cancellationToken)
        {
            var TraineeLanguage = await _TraineeLanguageRepository.FindOneAsync(x => x.TraineeLanguageId == request.Id, "Language");    
            return _mapper.Map<TraineeLanguageDto>(TraineeLanguage);    
        }
    }
}
