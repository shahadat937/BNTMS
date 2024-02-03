using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.IndividualBulletins.Requests.Commands;
using SchoolManagement.Application.DTOs.IndividualBulletins.Validators;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.IndividualBulletins.Handlers.Commands
{
    public class UpdateIndividualBulletinCommandHandler : IRequestHandler<UpdateIndividualBulletinCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateIndividualBulletinCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateIndividualBulletinCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateIndividualBulletinDtoValidator();
            var validationResult = await validator.ValidateAsync(request.IndividualBulletinDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var IndividualBulletin = await _unitOfWork.Repository<IndividualBulletin>().Get(request.IndividualBulletinDto.IndividualBulletinId);

            if (IndividualBulletin is null)
                throw new NotFoundException(nameof(IndividualBulletin), request.IndividualBulletinDto.IndividualBulletinId);

            _mapper.Map(request.IndividualBulletinDto, IndividualBulletin);

            await _unitOfWork.Repository<IndividualBulletin>().Update(IndividualBulletin);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
