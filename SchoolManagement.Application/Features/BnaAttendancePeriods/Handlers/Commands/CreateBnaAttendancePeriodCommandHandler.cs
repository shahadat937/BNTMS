using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaAttendancePeriod.Validators;
using SchoolManagement.Application.Features.BnaAttendancePeriods.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BnaAttendancePeriods.Handlers.Commands
{
    public class CreateBnaAttendancePeriodCommandHandler: IRequestHandler<CreateBnaAttendancePeriodCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBnaAttendancePeriodCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBnaAttendancePeriodCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBnaAttendancePeriodDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaAttendancePeriodDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BnaAttendancePeriod = _mapper.Map<BnaAttendancePeriod>(request.BnaAttendancePeriodDto);

                BnaAttendancePeriod = await _unitOfWork.Repository<BnaAttendancePeriod>().Add(BnaAttendancePeriod);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BnaAttendancePeriod.BnaAttendancePeriodId;
            }

            return response;
        }
    }
}
