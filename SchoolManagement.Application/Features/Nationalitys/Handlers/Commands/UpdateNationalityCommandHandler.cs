using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.Nationality.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Nationalitys.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Nationalitys.Handlers.Commands
{
    public class UpdateNationalityCommandHandler : IRequestHandler<UpdateNationalityCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateNationalityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateNationalityCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateNationalityDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.NationalityDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Nationality = await _unitOfWork.Repository<Nationality>().Get(request.NationalityDto.NationalityId);

            if (Nationality is null)
                throw new NotFoundException(nameof(Nationality), request.NationalityDto.NationalityId);

            _mapper.Map(request.NationalityDto, Nationality);

            await _unitOfWork.Repository<Nationality>().Update(Nationality);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
