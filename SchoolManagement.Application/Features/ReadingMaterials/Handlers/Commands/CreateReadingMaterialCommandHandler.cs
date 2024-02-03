using AutoMapper;
using SchoolManagement.Application.DTOs.ReadingMaterial.Validators;
using SchoolManagement.Application.Features.ReadingMaterials.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.ReadingMaterials.Handlers.Commands
{
    public class CreateReadingMaterialCommandHandler : IRequestHandler<CreateReadingMaterialCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateReadingMaterialCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateReadingMaterialCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateReadingMaterialDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ReadingMaterialDto);

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

                if (request.ReadingMaterialDto.Doc != null)
                {

                    var fileName = Path.GetFileName(request.ReadingMaterialDto.Doc.FileName);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                    //var filePath = Path.Combine(_hostingEnv.WebRootPath, "Content\\images\\profile", uniqueFileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\reading-materials", uniqueFileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.ReadingMaterialDto.Doc.CopyToAsync(fileSteam);
                    }


                }

                ////
                //  DateTime? d = request.TraineeBioDataGeneralInfoDto.DateOfBirth.ConvertToDateTime();

                var ReadingMaterials = _mapper.Map<ReadingMaterial>(request.ReadingMaterialDto);

                ReadingMaterials.DocumentLink = request.ReadingMaterialDto.DocumentLink ?? "files/reading-materials/" + uniqueFileName;



                // var ReadingMaterials = _mapper.Map<ReadingMaterial>(request.ReadingMaterialDto);

                ReadingMaterials = await _unitOfWork.Repository<ReadingMaterial>().Add(ReadingMaterials);
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
                response.Id = ReadingMaterials.ReadingMaterialId;
            }

            return response;
        }
    }
}
