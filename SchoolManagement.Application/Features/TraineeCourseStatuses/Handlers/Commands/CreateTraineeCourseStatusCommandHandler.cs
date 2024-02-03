using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TraineeCourseStatus.Validators;
using SchoolManagement.Application.Features.TraineeCourseStatuses.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeCourseStatuses.Handlers.Commands
{
    public class CreateTraineeCourseStatusCommandHandler : IRequestHandler<CreateTraineeCourseStatusesCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public CreateTraineeCourseStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateTraineeCourseStatusesCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTraineeCourseStatusDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.TraineeCourseStatusDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var TraineeCourseStatus = _mapper.Map<TraineeCourseStatus>(request.TraineeCourseStatusDto); 

                TraineeCourseStatus = await _unitOfWork.Repository<TraineeCourseStatus>().Add(TraineeCourseStatus);
                await _unitOfWork.Save();
                response.Success = true;
                response.Message = "Creation Successful"; 
                response.Id = TraineeCourseStatus.TraineeCourseStatusId;
            }

            return response;
        }
    }
}
