using AutoMapper;
using SchoolManagement.Application.Features.TraineeAssessmentMarks.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Responses;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.TraineeAssessmentMarks.Handlers.Commands
{
    public class CreateTraineeAssessmentMarkListCommandHandler : IRequestHandler<CreateTraineeAssessmentMarkListCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTraineeAssessmentMarkListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTraineeAssessmentMarkListCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            //var TraineeAssessmentMarks = _mapper.Map<List<TraineeAssessmentMark>>(request.TraineeAssessmentMarkListDto);
            var TraineeAssessmentMarks = request.TraineeAssessmentMarkListDto;

            var TraineeAssessmentMarkList = TraineeAssessmentMarks.assessmentTraineeListForm.Select(x => new TraineeAssessmentMark()
            {
                CourseDurationId = TraineeAssessmentMarks.CourseDurationId,
                BaseSchoolNameId = TraineeAssessmentMarks.BaseSchoolNameId,
                AssessmentTraineeId = TraineeAssessmentMarks.AssessmentTraineeId,
                AssessmentTypeId = TraineeAssessmentMarks.AssessmentTypeId,
                Status = TraineeAssessmentMarks.Status,
                MenuPosition = TraineeAssessmentMarks.MenuPosition,
                IsActive = TraineeAssessmentMarks.IsActive,
                TraineeNominationId = x.TraineeNominationId,
                TraineeAssessmentCreateId = TraineeAssessmentMarks.TraineeAssessmentCreateId,
                TraineeId = x.TraineeId,
                Position = x.Position,
                Knowledge = x.Knowledge,
                StaffDuty = x.StaffDuty,
                Leadeship = x.Leadeship,
                Remarks = x.Remarks,
            });

            try
            {
                await _unitOfWork.Repository<TraineeAssessmentMark>().AddRangeAsync(TraineeAssessmentMarkList);
                await _unitOfWork.Save();

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            var traineeAssissmentGroups =  _unitOfWork.Repository<TraineeAssissmentGroup>().FinedOneInclude(x => x.CourseDurationId == TraineeAssessmentMarks.CourseDurationId && x.TraineeAssissmentCreateId == TraineeAssessmentMarks.TraineeAssessmentCreateId && x.TraineeId == TraineeAssessmentMarks.AssessmentTraineeId && x.Status == 0);
            traineeAssissmentGroups.Status = 1;

            await _unitOfWork.Repository<TraineeAssissmentGroup>().Update(traineeAssissmentGroups);
            await _unitOfWork.Save();

            //var routines = await _unitOfWork.Repository<TraineeAssissmentGroup>().Get(bnaExamMarkList.Select(x => BnaExamMarks.ClassRoutineId).FirstOrDefault().Value);

            response.Success = true;
            response.Message = "Creation Successful";

            return response;
        }
    }
}
