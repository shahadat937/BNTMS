using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaClassSectionSelection.Validators;
using SchoolManagement.Application.Features.BnaClassSections.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassSections.Handler.Commands
{
    public class CreateBnaClassSectionCommandHandler : IRequestHandler<CreateBnaClassSectionCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public CreateBnaClassSectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateBnaClassSectionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBnaClassSectionSelectionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaClassSectionDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BnaClassSection = _mapper.Map<BnaClassSectionSelection>(request.BnaClassSectionDto);

                BnaClassSection = await _unitOfWork.Repository<BnaClassSectionSelection>().Add(BnaClassSection);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BnaClassSection.BnaClassSectionSelectionId;
            }

            return response;
        }
    }
}
