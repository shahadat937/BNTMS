using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ForeignCourseGOInfo.Validators;
using SchoolManagement.Application.Features.ForeignCourseGOInfos.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForeignCourseGOInfos.Handlers.Commands
{
    public class CreateForeignCourseGOInfoCommandHandler : IRequestHandler<CreateForeignCourseGOInfoCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateForeignCourseGOInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateForeignCourseGOInfoCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateForeignCourseGOInfoDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ForeignCourseGOInfoDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {

                /////// File Upload //////////

                string uniqueFileName = null;

                if (request.ForeignCourseGOInfoDto.Doc != null)
                {

                    var fileName = Path.GetFileName(request.ForeignCourseGOInfoDto.Doc.FileName);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\foreign-course-go-infos", uniqueFileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.ForeignCourseGOInfoDto.Doc.CopyToAsync(fileSteam);
                    }


                }
                var ForeignCourseGOInfo = _mapper.Map<ForeignCourseGOInfo>(request.ForeignCourseGOInfoDto);

                ForeignCourseGOInfo.FileUpload = request.ForeignCourseGOInfoDto.FileUpload ?? "files/foreign-course-go-infos/" + uniqueFileName;

                ForeignCourseGOInfo = await _unitOfWork.Repository<ForeignCourseGOInfo>().Add(ForeignCourseGOInfo);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ForeignCourseGOInfo.ForeignCourseGOInfoId;
            }

            return response;
        }
    }
}
