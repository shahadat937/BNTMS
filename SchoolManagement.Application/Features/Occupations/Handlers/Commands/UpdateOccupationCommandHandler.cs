using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.Occupation.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Occupations.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Occupations.Handlers.Commands
{
    public class UpdateOccupationCommandHandler : IRequestHandler<UpdateOccupationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOccupationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOccupationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOccupationDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.OccupationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Occupation = await _unitOfWork.Repository<Occupation>().Get(request.OccupationDto.OccupationId);

            if (Occupation is null)
                throw new NotFoundException(nameof(Occupation), request.OccupationDto.OccupationId);

            _mapper.Map(request.OccupationDto, Occupation);

            await _unitOfWork.Repository<Occupation>().Update(Occupation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
