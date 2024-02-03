using AutoMapper;
using SchoolManagement.Application.DTOs.RoutineSoftCopyUpload;
using SchoolManagement.Application.Features.RoutineSoftCopyUploads.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.RoutineSoftCopyUploads.Handlers.Queries
{
    public class GetRoutineSoftCopyUploadDetailRequestHandler : IRequestHandler<GetRoutineSoftCopyUploadDetailRequest, RoutineSoftCopyUploadDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.RoutineSoftCopyUpload> _RoutineSoftCopyUploadRepository;
        public GetRoutineSoftCopyUploadDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.RoutineSoftCopyUpload> RoutineSoftCopyUploadRepository, IMapper mapper)
        {
            _RoutineSoftCopyUploadRepository = RoutineSoftCopyUploadRepository;
            _mapper = mapper;
        }
        public async Task<RoutineSoftCopyUploadDto> Handle(GetRoutineSoftCopyUploadDetailRequest request, CancellationToken cancellationToken)
        {
            //var RoutineSoftCopyUpload = await _RoutineSoftCopyUploadRepository.FindOneAsync(x => x.RoutineSoftCopyUploadId == request.RoutineSoftCopyUploadId);
            var RoutineSoftCopyUpload = _RoutineSoftCopyUploadRepository.FinedOneInclude(x => x.RoutineSoftCopyUploadId == request.RoutineSoftCopyUploadId, "CourseDuration", "CourseDuration.CourseName");
            return _mapper.Map<RoutineSoftCopyUploadDto>(RoutineSoftCopyUpload);
        }
    }
} 
