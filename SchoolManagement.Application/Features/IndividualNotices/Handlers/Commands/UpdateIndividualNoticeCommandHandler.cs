using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.IndividualNotices.Requests.Commands;
using SchoolManagement.Application.DTOs.IndividualNotices.Validators;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.IndividualNotices.Handlers.Commands
{
    public class UpdateIndividualNoticeCommandHandler : IRequestHandler<UpdateIndividualNoticeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateIndividualNoticeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateIndividualNoticeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateIndividualNoticeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.IndividualNoticeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var IndividualNotice = await _unitOfWork.Repository<IndividualNotice>().Get(request.IndividualNoticeDto.IndividualNoticeId);

            if (IndividualNotice is null)
                throw new NotFoundException(nameof(IndividualNotice), request.IndividualNoticeDto.IndividualNoticeId);

            _mapper.Map(request.IndividualNoticeDto, IndividualNotice);

            await _unitOfWork.Repository<IndividualNotice>().Update(IndividualNotice);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
