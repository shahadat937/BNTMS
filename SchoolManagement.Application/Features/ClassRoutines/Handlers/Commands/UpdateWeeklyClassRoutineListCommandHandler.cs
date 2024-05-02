﻿using AutoMapper;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Commands
{
    public class UpdateWeeklyClassRoutineListCommandHandler : IRequestHandler<UpdateWeeklyClassRoutineListCommand, BaseCommandResponse>
    {
        private readonly ISchoolManagementRepository<Domain.BnaClassRoutine> _ClassRoutineRepository;
        private readonly ISchoolManagementRepository<BnaSubjectName> _BnaSubjectNameRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateWeeklyClassRoutineListCommandHandler(ISchoolManagementRepository<Domain.BnaClassRoutine> ClassRoutineRepository, ISchoolManagementRepository<BnaSubjectName> BnaSubjectNameRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _ClassRoutineRepository = ClassRoutineRepository;
            _BnaSubjectNameRepository = BnaSubjectNameRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateWeeklyClassRoutineListCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            
            var ClassRoutines = request.UpdateClassRoutineDtoList;
            //var ClassRoutines = _mapper.Map<List<ClassRoutine>>(request.ClassRoutines);


         
            int? BaseSchoolNameId = request.UpdateClassRoutineDtoList.RoutineList.Select(x => x.baseSchoolNameId).FirstOrDefault();
            string? CourseDurationId = request.UpdateClassRoutineDtoList.RoutineList.Select(x => x.CourseDurationId).FirstOrDefault();
            string? CourseNameId = request.UpdateClassRoutineDtoList.RoutineList.Select(x => x.CourseNameId).FirstOrDefault();
            int? CourseWeekId = request.UpdateClassRoutineDtoList.RoutineList.Select(x => x.courseWeekId).FirstOrDefault();
            int? BnaSubjectNameId = request.UpdateClassRoutineDtoList.RoutineList.Select(x => x.courseWeekId).FirstOrDefault();

            if(CourseNameId == "1252")
            {
                IQueryable<Domain.BnaClassRoutine> ClassRoutineListForDelete = _ClassRoutineRepository.FilterWithInclude(x => (x.CourseDurationId == CourseDurationId && x.AttendanceComplete == 0));
                await _unitOfWork.Repository<Domain.BnaClassRoutine>().RemoveRangeAsync(ClassRoutineListForDelete);
                await _unitOfWork.Save();
            }
            else
            {
                try
                {
                    IQueryable<Domain.BnaClassRoutine> ClassRoutineListForDelete = _ClassRoutineRepository.FilterWithInclude(x => (x.BaseSchoolNameId == BaseSchoolNameId && x.CourseDurationId == CourseDurationId && x.CourseNameId == CourseNameId && x.CourseNameId == CourseWeekId.ToString() && x.AttendanceComplete == 0));
                    await _unitOfWork.Repository<Domain.BnaClassRoutine>().RemoveRangeAsync(ClassRoutineListForDelete);
                    await _unitOfWork.Save();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
           
            

            

            var query = ClassRoutines.RoutineList.GroupBy(b => b.bnaSubjectNameId).SelectMany(g => g.OrderBy(b => b.date).Select((b, i) => new { b.classRoutineId, b.CourseSectionId, countPeriod = i + 1 }));

            var subjectTotalPeriod = await _BnaSubjectNameRepository.FilterAsync(x=>x.IsActive);

            if (CourseNameId == "1252")
            {
                var ClassRoutineList = ClassRoutines.RoutineList.OrderBy(x => x.date).Select(x => new Domain.BnaClassRoutine()
                {
                    // ClassRoutineId = x.classRoutineId,
                    CourseModuleId = x.courseModuleId,
                    ClassPeriodId = x.classPeriodId,
                    BaseSchoolNameId = x.baseSchoolNameId,
                    SubjectMarkId = x.SubjectMarkId,
                    MarkTypeId = x.MarkTypeId,
                    TraineeId = x.TraineeId,
                    CourseSectionId = x.CourseSectionId,
                    ClassCountPeriod = x.classCountPeriod,
                    SubjectCountPeriod = x.subjectCountPeriod,
                    CourseNameId = x.CourseNameId,
                    WeekID = x.courseWeekId,
                    BranchId = x.BranchId,
                    CourseDurationId = x.CourseDurationId,
                    BnaSubjectNameId = x.bnaSubjectNameId,
                    AttendanceComplete = x.AttendanceComplete,
                    ExamMarkComplete = x.examMarkComplete,
                    ClassLocation = x.classLocation,
                    Date = x.date,
                    ClassTypeId = x.classTypeId,
                    IsApproved = x.isApproved,
                    ApprovedBy = x.approvedBy,
                    ApprovedDate = x.approvedDate,
                    Status = x.status,
                    MenuPosition = x.MenuPosition,
                    IsActive = x.isActive,
                });
                await _unitOfWork.Repository<Domain.BnaClassRoutine>().AddRangeAsync(ClassRoutineList);
                await _unitOfWork.Save();
            }
            else
            {
                var ClassRoutineList = ClassRoutines.RoutineList.OrderBy(x => x.date).Select(x => new Domain.BnaClassRoutine()
                {
                    // ClassRoutineId = x.classRoutineId,
                    CourseModuleId = x.courseModuleId,
                    ClassPeriodId = x.classPeriodId,
                    SubjectMarkId = x.SubjectMarkId,
                    MarkTypeId = x.MarkTypeId,
                    TraineeId = x.TraineeId,
                    CourseSectionId = x.CourseSectionId,
                    BaseSchoolNameId = x.baseSchoolNameId,
                    ClassCountPeriod = query.Where(y => y.classRoutineId == x.classRoutineId && y.CourseSectionId == x.CourseSectionId).Select(y => y.countPeriod).FirstOrDefault(),
                    SubjectCountPeriod = subjectTotalPeriod.Where(y => y.BnaSubjectNameId == x.bnaSubjectNameId).Select(y => int.Parse(y.TotalPeriod)).FirstOrDefault(),
                    CourseNameId = x.CourseNameId,
                    WeekID = x.courseWeekId,
                    CourseDurationId = x.CourseDurationId,
                    BnaSubjectNameId = x.bnaSubjectNameId,
                    AttendanceComplete = x.AttendanceComplete,
                    ExamMarkComplete = x.examMarkComplete,
                    ClassLocation = x.classLocation,
                    Date = x.date,
                    ClassTypeId = x.classTypeId,
                    IsApproved = x.isApproved,
                    ApprovedBy = x.approvedBy,
                    ApprovedDate = x.approvedDate,
                    Status = x.status,
                    MenuPosition = x.MenuPosition,
                    IsActive = x.isActive,
                });
                await _unitOfWork.Repository<Domain.BnaClassRoutine>().AddRangeAsync(ClassRoutineList);
                await _unitOfWork.Save();
            }

            
            
            
            

            response.Success = true;
            response.Message = "Approve Successful";

            return response;
        }

       
    }
}
