using AutoMapper;
using SchoolManagement.Application.DTOs.Question;
using SchoolManagement.Application.Features.Questions.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Questions.Handlers.Queries
{
    public class GetQuestionListByTraineeRequestHandler : IRequestHandler<GetQuestionListByTraineeRequest, List<QuestionDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Question> _QuestionRepository;
        public GetQuestionListByTraineeRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Question> QuestionRepository, IMapper mapper)
        {
            _QuestionRepository = QuestionRepository;
            _mapper = mapper;
        }
        public async Task<List<QuestionDto>> Handle(GetQuestionListByTraineeRequest request, CancellationToken cancellationToken)
        {
            var Question = _QuestionRepository.FilterWithInclude(x => (x.TraineeId == request.Traineeid), "QuestionType");
            return _mapper.Map<List<QuestionDto>>(Question);
        }
    }
    
}
