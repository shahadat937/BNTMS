using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Features.IndividualNotices.Requests.Commands;

namespace SchoolManagement.Application.Features.IndividualNotices.Handlers.Commands
{
    public class DeleteIndividualNoticeCommandHandler : IRequestHandler<DeleteIndividualNoticeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteIndividualNoticeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
         
        public async Task<Unit> Handle(DeleteIndividualNoticeCommand request, CancellationToken cancellationToken)
        {
            var IndividualNotice = await _unitOfWork.Repository<IndividualNotice>().Get(request.IndividualNoticeId);

            if (IndividualNotice == null)
                throw new NotFoundException(nameof(IndividualNotice), request.IndividualNoticeId);

            await _unitOfWork.Repository<IndividualNotice>().Delete(IndividualNotice);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
