using AutoMapper;
using SchoolManagement.Application.DTOs.ReadingMaterialTitle.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ReadingMaterialTitles.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses; 
using System.Linq;
using SchoolManagement.Application.DTOs.ReadingMaterialTitles.Validators;

namespace SchoolManagement.Application.Features.ReadingMaterialTitles.Handlers.Commands
{
    public class CreateReadingMaterialTitleCommandHandler : IRequestHandler<CreateReadingMaterialTitleCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateReadingMaterialTitleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateReadingMaterialTitleCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateReadingMaterialTitleDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ReadingMaterialTitleDto);

            if (validationResult.IsValid == false)
            { 
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ReadingMaterialTitle = _mapper.Map<ReadingMaterialTitle>(request.ReadingMaterialTitleDto);

                ReadingMaterialTitle = await _unitOfWork.Repository<ReadingMaterialTitle>().Add(ReadingMaterialTitle);
                try
                {
                    await _unitOfWork.Save();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
               

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ReadingMaterialTitle.ReadingMaterialTitleId;
            }

            return response;
        }
    }
}
