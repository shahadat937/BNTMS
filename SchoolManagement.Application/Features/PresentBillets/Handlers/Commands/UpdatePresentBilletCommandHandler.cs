using AutoMapper;
using SchoolManagement.Application.DTOs.PresentBillet.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.PresentBillets.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.PresentBillets.Handlers.Commands
{
    public class UpdatePresentBilletCommandHandler : IRequestHandler<UpdatePresentBilletCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePresentBilletCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePresentBilletCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePresentBilletDtoValidator();
            var validationResult = await validator.ValidateAsync(request.PresentBilletDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var PresentBillet = await _unitOfWork.Repository<PresentBillet>().Get(request.PresentBilletDto.PresentBilletId);

            if (PresentBillet is null)
                throw new NotFoundException(nameof(PresentBillet), request.PresentBilletDto.PresentBilletId);

            _mapper.Map(request.PresentBilletDto, PresentBillet);

            await _unitOfWork.Repository<PresentBillet>().Update(PresentBillet);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
