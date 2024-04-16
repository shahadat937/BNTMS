using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaClassAttendance.Request.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassAttendance.Handler.Commands
{
    public class UpdateBnaClassAttendanceCommandHandler : IRequestHandler<UpdateBnaClassAttendanceCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<Domain.BnaClassAttendance> _BnaClassAttendanceRepository;

        public UpdateBnaClassAttendanceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ISchoolManagementRepository<Domain.BnaClassAttendance> bnaClassAttendanceRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _BnaClassAttendanceRepository = bnaClassAttendanceRepository;
        }

        public async Task<BaseCommandResponse> Handle(UpdateBnaClassAttendanceCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();



            IQueryable<Domain.BnaClassAttendance> bnaClassAttendances = _BnaClassAttendanceRepository.Where(x => x.AttendanceDate == request.BnaClassAttendanceDto.Date && x.BnaSubjectCurriculumId == request.BnaClassAttendanceDto.BnaSubjectCurriculumId && x.CourseTitleId == request.BnaClassAttendanceDto.CourseTitleId && x.BnaSemesterId == request.BnaClassAttendanceDto.BnaSemesterId && x.CourseSectionId == request.BnaClassAttendanceDto.CourseSectionId && x.ClassPeriodId == request.BnaClassAttendanceDto.ClassPeriodId);

            foreach (var item in request.BnaClassAttendanceDto.studentAttendanceForm)
            {
                foreach (var bnaClassAttendance in bnaClassAttendances)
                {
                    if (item.traineeId == bnaClassAttendance.TraineeId && item.instructorId == bnaClassAttendance.InstructorId && item.subjectId == bnaClassAttendance.SubjectId)
                    {
                        Domain.BnaClassAttendance ClassAttendanceList = new Domain.BnaClassAttendance
                        {
                            BnaClassAttendanceId = bnaClassAttendance.BnaClassAttendanceId,
                            BnaSubjectCurriculumId = request.BnaClassAttendanceDto.BnaSubjectCurriculumId,
                            CourseTitleId = request.BnaClassAttendanceDto.CourseTitleId,
                            BnaSemesterId = request.BnaClassAttendanceDto.BnaSemesterId,
                            BaseSchoolNameId = request.BnaClassAttendanceDto.BaseSchoolNameId,
                            CourseSectionId = request.BnaClassAttendanceDto.CourseSectionId,
                            ClassPeriodId = request.BnaClassAttendanceDto.ClassPeriodId,
                            AttendanceDate = request.BnaClassAttendanceDto.Date,
                            TraineeId = item.traineeId,
                            SubjectId = item.subjectId,
                            InstructorId = item.instructorId,
                            AttendanceStatus = item.attendance,
                            Remark = item.remark
                        };
                        var ClassAttendance = await _unitOfWork.Repository<Domain.BnaClassAttendance>().Get(bnaClassAttendance.BnaClassAttendanceId);
                        _mapper.Map(ClassAttendanceList, ClassAttendance);

                        await _unitOfWork.Repository<Domain.BnaClassAttendance>().Update(ClassAttendance);
                    }
                }
            }

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
