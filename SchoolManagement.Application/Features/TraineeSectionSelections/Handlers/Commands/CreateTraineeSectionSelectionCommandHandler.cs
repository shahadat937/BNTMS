using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeSectionSelection.Validators;
using SchoolManagement.Application.Features.TraineeSectionSelections.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.TraineeSectionSelections.Handlers.Commands
{
    public class CreateTraineeSectionSelectionCommandHandler : IRequestHandler<CreateTraineeSectionSelectionCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTraineeSectionSelectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTraineeSectionSelectionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTraineeSectionSelectionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TraineeSectionSelectionDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var TraineeSectionSelections = _mapper.Map<TraineeSectionSelection>(request.TraineeSectionSelectionDto);

                TraineeSectionSelections = await _unitOfWork.Repository<TraineeSectionSelection>().Add(TraineeSectionSelections);
                
                
                    await _unitOfWork.Save();
                

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = TraineeSectionSelections.TraineeSectionSelectionId;
            }

            return response;
        }
    }
}
