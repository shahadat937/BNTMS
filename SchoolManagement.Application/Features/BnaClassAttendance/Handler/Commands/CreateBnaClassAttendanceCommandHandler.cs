using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Attendance;
using SchoolManagement.Application.Features.BnaClassAttendance.Request.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassAttendance.Handler.Commands
{
    public class CreateBnaClassAttendanceCommandHandler : IRequestHandler<CreateBnaClassAttendanceCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBnaClassAttendanceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBnaClassAttendanceCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            List<Domain.BnaClassAttendance> classAttendances = new List<Domain.BnaClassAttendance>();
            classAttendances = request.BnaClassAttendanceDto.studentAttendanceForm.Select(x => new Domain.BnaClassAttendance()
            {
                BnaClassAttendanceId = request.BnaClassAttendanceDto.BnaClassAttendanceId,
                BnaSubjectCurriculumId = request.BnaClassAttendanceDto.BnaSubjectCurriculumId,
                CourseNameId = request.BnaClassAttendanceDto.CourseNameId,
                CourseDurationId = request.BnaClassAttendanceDto.CourseDurationId,
                BnaSemesterId = request.BnaClassAttendanceDto.BnaSemesterId,
                BaseSchoolNameId = request.BnaClassAttendanceDto.BaseSchoolNameId,
                CourseSectionId = request.BnaClassAttendanceDto.CourseSectionId,
                ClassPeriodId = request.BnaClassAttendanceDto.ClassPeriodId,
                AttendanceDate = request.BnaClassAttendanceDto.Date,
                TraineeId = x.traineeId,
                SubjectId = x.subjectId,
                InstructorId = x.instructorId,
                AttendanceStatus = x.attendance,
                Remark = x.remark
            }).ToList();

            await _unitOfWork.Repository<Domain.BnaClassAttendance>().AddRangeAsync(classAttendances);

            try
            {
                await _unitOfWork.Save();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }



            response.Success = true;
            response.Message = "Creation Successful";

            return response;
        }
    }
}
