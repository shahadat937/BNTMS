using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaCurriculumUpdates.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaCurriculumUpdates.Handlers.Commands
{
    public class DeleteBnaCurriculumUpdateCommandHandler : IRequestHandler<DeleteBnaCurriculumUpdateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBnaCurriculumUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBnaCurriculumUpdateCommand request, CancellationToken cancellationToken)
        {
            var BnaCurriculumUpdates = await _unitOfWork.Repository<BnaCurriculumUpdate>().Get(request.BnaCurriculumUpdateId);

            if (BnaCurriculumUpdates == null)
                throw new NotFoundException(nameof(BnaCurriculumUpdate), request.BnaCurriculumUpdateId);

            await _unitOfWork.Repository<BnaCurriculumUpdate>().Delete(BnaCurriculumUpdates);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
