using AutoMapper;
using SchoolManagement.Application.DTOs.BnaCurriculumUpdate.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaCurriculumUpdates.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaCurriculumUpdates.Handlers.Commands
{
    public class UpdateBnaCurriculumUpdateCommandHandler : IRequestHandler<UpdateBnaCurriculumUpdateCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBnaCurriculumUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBnaCurriculumUpdateCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBnaCurriculumUpdateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaCurriculumUpdateDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BnaCurriculumUpdates = await _unitOfWork.Repository<BnaCurriculumUpdate>().Get(request.BnaCurriculumUpdateDto.BnaCurriculumUpdateId);

            if (BnaCurriculumUpdates is null)
                throw new NotFoundException(nameof(BnaCurriculumUpdate), request.BnaCurriculumUpdateDto.BnaCurriculumUpdateId);

            _mapper.Map(request.BnaCurriculumUpdateDto, BnaCurriculumUpdates);

            await _unitOfWork.Repository<BnaCurriculumUpdate>().Update(BnaCurriculumUpdates);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
