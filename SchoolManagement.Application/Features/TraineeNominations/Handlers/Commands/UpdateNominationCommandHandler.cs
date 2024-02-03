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
using SchoolManagement.Application.DTOs.TraineeNomination.Validators;

namespace SchoolManagement.Application.Features.ReadingMaterials.Handlers.Commands
{
    public class UpdateNominationCommandHandler : IRequestHandler<UpdateNominationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateNominationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateNominationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateReligationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TraineeReligationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var TraineeNominations = await _unitOfWork.Repository<TraineeNomination>().Get(request.TraineeReligationDto.TraineeNominationId);
                /////// File Upload //////////
                ///
                string uniqueFileName = null;

                if (request.TraineeReligationDto.Doc != null)
                {

                    var fileName = Path.GetFileName(request.TraineeReligationDto.Doc.FileName);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                    //var filePath = Path.Combine(_hostingEnv.WebRootPath, "Content\\images\\profile", uniqueFileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\religation-doc", uniqueFileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.TraineeReligationDto.Doc.CopyToAsync(fileSteam);
                    }


                }

                ////
                //  DateTime? d = request.TraineeBioDataGeneralInfoDto.DateOfBirth.ConvertToDateTime();

                //   var TraineeNomination = _mapper.Map<TraineeNomination>(request.TraineeReligationDto);

                TraineeNominations.WithdrawnDocs = request.TraineeReligationDto.WithdrawnDocs ?? "files/religation-doc/" + uniqueFileName;
                TraineeNominations.WithdrawnRemarks = request.TraineeReligationDto.WithdrawnRemarks;
                TraineeNominations.WithdrawnDate = request.TraineeReligationDto.WithdrawnDate;
                TraineeNominations.WithdrawnTypeId = request.TraineeReligationDto.WithdrawnTypeId;


            // var ReadingMaterials = _mapper.Map<ReadingMaterial>(request.ReadingMaterialDto);

                 await _unitOfWork.Repository<TraineeNomination>().Update(TraineeNominations);
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
                //response.Id = ReadingMaterials.ReadingMaterialId;
            }

           return Unit.Value; 
        }
    }
}
