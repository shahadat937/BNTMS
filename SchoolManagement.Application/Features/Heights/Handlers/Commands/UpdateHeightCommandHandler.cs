using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Height.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Heights.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Heights.Handler.Commands
{
    public class UpdateHeightCommandHandler : IRequestHandler<UpdateHeightsCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;
         
        public UpdateHeightCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateHeightsCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateHeightDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.HeightDto); 

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 

            var height = await _unitOfWork.Repository<Height>().Get(request.HeightDto.HeightId);

            if (height is null)
                throw new NotFoundException(nameof(height), request.HeightDto.HeightId); 

            _mapper.Map(request.HeightDto, height); 

            await _unitOfWork.Repository<Height>().Update(height);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}