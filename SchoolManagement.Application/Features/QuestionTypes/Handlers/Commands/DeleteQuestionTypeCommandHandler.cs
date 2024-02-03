using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.QuestionTypes.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.QuestionTypes.Handlers.Commands
{
    public class DeleteQuestionTypeCommandHandler : IRequestHandler<DeleteQuestionTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteQuestionTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteQuestionTypeCommand request, CancellationToken cancellationToken)
        {
            var QuestionType = await _unitOfWork.Repository<QuestionType>().Get(request.QuestionTypeId);

            if (QuestionType == null)
                throw new NotFoundException(nameof(QuestionType), request.QuestionTypeId);

            await _unitOfWork.Repository<QuestionType>().Delete(QuestionType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
