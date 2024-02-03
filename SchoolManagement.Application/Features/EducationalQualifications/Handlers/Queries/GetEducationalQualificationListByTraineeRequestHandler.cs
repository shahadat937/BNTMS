using AutoMapper;
using SchoolManagement.Application.DTOs.EducationalQualification;
using SchoolManagement.Application.Features.EducationalQualifications.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.EducationalQualifications.Handlers.Queries
{
    //public class GetEducationalQualificationListByTraineeRequestHandler : IRequestHandler<GetEducationalQualificationListByTraineeRequest, Unit>


    public class GetEducationalQualificationListByTraineeRequestHandler : IRequestHandler<GetEducationalQualificationListByTraineeRequest, List<EducationalQualificationDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.EducationalQualification> _EducationalQualificationRepository;
        public GetEducationalQualificationListByTraineeRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.EducationalQualification> EducationalQualificationRepository, IMapper mapper)
        {
            _EducationalQualificationRepository = EducationalQualificationRepository;
            _mapper = mapper;
        }
        public async Task<List<EducationalQualificationDto>> Handle(GetEducationalQualificationListByTraineeRequest request, CancellationToken cancellationToken)
        {
            var EducationalQualification = _EducationalQualificationRepository.FilterWithInclude(x =>(x.TraineeId == request.Traineeid), "ExamType", "Board", "Group");
            return _mapper.Map<List<EducationalQualificationDto>>(EducationalQualification);
        }
    }
}
