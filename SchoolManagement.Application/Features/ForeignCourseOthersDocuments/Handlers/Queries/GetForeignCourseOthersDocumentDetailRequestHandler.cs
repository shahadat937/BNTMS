using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ForeignCourseOthersDocument;
using SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Handlers.Queries
{
    public class GetForeignCourseOthersDocumentDetailRequestHandler : IRequestHandler<GetForeignCourseOthersDocumentDetailRequest, ForeignCourseOthersDocumentDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ForeignCourseOthersDocument> _ForeignCourseOthersDocumentRepository;
        public GetForeignCourseOthersDocumentDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ForeignCourseOthersDocument> ForeignCourseOthersDocumentRepository, IMapper mapper)
        {
            _ForeignCourseOthersDocumentRepository = ForeignCourseOthersDocumentRepository;
            _mapper = mapper;
        }
        public async Task<ForeignCourseOthersDocumentDto> Handle(GetForeignCourseOthersDocumentDetailRequest request, CancellationToken cancellationToken)
        {
            var ForeignCourseOthersDocument = await _ForeignCourseOthersDocumentRepository.Get(request.ForeignCourseOthersDocumentId);
            return _mapper.Map<ForeignCourseOthersDocumentDto>(ForeignCourseOthersDocument);
        }
    }
}
