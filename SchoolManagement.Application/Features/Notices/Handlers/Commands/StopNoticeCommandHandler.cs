using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Notices.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Notices.Handlers.Commands
{
    public class StopNoticeCommandHandler : IRequestHandler<StopNoticeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StopNoticeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(StopNoticeCommand request, CancellationToken cancellationToken)
        {
            var Notice = await _unitOfWork.Repository<Notice>().Get(request.NoticeId);
            Notice.Status = 1;

            if (Notice == null)
                throw new NotFoundException(nameof(Notice), request.NoticeId);

            await _unitOfWork.Repository<Notice>().Update(Notice);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
