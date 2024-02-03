using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.SubjectTypes.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SubjectTypes.Handlers.Commands
{
    public class DeleteSubjectTypeCommandHandler : IRequestHandler<DeleteSubjectTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSubjectTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSubjectTypeCommand request, CancellationToken cancellationToken)
        {
            var SubjectType = await _unitOfWork.Repository<SubjectType>().Get(request.SubjectTypeId);

            if (SubjectType == null)
                throw new NotFoundException(nameof(SubjectType), request.SubjectTypeId);

            await _unitOfWork.Repository<SubjectType>().Delete(SubjectType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
