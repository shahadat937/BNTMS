using AutoMapper;
using SchoolManagement.Application.DTOs.Question;
using SchoolManagement.Application.Features.Questions.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Questions.Handlers.Queries
{
    public class GetQuestionDetailRequestHandler : IRequestHandler<GetQuestionDetailRequest, QuestionDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Question> _QuestionRepository;
        public GetQuestionDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Question> QuestionRepository, IMapper mapper)
        {
            _QuestionRepository = QuestionRepository;
            _mapper = mapper;
        }
        public async Task<QuestionDto> Handle(GetQuestionDetailRequest request, CancellationToken cancellationToken)
        {
            var Question = await _QuestionRepository.FindOneAsync(x => x.QuestionId == request.QuestionId, "QuestionType");
            return _mapper.Map<QuestionDto>(Question);
        }
    }
}
