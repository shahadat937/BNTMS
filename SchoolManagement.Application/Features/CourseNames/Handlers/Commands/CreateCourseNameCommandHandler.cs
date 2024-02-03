using AutoMapper;
using SchoolManagement.Application.DTOs.CourseName.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseNames.Requests.Commands;
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

namespace SchoolManagement.Application.Features.CourseNames.Handlers.Commands
{
    public class CreateCourseNameCommandHandler : IRequestHandler<CreateCourseNameCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCourseNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCourseNameCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCourseNameDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CourseNameDto);

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

                if (request.CourseNameDto.Doc != null)
                {

                    var fileName = Path.GetFileName(request.CourseNameDto.Doc.FileName);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\course-names", uniqueFileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.CourseNameDto.Doc.CopyToAsync(fileSteam);
                    }


                }

                var CourseName = _mapper.Map<CourseName>(request.CourseNameDto);
                CourseName.CourseSyllabus = request.CourseNameDto.CourseSyllabus ?? "files/course-names/" + uniqueFileName;

                CourseName = await _unitOfWork.Repository<CourseName>().Add(CourseName);
                
                    await _unitOfWork.Save();
                
                

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CourseName.CourseNameId;
            }

            return response;
        }
    }
}
