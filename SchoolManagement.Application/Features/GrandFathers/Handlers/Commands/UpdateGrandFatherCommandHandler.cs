using AutoMapper;
using SchoolManagement.Application.DTOs.GrandFather.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.GrandFathers.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GrandFathers.Handlers.Commands
{
    public class UpdateGrandFatherCommandHandler : IRequestHandler<UpdateGrandFatherCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGrandFatherCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateGrandFatherCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateGrandFatherDtoValidator();
            var validationResult = await validator.ValidateAsync(request.GrandFatherDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var GrandFather = await _unitOfWork.Repository<GrandFather>().Get(request.GrandFatherDto.GrandFatherId);

            if (GrandFather is null)
                throw new NotFoundException(nameof(GrandFather), request.GrandFatherDto.GrandFatherId);

            _mapper.Map(request.GrandFatherDto, GrandFather);

            await _unitOfWork.Repository<GrandFather>().Update(GrandFather);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
