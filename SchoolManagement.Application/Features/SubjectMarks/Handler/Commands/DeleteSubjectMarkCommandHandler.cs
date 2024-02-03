using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.SubjectMarks.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.SubjectMarks.Handler.Queries
{
    public class DeleteSubjectMarkCommandHandler : IRequestHandler<DeleteSubjectMarkCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSubjectMarkCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSubjectMarkCommand request, CancellationToken cancellationToken)
        {
            var SubjectMark = await _unitOfWork.Repository<SubjectMark>().Get(request.Id);

            if (SubjectMark == null)
                throw new NotFoundException(nameof(SubjectMark), request.Id);

            await _unitOfWork.Repository<SubjectMark>().Delete(SubjectMark);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}