using AutoMapper;
using SchoolManagement.Application.Features.InterServiceMarks.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Responses;
using SchoolManagement.Application.DTOs.InterServiceMark.converter;

namespace SchoolManagement.Application.Features.InterServiceMarks.Handlers.Commands
{
    public class CreateInterServiceMarkListCommandHandler : IRequestHandler<CreateInterServiceMarkListCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateInterServiceMarkListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateInterServiceMarkListCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var InterServiceMarks = request.InterServiceMarkListDto;

            /////// File Upload //////////

            //string uniqueFileName = null;

            //if (request..Doc != null)
            //{

            //    var fileName = Path.GetFileName(request.ForeignCourseOthersDocumentDto.Doc.FileName);
            //    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
            //    var a = Directory.GetCurrentDirectory();
            //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\foreign-course-other-documents", uniqueFileName);
            //    using (var fileSteam = new FileStream(filePath, FileMode.Create))
            //    {
            //        await request.ForeignCourseOthersDocumentDto.Doc.CopyToAsync(fileSteam);
            //    }


            //}
            //var ForeignCourseGOInfo = _mapper.Map<ForeignCourseOthersDocument>(request.ForeignCourseOthersDocumentDto);

            //ForeignCourseGOInfo.FileUpload = request.ForeignCourseOthersDocumentDto.FileUpload ?? "files/foreign-course-other-documents/" + uniqueFileName;
            //ForeignCourseGOInfo.Status = 0;
            //ForeignCourseGOInfo = await _unitOfWork.Repository<ForeignCourseOthersDocument>().Add(ForeignCourseGOInfo);
            //await _unitOfWork.Save();


            //response.Success = true;
            //response.Message = "Creation Successful";
            //response.Id = ForeignCourseGOInfo.ForeignCourseOthersDocumentId;
            ///
            var interServiceMarkList = new List<InterServiceMark>();
            var TraineeListForm = new List<InterServiceMarkListFormDto>();
            foreach (var item in TraineeListForm)
            {
                /////// File Upload //////////

                string uniqueFileName = null;

                if (item.Doc != null)
                {

                  //  var fileName = Path.GetFileName(item.Doc.FileName);
                  //  uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\inter-service-mark", uniqueFileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                       // await item.Doc.CopyToAsync(fileSteam);
                    }  

                    //var InterServiceMark = _mapper.Map<InterServiceMarkListDto>(request.ForeignCourseOthersDocumentDto);

                    //InterServiceMark.Doc = request.ForeignCourseOthersDocumentDto.FileUpload ?? "files/inter-service-mark/" + uniqueFileName;

                }
                var interServiceMark = new InterServiceMark()
                {
                    //CourseDurationId = InterServiceMarks.CourseDurationId,
                    //CourseNameId = item.CourseNameId,
                    //CourseTypeId = InterServiceMarks.CourseTypeId,
                    //CountryId = item.CountryId,
                    //OrganizationNameId = InterServiceMarks.OrganizationNameId,
                    //TraineeNominationId = item.TraineeNominationId,
                    //IsActive = InterServiceMarks.IsActive,
                    //TraineeId = item.TraineeId,
                    //CoursePosition = item.CoursePosition,
                    //ObtaintMark = item.ObtaintMark,
                    //Doc = item.Image,
                    //Remarks = item.Remarks,
                };
                interServiceMarkList.Add(interServiceMark);
            };
           
            //var interServiceMarkList = InterServiceMarks.traineeListForm.Select(x => new InterServiceMark()
            //{
            //    CourseDurationId = InterServiceMarks.CourseDurationId,
            //    CourseNameId = x.CourseNameId,
            //    CourseTypeId = InterServiceMarks.CourseTypeId,
            //    CountryId= x.CountryId,
            //    OrganizationNameId = InterServiceMarks.OrganizationNameId,
            //    TraineeNominationId = x.TraineeNominationId,
            //    IsActive = InterServiceMarks.IsActive,
            //    TraineeId = x.TraineeId,
            //    CoursePosition =x.CoursePosition,
            //    ObtaintMark = x.ObtaintMark,
            //    Doc = x.Image,
            //    Remarks =x.Remarks,
            //});

            //await _unitOfWork.Repository<InterServiceMark>().AddRangeAsync(interServiceMarkList);
            //await _unitOfWork.Save();


            response.Success = true;
            response.Message = "Creation Successful";

            return response;
        }
    }
}
