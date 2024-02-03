using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ExamCenterSelection.Validators;
using SchoolManagement.Application.Features.ExamCenterSelections.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamCenterSelections.Handlers.Commands
{
    public class CreateExamCenterSelectionCommandHandler : IRequestHandler<CreateExamCenterSelectionCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateExamCenterSelectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateExamCenterSelectionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateExamCenterSelectionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ExamCenterSelectionDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ExamCenterSelection = _mapper.Map<ExamCenterSelection>(request.ExamCenterSelectionDto);

                ExamCenterSelection = await _unitOfWork.Repository<ExamCenterSelection>().Add(ExamCenterSelection);
                
                    await _unitOfWork.Save();
                


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ExamCenterSelection.ExamCenterSelectionId;
            }

            return response;
        }
    }
}
