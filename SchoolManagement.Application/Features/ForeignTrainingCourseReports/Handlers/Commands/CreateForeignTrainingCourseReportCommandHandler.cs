using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ForeignTrainingCourseReport.Validators;
using SchoolManagement.Application.Features.ForeignTrainingCourseReports.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForeignTrainingCourseReports.Handlers.Commands
{
    public class CreateForeignTrainingCourseReportCommandHandler : IRequestHandler<CreateForeignTrainingCourseReportCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateForeignTrainingCourseReportCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateForeignTrainingCourseReportCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateForeignTrainingCourseReportDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ForeignTrainingCourseReportDto);

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

                if (request.ForeignTrainingCourseReportDto.DocFile != null)
                {

                    var fileName = Path.GetFileName(request.ForeignTrainingCourseReportDto.DocFile.FileName);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\foreign-training-course-report", uniqueFileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.ForeignTrainingCourseReportDto.DocFile.CopyToAsync(fileSteam);
                    }


                }
                var ForeignTrainingCourseReport = _mapper.Map<ForeignTrainingCourseReport>(request.ForeignTrainingCourseReportDto);

                ForeignTrainingCourseReport.Doc = request.ForeignTrainingCourseReportDto.Doc ?? "files/foreign-training-course-report/" + uniqueFileName;
                //ForeignCourseGOInfo.Status = 0;
                ForeignTrainingCourseReport = await _unitOfWork.Repository<ForeignTrainingCourseReport>().Add(ForeignTrainingCourseReport);
                await _unitOfWork.Save();



                //var ForeignTrainingCourseReport = _mapper.Map<ForeignTrainingCourseReport>(request.ForeignTrainingCourseReportDto);

                //ForeignTrainingCourseReport = await _unitOfWork.Repository<ForeignTrainingCourseReport>().Add(ForeignTrainingCourseReport);
                //await _unitOfWork.Save();
                

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ForeignTrainingCourseReport.ForeignTrainingCourseReportid;
            }

            return response;
        }
    }
}
