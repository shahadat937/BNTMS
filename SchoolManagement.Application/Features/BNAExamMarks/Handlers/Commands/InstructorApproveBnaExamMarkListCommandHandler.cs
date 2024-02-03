using AutoMapper;
using SchoolManagement.Application.Features.BnaExamMarks.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.BnaExamMarks.Handlers.Commands
{
    public class InstructorApproveBnaExamMarkListCommandHandler : IRequestHandler<InstructorApproveBnaExamMarkListCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InstructorApproveBnaExamMarkListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(InstructorApproveBnaExamMarkListCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            //var BnaExamMarks = _mapper.Map<List<BnaExamMark>>(request.ApproveBnaExamMarkListDto);
            var BnaExamMarks = request.ApproveBnaExamMarkListDto;
            
            var bnaExamMarkList = BnaExamMarks.approveTraineeListForm.Select(x => new BnaExamMark()
            {
                BnaExamMarkId = x.BnaExamMarkId,
                BaseSchoolNameId = BnaExamMarks.BaseSchoolNameId,
                CourseNameId = BnaExamMarks.CourseNameId,
                BnaSubjectNameId = BnaExamMarks.BnaSubjectNameId,
                SubjectMarkId = BnaExamMarks.SubjectMarkId,
                BnaExamScheduleId = BnaExamMarks.BnaExamScheduleId,
                BnaSemesterId = BnaExamMarks.BnaSemesterId,
                BnaBatchId = BnaExamMarks.BnaBatchId,
                BranchId = BnaExamMarks.BranchId,
                TraineeNominationId = x.TraineeNominationId,
                ClassRoutineId = BnaExamMarks.ClassRoutineId,
                CourseDurationId = BnaExamMarks.CourseDurationId,
                BnaCurriculumTypeId = BnaExamMarks.BnaCurriculamTypeId,
                TotalMark = BnaExamMarks.TotalMark,
                PassMark = BnaExamMarks.PassMark,
                IsApproved = BnaExamMarks.IsApproved,
                IsApprovedBy = BnaExamMarks.IsApprovedBy,
                IsApprovedDate = DateTime.Now,
                Remarks = BnaExamMarks.Remarks,
                Status = BnaExamMarks.Status,
                SubmissionStatus = 1,
                IsActive = BnaExamMarks.IsActive,
                DateCreated = x.DateCreated,
                CreatedBy = x.CreatedBy,
                ObtaintMark = x.ObtaintMark,
                ResultStatus = x.ResultStatus,
                TraineeId = x.TraineeId,
                ExamMarkRemarksId = x.ExamMarkRemarksId,
                CourseSectionId =BnaExamMarks.CourseSectionId,
                ReExamStatus =BnaExamMarks.ReExamStatus
            });
            try
            {
                foreach (var item in bnaExamMarkList)
                {
                    //var ApproveBnaExamMark = await _unitOfWork.Repository<BnaExamMark>().Get(item.BnaExamMarkId);
                    await _unitOfWork.Repository<BnaExamMark>().Update(item);
                    await _unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var routines = await _unitOfWork.Repository<ClassRoutine>().Get(request.ApproveBnaExamMarkListDto.ClassRoutineId.Value);

            

            if (BnaExamMarks.ExamTypeCount == 1)
            {
                routines.ResultSubmissionStatus = 1;

                await _unitOfWork.Repository<ClassRoutine>().Update(routines);
                await _unitOfWork.Save();
            }
            else
            {
                routines.ResultSubmissionStatus = 0;

                await _unitOfWork.Repository<ClassRoutine>().Update(routines);
                await _unitOfWork.Save();
            }


            //await _unitOfWork.Repository<BnaExamMark>().AddRangeAsync(bnaExamMarkList);
            //await _unitOfWork.Repository<BnaExamMark>().AddRangeAsync(bnaExamMarkList);
            //await _unitOfWork.Save();

            //var routines = await _unitOfWork.Repository<ClassRoutine>().Get(bnaExamMarkList.Select(x => BnaExamMarks.ClassRoutineId).FirstOrDefault().Value);

            //if (BnaExamMarks.ExamTypeCount == 1)
            //{
            //    routines.ExamMarkComplete = 1;
            //    await _unitOfWork.Repository<ClassRoutine>().Update(routines);
            //    await _unitOfWork.Save();
            //}
            //else
            //{
            //    routines.ExamMarkComplete = 0;
            //    await _unitOfWork.Repository<ClassRoutine>().Update(routines);
            //    await _unitOfWork.Save();
            //}

            //routines.ExamMarkComplete = 1;

            //await _unitOfWork.Repository<ClassRoutine>().Update(routines);
            //await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Approve Successful";

            return response;
        }
    }
}
