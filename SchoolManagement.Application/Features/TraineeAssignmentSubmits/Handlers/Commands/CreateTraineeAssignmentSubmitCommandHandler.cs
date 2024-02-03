using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TraineeAssignmentSubmits.Validators;
using SchoolManagement.Application.Features.TraineeAssignmentSubmits.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TraineeAssignmentSubmits.Handlers.Commands
{
    public class CreateTraineeAssignmentSubmitCommandHandler : IRequestHandler<CreateTraineeAssignmentSubmitCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTraineeAssignmentSubmitCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTraineeAssignmentSubmitCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTraineeAssignmentSubmitDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TraineeAssignmentSubmitDto);

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

                if (request.TraineeAssignmentSubmitDto.Doc != null)
                {

                    var fileName = Path.GetFileName(request.TraineeAssignmentSubmitDto.Doc.FileName);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                    //var filePath = Path.Combine(_hostingEnv.WebRootPath, "Content\\images\\profile", uniqueFileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\trainee-assignments", uniqueFileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.TraineeAssignmentSubmitDto.Doc.CopyToAsync(fileSteam);
                    }


                }

                ////
                //  DateTime? d = request.TraineeBioDataGeneralInfoDto.DateOfBirth.ConvertToDateTime();

                //var ReadingMaterials = _mapper.Map<ReadingMaterial>(request.ReadingMaterialDto);

                //ReadingMaterials.DocumentLink = request.ReadingMaterialDto.DocumentLink ?? "files/reading-materials/" + uniqueFileName;



                // var ReadingMaterials = _mapper.Map<ReadingMaterial>(request.ReadingMaterialDto);

                //ReadingMaterials = await _unitOfWork.Repository<ReadingMaterial>().Add(ReadingMaterials);




                var TraineeAssignmentSubmit = _mapper.Map<TraineeAssignmentSubmit>(request.TraineeAssignmentSubmitDto);
                TraineeAssignmentSubmit.Status = 0;
                TraineeAssignmentSubmit.ImageUpload = request.TraineeAssignmentSubmitDto.ImageUpload ?? "files/trainee-assignments/" + uniqueFileName;

                TraineeAssignmentSubmit = await _unitOfWork.Repository<TraineeAssignmentSubmit>().Add(TraineeAssignmentSubmit);
                try
                {
                    await _unitOfWork.Save();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = TraineeAssignmentSubmit.TraineeAssignmentSubmitId;
            }

            return response;
        }
    }
}
