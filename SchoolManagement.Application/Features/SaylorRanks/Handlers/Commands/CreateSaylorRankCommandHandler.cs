using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SaylorRank.Validators;
using SchoolManagement.Application.Features.SaylorRanks.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SaylorRanks.Handlers.Commands
{
    public class CreateSaylorRankCommandHandler : IRequestHandler<CreateSaylorRankCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSaylorRankCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSaylorRankCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSaylorRankDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SaylorRankDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var SaylorRank = _mapper.Map<SaylorRank>(request.SaylorRankDto);

                SaylorRank = await _unitOfWork.Repository<SaylorRank>().Add(SaylorRank);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = SaylorRank.SaylorRankId;
            }

            return response;
        }
    }
}
