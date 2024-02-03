using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.QuestionType;
using SchoolManagement.Application.Features.QuestionTypes.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.QuestionTypes.Handlers.Queries
{
    public class GetQuestionTypeDetailRequestHandler : IRequestHandler<GetQuestionTypeDetailRequest, QuestionTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.QuestionType> _QuestionTypeRepository;
        public GetQuestionTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.QuestionType> QuestionTypeRepository, IMapper mapper)
        {
            _QuestionTypeRepository = QuestionTypeRepository;
            _mapper = mapper;
        }
        public async Task<QuestionTypeDto> Handle(GetQuestionTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var QuestionType = await _QuestionTypeRepository.Get(request.QuestionTypeId);
            return _mapper.Map<QuestionTypeDto>(QuestionType);
        }
    }
}
