using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeBioDataOther;
using SchoolManagement.Application.Features.TraineeBioDataOthers.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeBioDataOthers.Handlers.Queries
{
    public class GetTraineeBioDataOtherDetailRequestHandler : IRequestHandler<GetTraineeBioDataOtherDetailRequest, TraineeBioDataOtherDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeBioDataOther> _TraineeBioDataOtherRepository;
        public GetTraineeBioDataOtherDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeBioDataOther> TraineeBioDataOtherRepository, IMapper mapper)
        {
            _TraineeBioDataOtherRepository = TraineeBioDataOtherRepository;
            _mapper = mapper;
        }
        

        public async Task<TraineeBioDataOtherDto> Handle(GetTraineeBioDataOtherDetailRequest request, CancellationToken cancellationToken)
        {

            var TraineeBioDataOther = await _TraineeBioDataOtherRepository.FindOneAsync(x => x.TraineeBioDataOtherId == request.TraineeBioDataOtherId, "BloodGroup", "BnaClassSectionSelection", "BnaCurriculumType",
                                        "BnaInstructorType", "BnaPromotionStatus", "BnaSemester", "BnaServiceType", "Branch", "Caste", "ColorOfEye", "Complexion", "CourseName", "Country", "FailureStatus", "Height", "MaritalStatus", "PresentBillet", "Religion",
                                         "UtofficerCategory", "UtofficerType", "Weight");


            return _mapper.Map<TraineeBioDataOtherDto>(TraineeBioDataOther);
        }

        
    }
}
