using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaSubjectCurriculums.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaSubjectCurriculums.Handlers.Commands
{
    public class DeleteBnaSubjectCurriculumCommandHandler : IRequestHandler<DeleteBnaSubjectCurriculumCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBnaSubjectCurriculumCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        { 
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBnaSubjectCurriculumCommand request, CancellationToken cancellationToken)
        {
            var BnaSubjectCurriculum = await _unitOfWork.Repository<BnaSubjectCurriculum>().Get(request.BnaSubjectCurriculumId);

            if (BnaSubjectCurriculum == null)
                throw new NotFoundException(nameof(BnaSubjectCurriculum), request.BnaSubjectCurriculumId);

            await _unitOfWork.Repository<BnaSubjectCurriculum>().Delete(BnaSubjectCurriculum);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
