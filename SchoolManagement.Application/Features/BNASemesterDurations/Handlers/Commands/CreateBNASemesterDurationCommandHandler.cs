using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaSemesterDurations.Validators;
using SchoolManagement.Application.Features.BnaSemesterDurations.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaSemesterDurations.Handlers.Commands   
{
    public class CreateBnaSemesterDurationCommandHandler : IRequestHandler<CreateBnaSemesterDurationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public CreateBnaSemesterDurationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateBnaSemesterDurationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBnaSemesterDurationDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.BnaSemesterDurationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BnaSemesterDuration = _mapper.Map<BnaSemesterDuration>(request.BnaSemesterDurationDto); 

                BnaSemesterDuration = await _unitOfWork.Repository<BnaSemesterDuration>().Add(BnaSemesterDuration);
                await _unitOfWork.Save();
                response.Success = true;
                response.Message = "Creation Successful"; 
                response.Id = BnaSemesterDuration.BnaSemesterDurationId;
            }

            return response;
        }
    }
}
