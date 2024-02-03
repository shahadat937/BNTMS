using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.IndividualNotices.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.IndividualNotices.Handlers.Commands
{
    public class StopIndividualNoticeCommandHandler : IRequestHandler<StopIndividualNoticeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StopIndividualNoticeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(StopIndividualNoticeCommand request, CancellationToken cancellationToken)
        {
            var IndividualNotice = await _unitOfWork.Repository<IndividualNotice>().Get(request.IndividualNoticeId);
            IndividualNotice.Status = 1;

            if (IndividualNotice == null)
                throw new NotFoundException(nameof(IndividualNotice), request.IndividualNoticeId);

            await _unitOfWork.Repository<IndividualNotice>().Update(IndividualNotice);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
