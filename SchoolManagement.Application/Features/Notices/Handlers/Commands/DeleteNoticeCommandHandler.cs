using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Features.Notices.Requests.Commands;

namespace SchoolManagement.Application.Features.Notices.Handlers.Commands
{
    public class DeleteNoticeCommandHandler : IRequestHandler<DeleteNoticeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteNoticeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
         
        public async Task<Unit> Handle(DeleteNoticeCommand request, CancellationToken cancellationToken)
        {
            var Notice = await _unitOfWork.Repository<Notice>().Get(request.NoticeId);

            if (Notice == null)
                throw new NotFoundException(nameof(Notice), request.NoticeId);

            await _unitOfWork.Repository<Notice>().Delete(Notice);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
