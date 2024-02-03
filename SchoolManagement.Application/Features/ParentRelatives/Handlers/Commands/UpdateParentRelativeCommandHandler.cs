using AutoMapper;
using SchoolManagement.Application.DTOs.ParentRelative.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ParentRelatives.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ParentRelatives.Handlers.Commands
{
    public class UpdateParentRelativeCommandHandler : IRequestHandler<UpdateParentRelativeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateParentRelativeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateParentRelativeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateParentRelativeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ParentRelativeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ParentRelative = await _unitOfWork.Repository<ParentRelative>().Get(request.ParentRelativeDto.ParentRelativeId);

            if (ParentRelative is null)
                throw new NotFoundException(nameof(ParentRelative), request.ParentRelativeDto.ParentRelativeId);

            _mapper.Map(request.ParentRelativeDto, ParentRelative);

            await _unitOfWork.Repository<ParentRelative>().Update(ParentRelative);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
