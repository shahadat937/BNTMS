using AutoMapper;
using SchoolManagement.Application.DTOs.RoutineSoftCopyUpload.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.RoutineSoftCopyUploads.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.RoutineSoftCopyUploads.Handlers.Commands
{
    public class UpdateRoutineSoftCopyUploadCommandHandler : IRequestHandler<UpdateRoutineSoftCopyUploadCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRoutineSoftCopyUploadCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateRoutineSoftCopyUploadCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateRoutineSoftCopyUploadDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateRoutineSoftCopyUploadDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var RoutineSoftCopyUploads = await _unitOfWork.Repository<RoutineSoftCopyUpload>().Get(request.CreateRoutineSoftCopyUploadDto.RoutineSoftCopyUploadId);

            if (RoutineSoftCopyUploads is null)
                throw new NotFoundException(nameof(RoutineSoftCopyUpload), request.CreateRoutineSoftCopyUploadDto.RoutineSoftCopyUploadId);

            /////// File Upload //////////
            ///
            string uniqueFileName = null;

            if (request.CreateRoutineSoftCopyUploadDto.Doc != null)
            {

                var fileName = Path.GetFileName(request.CreateRoutineSoftCopyUploadDto.Doc.FileName);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                var a = Directory.GetCurrentDirectory();
                //var filePath = Path.Combine(_hostingEnv.WebRootPath, "Content\\images\\profile", uniqueFileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\routinesoftcopy-upload", uniqueFileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await request.CreateRoutineSoftCopyUploadDto.Doc.CopyToAsync(fileSteam);
                }

                // request.UpdateTraineeBIODataGeneralInfoDto.BnaPhotoUrl = "images/profile/" + uniqueFileName;
            }

            ////
            //  DateTime? d = request.TraineeBioDataGeneralInfoDto.DateOfBirth.ConvertToDateTime();




            _mapper.Map(request.CreateRoutineSoftCopyUploadDto, RoutineSoftCopyUploads);

            //  request.TraineeBioDataGeneralInfoDto.BnaPhotoUrl = request.TraineeBioDataGeneralInfoDto.BnaPhotoUrl ?? TraineeBioDataGeneralInfos.BnaPhotoUrl;


            // TraineeBioDataGeneralInfos.BnaPhotoUrl = request.TraineeBioDataGeneralInfoDto.BnaPhotoUrl ?? "images/profile/" + uniqueFileName;
            RoutineSoftCopyUploads.DocumentLink = request.CreateRoutineSoftCopyUploadDto.Doc != null ? "files/routinesoftcopy-upload/" + uniqueFileName : RoutineSoftCopyUploads.DocumentLink.Replace("https://localhost:44395/Content/", String.Empty);




            await _unitOfWork.Repository<RoutineSoftCopyUpload>().Update(RoutineSoftCopyUploads);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
