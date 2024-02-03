using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeSectionSelection.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeSectionSelections.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeSectionSelections.Handlers.Commands
{
    public class UpdateTraineeSectionSelectionCommandHandler : IRequestHandler<UpdateTraineeSectionSelectionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTraineeSectionSelectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTraineeSectionSelectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTraineeSectionSelectionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TraineeSectionSelectionDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var TraineeSectionSelections = await _unitOfWork.Repository<TraineeSectionSelection>().Get(request.TraineeSectionSelectionDto.TraineeSectionSelectionId);

            if (TraineeSectionSelections is null)
                throw new NotFoundException(nameof(TraineeSectionSelection), request.TraineeSectionSelectionDto.TraineeSectionSelectionId);

            _mapper.Map(request.TraineeSectionSelectionDto, TraineeSectionSelections);

            await _unitOfWork.Repository<TraineeSectionSelection>().Update(TraineeSectionSelections);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
