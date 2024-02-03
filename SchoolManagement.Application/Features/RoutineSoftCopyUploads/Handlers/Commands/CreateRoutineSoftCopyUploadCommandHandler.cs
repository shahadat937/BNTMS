using AutoMapper;
using SchoolManagement.Application.DTOs.RoutineSoftCopyUpload.Validators;
using SchoolManagement.Application.Features.RoutineSoftCopyUploads.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.RoutineSoftCopyUploads.Handlers.Commands
{
    public class CreateRoutineSoftCopyUploadCommandHandler : IRequestHandler<CreateRoutineSoftCopyUploadCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRoutineSoftCopyUploadCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateRoutineSoftCopyUploadCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateRoutineSoftCopyUploadDtoValidator();
            var validationResult = await validator.ValidateAsync(request.RoutineSoftCopyUploadDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                /////// File Upload //////////
                ///
                string uniqueFileName = null;

                if (request.RoutineSoftCopyUploadDto.Doc != null)
                {

                    var fileName = Path.GetFileName(request.RoutineSoftCopyUploadDto.Doc.FileName);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                    //var filePath = Path.Combine(_hostingEnv.WebRootPath, "Content\\images\\profile", uniqueFileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\routinesoftcopy-upload", uniqueFileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.RoutineSoftCopyUploadDto.Doc.CopyToAsync(fileSteam);
                    }


                }

                ////
                //  DateTime? d = request.TraineeBioDataGeneralInfoDto.DateOfBirth.ConvertToDateTime();

                var RoutineSoftCopyUploads = _mapper.Map<RoutineSoftCopyUpload>(request.RoutineSoftCopyUploadDto);

                RoutineSoftCopyUploads.DocumentLink = request.RoutineSoftCopyUploadDto.DocumentLink ?? "files/routinesoftcopy-upload/" + uniqueFileName;



                // var RoutineSoftCopyUploads = _mapper.Map<RoutineSoftCopyUpload>(request.RoutineSoftCopyUploadDto);

                RoutineSoftCopyUploads = await _unitOfWork.Repository<RoutineSoftCopyUpload>().Add(RoutineSoftCopyUploads);
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
                response.Id = RoutineSoftCopyUploads.RoutineSoftCopyUploadId;
            }

            return response;
        }
    }
}
