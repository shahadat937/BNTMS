using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaClassAttendance.Request.Commands;
using SchoolManagement.Application.Responses;
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

            foreach (var item in bnaClassAttendances)
            {

            }

            response.Success = true;
            response.Message = "Creation Successful";

            return response;
        }
    }
}
