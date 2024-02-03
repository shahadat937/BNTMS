using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.BnaBatch.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.BnaBatches.Requests.Commands;

namespace SchoolManagement.Application.Features.BnaBatches.Handlers.Commands
{
    public class UpdateBnaBatchCommandHandler : IRequestHandler<UpdateBnaBatchCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBnaBatchCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBnaBatchCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBnaBatchDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaBatchDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BnaBatch = await _unitOfWork.Repository<BnaBatch>().Get(request.BnaBatchDto.BnaBatchId);

            if (BnaBatch is null)
                throw new NotFoundException(nameof(BnaBatch), request.BnaBatchDto.BnaBatchId);

            _mapper.Map(request.BnaBatchDto, BnaBatch);

            await _unitOfWork.Repository<BnaBatch>().Update(BnaBatch);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
