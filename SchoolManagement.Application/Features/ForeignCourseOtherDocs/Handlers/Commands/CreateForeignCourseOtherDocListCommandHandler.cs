using AutoMapper;
using SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.ForeignCourseOtherDocs.Handlers.Commands
{
    public class CreateForeignCourseOtherDocListCommandHandler : IRequestHandler<CreateForeignCourseOtherDocListCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISchoolManagementRepository<ForeignCourseOtherDoc> _foreignCourseOtherDocRepository;
        private readonly IMapper _mapper;

        public CreateForeignCourseOtherDocListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,
            ISchoolManagementRepository<ForeignCourseOtherDoc> foreignCourseOtherDocRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _foreignCourseOtherDocRepository = foreignCourseOtherDocRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateForeignCourseOtherDocListCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var ForeignCourseOtherDocs = request.ForeignCourseOtherDocListDto;
            
            var ForeignCourseOtherDocList = ForeignCourseOtherDocs.traineeListForm.Select(x => new ForeignCourseOtherDoc()
            {
                CourseDurationId = ForeignCourseOtherDocs.CourseDurationId,
                CourseNameId = x.CourseNameId,
                FinancialSanctionId= x.FinancialSanctionId,
                TraineeNominationId = x.TraineeNominationId,
                TraineeId = x.TraineeId,
                Ticket = x.Ticket,
                Visa = x.Visa,
                Passport = x.Passport,
                CovidTest = x.CovidTest,
                MedicalDocument =x.MedicalDocument,
                DgfiBreafing = x.DgfiBreafing,
                DniBreafing =x.DniBreafing,
                EmbassiBreafing = x.EmbassiBreafing,
                FinancialSanction= x.FinancialSanction,
                ExBdLeave= x.ExBdLeave,
                Remark= x.Remark,   
                MedicalTest = ForeignCourseOtherDocs.MedicalTest,
            });
            var foreignCourseList = _foreignCourseOtherDocRepository.FilterWithInclude(x => x.CourseDurationId == ForeignCourseOtherDocs.CourseDurationId);
            await _unitOfWork.Repository<ForeignCourseOtherDoc>().RemoveRangeAsync(foreignCourseList);
            await _unitOfWork.Repository<ForeignCourseOtherDoc>().AddRangeAsync(ForeignCourseOtherDocList);
            try
            {
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
           

            response.Success = true;
            response.Message = "Creation Successful";

            return response;
        }
    }
}
