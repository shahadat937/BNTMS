using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ForeignCourseOtherDoc.Validators;
using SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForeignCourseOtherDocs.Handlers.Commands
{
    public class CreateForeignCourseOtherDocCommandHandler : IRequestHandler<CreateForeignCourseOtherDocCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateForeignCourseOtherDocCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateForeignCourseOtherDocCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateForeignCourseOtherDocDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ForeignCourseOtherDocDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ForeignCourseOtherDoc = _mapper.Map<ForeignCourseOtherDoc>(request.ForeignCourseOtherDocDto);

                ForeignCourseOtherDoc = await _unitOfWork.Repository<ForeignCourseOtherDoc>().Add(ForeignCourseOtherDoc);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ForeignCourseOtherDoc.ForeignCourseOtherDocId;
            }

            return response;
        }
    }
}
