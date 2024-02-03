using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.SubjectClassifications.Requests.Commands;

namespace SchoolManagement.Application.Features.SubjectClassifications.Handlers.Commands
{
    public class DeleteSubjectClassificationCommandHandler : IRequestHandler<DeleteSubjectClassificationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSubjectClassificationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSubjectClassificationCommand request, CancellationToken cancellationToken)
        {
            var SubjectClassification = await _unitOfWork.Repository<SubjectClassification>().Get(request.SubjectClassificationId);

            if (SubjectClassification == null)
                throw new NotFoundException(nameof(SubjectClassification), request.SubjectClassificationId);

            await _unitOfWork.Repository<SubjectClassification>().Delete(SubjectClassification);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
