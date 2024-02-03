using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ForeignCourseOthersDocument.Validators;
using SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Handlers.Commands
{
    public class CreateForeignCourseOthersDocumentCommandHandler : IRequestHandler<CreateForeignCourseOthersDocumentCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateForeignCourseOthersDocumentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateForeignCourseOthersDocumentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateForeignCourseOthersDocumentDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ForeignCourseOthersDocumentDto);

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

                if (request.ForeignCourseOthersDocumentDto.Doc != null)
                {

                    var fileName = Path.GetFileName(request.ForeignCourseOthersDocumentDto.Doc.FileName);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\foreign-course-other-documents", uniqueFileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.ForeignCourseOthersDocumentDto.Doc.CopyToAsync(fileSteam);
                    }


                }
                var ForeignCourseGOInfo = _mapper.Map<ForeignCourseOthersDocument>(request.ForeignCourseOthersDocumentDto);

                ForeignCourseGOInfo.FileUpload = request.ForeignCourseOthersDocumentDto.FileUpload ?? "files/foreign-course-other-documents/" + uniqueFileName;
                ForeignCourseGOInfo.Status = 0;
                ForeignCourseGOInfo = await _unitOfWork.Repository<ForeignCourseOthersDocument>().Add(ForeignCourseGOInfo);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ForeignCourseGOInfo.ForeignCourseOthersDocumentId;


                //var ForeignCourseOthersDocument = _mapper.Map<ForeignCourseOthersDocument>(request.ForeignCourseOthersDocumentDto);

                //ForeignCourseOthersDocument = await _unitOfWork.Repository<ForeignCourseOthersDocument>().Add(ForeignCourseOthersDocument);
                //try
                //{
                //    await _unitOfWork.Save();
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.ToString());
                //}


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ForeignCourseGOInfo.ForeignCourseOthersDocumentId;
            }

            return response;
        }
    }
}
