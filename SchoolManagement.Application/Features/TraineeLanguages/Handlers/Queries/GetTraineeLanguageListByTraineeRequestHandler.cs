using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeLanguages;
using SchoolManagement.Application.Features.TraineeLanguages.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TraineeLanguages.Handlers.Queries
{

    public class GetTraineeLanguageListByTraineeRequestHandler : IRequestHandler<GetTraineeLanguageListByTraineeRequest, List<TraineeLanguageDto>>
    {
        private readonly IMapper _mapper; 
        private readonly ISchoolManagementRepository<TraineeLanguage> _TraineeLanguageRepository;
        public GetTraineeLanguageListByTraineeRequestHandler(ISchoolManagementRepository<TraineeLanguage> TraineeLanguageRepository, IMapper mapper)
        {
            _TraineeLanguageRepository = TraineeLanguageRepository;
            _mapper = mapper;
        }
        public async Task<List<TraineeLanguageDto>> Handle(GetTraineeLanguageListByTraineeRequest request, CancellationToken cancellationToken)
        {
            var TraineeLanguage = _TraineeLanguageRepository.FilterWithInclude(x =>x.TraineeId == request.Traineeid, "Language");
            return _mapper.Map<List<TraineeLanguageDto>>(TraineeLanguage);
        }
    }
}
