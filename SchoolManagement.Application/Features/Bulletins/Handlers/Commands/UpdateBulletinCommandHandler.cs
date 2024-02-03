using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.Bulletin.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Bulletins.Requests.Commands;

namespace SchoolManagement.Application.Features.Bulletins.Handlers.Commands
{
    public class UpdateBulletinCommandHandler : IRequestHandler<UpdateBulletinCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBulletinCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBulletinCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBulletinDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BulletinDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Bulletin = await _unitOfWork.Repository<Bulletin>().Get(request.BulletinDto.BulletinId);

            if (Bulletin is null)
                throw new NotFoundException(nameof(Bulletin), request.BulletinDto.BulletinId);

            _mapper.Map(request.BulletinDto, Bulletin);

            await _unitOfWork.Repository<Bulletin>().Update(Bulletin);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
