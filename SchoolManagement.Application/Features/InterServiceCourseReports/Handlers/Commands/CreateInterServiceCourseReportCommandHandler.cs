using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.InterServiceCourseReport.Validators;
using SchoolManagement.Application.Features.InterServiceCourseReports.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InterServiceCourseReports.Handlers.Commands
{
    public class CreateInterServiceCourseReportCommandHandler : IRequestHandler<CreateInterServiceCourseReportCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateInterServiceCourseReportCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateInterServiceCourseReportCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateInterServiceCourseReportDtoValidator();
            var validationResult = await validator.ValidateAsync(request.InterServiceCourseReportDto);

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

                if (request.InterServiceCourseReportDto.DocFile != null)
                {

                    var fileName = Path.GetFileName(request.InterServiceCourseReportDto.DocFile.FileName);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\interservice-course-report", uniqueFileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.InterServiceCourseReportDto.DocFile.CopyToAsync(fileSteam);
                    }


                }
                var InterServiceCourseReport = _mapper.Map<InterServiceCourseReport>(request.InterServiceCourseReportDto);

                InterServiceCourseReport.Doc = request.InterServiceCourseReportDto.Doc ?? "files/interservice-course-report/" + uniqueFileName;
                //ForeignCourseGOInfo.Status = 0;
                InterServiceCourseReport = await _unitOfWork.Repository<InterServiceCourseReport>().Add(InterServiceCourseReport);
                await _unitOfWork.Save();



                //var InterServiceCourseReport = _mapper.Map<InterServiceCourseReport>(request.InterServiceCourseReportDto);

                //InterServiceCourseReport = await _unitOfWork.Repository<InterServiceCourseReport>().Add(InterServiceCourseReport);
                //await _unitOfWork.Save();
                

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = InterServiceCourseReport.InterServiceCourseReportid;
            }

            return response;
        }
    }
}
