using AutoMapper;
using SchoolManagement.Application.DTOs.BnaCurriculumUpdate.Validators;
using SchoolManagement.Application.Features.BnaCurriculumUpdates.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.BnaCurriculumUpdates.Handlers.Commands
{
    public class CreateBnaCurriculumUpdateCommandHandler : IRequestHandler<CreateBnaCurriculumUpdateCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBnaCurriculumUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBnaCurriculumUpdateCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBnaCurriculumUpdateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaCurriculumUpdateDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BnaCurriculumUpdates = _mapper.Map<BnaCurriculumUpdate>(request.BnaCurriculumUpdateDto);

                BnaCurriculumUpdates = await _unitOfWork.Repository<BnaCurriculumUpdate>().Add(BnaCurriculumUpdates);
                
                
                    await _unitOfWork.Save();
                

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BnaCurriculumUpdates.BnaCurriculumUpdateId;
            }

            return response;
        }
    }
}
