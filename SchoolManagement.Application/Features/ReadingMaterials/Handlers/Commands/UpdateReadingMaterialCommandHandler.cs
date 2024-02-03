using AutoMapper;
using SchoolManagement.Application.DTOs.ReadingMaterial.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ReadingMaterials.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ReadingMaterials.Handlers.Commands
{
    public class UpdateReadingMaterialCommandHandler : IRequestHandler<UpdateReadingMaterialCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateReadingMaterialCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateReadingMaterialCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateReadingMaterialDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateReadingMaterialDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ReadingMaterials = await _unitOfWork.Repository<ReadingMaterial>().Get(request.CreateReadingMaterialDto.ReadingMaterialId);

            if (ReadingMaterials is null)
                throw new NotFoundException(nameof(ReadingMaterial), request.CreateReadingMaterialDto.ReadingMaterialId);

            /////// File Upload //////////
            ///
            string uniqueFileName = null;

            if (request.CreateReadingMaterialDto.Doc != null)
            {

                var fileName = Path.GetFileName(request.CreateReadingMaterialDto.Doc.FileName);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                var a = Directory.GetCurrentDirectory();
                //var filePath = Path.Combine(_hostingEnv.WebRootPath, "Content\\images\\profile", uniqueFileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\reading-materials", uniqueFileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await request.CreateReadingMaterialDto.Doc.CopyToAsync(fileSteam);
                }

                // request.UpdateTraineeBIODataGeneralInfoDto.BnaPhotoUrl = "images/profile/" + uniqueFileName;
            }

            ////
            //  DateTime? d = request.TraineeBioDataGeneralInfoDto.DateOfBirth.ConvertToDateTime();




            _mapper.Map(request.CreateReadingMaterialDto, ReadingMaterials);

            //  request.TraineeBioDataGeneralInfoDto.BnaPhotoUrl = request.TraineeBioDataGeneralInfoDto.BnaPhotoUrl ?? TraineeBioDataGeneralInfos.BnaPhotoUrl;


            // TraineeBioDataGeneralInfos.BnaPhotoUrl = request.TraineeBioDataGeneralInfoDto.BnaPhotoUrl ?? "images/profile/" + uniqueFileName;
            ReadingMaterials.DocumentLink = request.CreateReadingMaterialDto.Doc != null ? "files/reading-materials/" + uniqueFileName : ReadingMaterials.DocumentLink.Replace("https://localhost:44395/Content/", String.Empty);




            await _unitOfWork.Repository<ReadingMaterial>().Update(ReadingMaterials);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
