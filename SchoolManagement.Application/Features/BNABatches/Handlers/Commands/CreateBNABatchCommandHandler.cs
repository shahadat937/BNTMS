using AutoMapper;
using SchoolManagement.Application.DTOs.BnaBatch.Validators;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;
using SchoolManagement.Application.Features.BnaBatches.Requests.Commands;

namespace SchoolManagement.Application.Features.BnaBatches.Handlers.Commands
{
    public class CreateBnaBatchCommandHandler : IRequestHandler<CreateBnaBatchCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBnaBatchCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBnaBatchCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBnaBatchDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaBatchDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BnaBatch = _mapper.Map<BnaBatch>(request.BnaBatchDto);
                BnaBatch.StartDate = BnaBatch.StartDate.AddDays(1.0);

                BnaBatch = await _unitOfWork.Repository<BnaBatch>().Add(BnaBatch);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BnaBatch.BnaBatchId;
            }

            return response;
        }
    }
}
