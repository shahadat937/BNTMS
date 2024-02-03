using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaSubjectname.Validators;
using SchoolManagement.Application.DTOs.BnaSubjectName.Validators;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Handlers.Commands   
{
    public class CreateBnaSubjectNameCommandHandler : IRequestHandler<CreateBnaSubjectNameCommand, BaseCommandResponse>
    { 
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public CreateBnaSubjectNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateBnaSubjectNameCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBnaSubjectNameDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.BnaSubjectNameDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BnaSubjectName = _mapper.Map<BnaSubjectName>(request.BnaSubjectNameDto); 

                BnaSubjectName = await _unitOfWork.Repository<BnaSubjectName>().Add(BnaSubjectName);
           
                await _unitOfWork.Save();
                response.Success = true;
                response.Message = "Creation Successful"; 
                response.Id = BnaSubjectName.BnaSubjectNameId;
            }

            return response;
        }
    }
}

