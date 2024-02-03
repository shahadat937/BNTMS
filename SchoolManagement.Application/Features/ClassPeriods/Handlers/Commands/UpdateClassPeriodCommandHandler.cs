using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ClassPeriod.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassPeriods.Handlers.Commands
{
    public class UpdateClassPeriodCommandHandler : IRequestHandler<UpdateClassPeriodCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateClassPeriodCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateClassPeriodCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateClassPeriodDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ClassPeriodDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ClassPeriod = await _unitOfWork.Repository<ClassPeriod>().Get(request.ClassPeriodDto.ClassPeriodId);

            if (ClassPeriod is null)
                throw new NotFoundException(nameof(ClassPeriod), request.ClassPeriodDto.ClassPeriodId);

            _mapper.Map(request.ClassPeriodDto, ClassPeriod);

            await _unitOfWork.Repository<ClassPeriod>().Update(ClassPeriod);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
