using AutoMapper;
using SchoolManagement.Application.DTOs.EmploymentBeforeJoinBna.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.EmploymentBeforeJoinBnas.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.EmploymentBeforeJoinBnas.Handlers.Commands
{
    public class UpdateEmploymentBeforeJoinBnaCommandHandler : IRequestHandler<UpdateEmploymentBeforeJoinBnaCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEmploymentBeforeJoinBnaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEmploymentBeforeJoinBnaCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateEmploymentBeforeJoinBnaDtoValidator();
            var validationResult = await validator.ValidateAsync(request.EmploymentBeforeJoinBnaDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var EmploymentBeforeJoinBnas = await _unitOfWork.Repository<EmploymentBeforeJoinBna>().Get(request.EmploymentBeforeJoinBnaDto.EmploymentBeforeJoinBnaId);

            if (EmploymentBeforeJoinBnas is null)
                throw new NotFoundException(nameof(EmploymentBeforeJoinBna), request.EmploymentBeforeJoinBnaDto.EmploymentBeforeJoinBnaId);

            _mapper.Map(request.EmploymentBeforeJoinBnaDto, EmploymentBeforeJoinBnas);

            await _unitOfWork.Repository<EmploymentBeforeJoinBna>().Update(EmploymentBeforeJoinBnas);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
