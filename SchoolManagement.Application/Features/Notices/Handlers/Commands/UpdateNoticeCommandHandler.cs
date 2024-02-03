using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.Notice.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Notices.Requests.Commands;

namespace SchoolManagement.Application.Features.Notices.Handlers.Commands
{
    public class UpdateNoticeCommandHandler : IRequestHandler<UpdateNoticeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateNoticeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateNoticeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateNoticeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.NoticeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Notice = await _unitOfWork.Repository<Notice>().Get(request.NoticeDto.NoticeId);

            if (Notice is null)
                throw new NotFoundException(nameof(Notice), request.NoticeDto.NoticeId);

            _mapper.Map(request.NoticeDto, Notice);

            await _unitOfWork.Repository<Notice>().Update(Notice);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
