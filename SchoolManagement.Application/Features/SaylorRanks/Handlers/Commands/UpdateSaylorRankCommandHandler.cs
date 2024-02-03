using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.SaylorRanks.Requests.Commands;
using SchoolManagement.Application.DTOs.SaylorRank.Validators;

namespace SchoolManagement.Application.Features.SaylorRanks.Handlers.Commands
{
    public class UpdateSaylorRankCommandHandler : IRequestHandler<UpdateSaylorRankCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSaylorRankCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSaylorRankCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSaylorRankDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.SaylorRankDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var SaylorRank = await _unitOfWork.Repository<SaylorRank>().Get(request.SaylorRankDto.SaylorRankId);

            if (SaylorRank is null)
                throw new NotFoundException(nameof(SaylorRank), request.SaylorRankDto.SaylorRankId);

            _mapper.Map(request.SaylorRankDto, SaylorRank);

            await _unitOfWork.Repository<SaylorRank>().Update(SaylorRank);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
