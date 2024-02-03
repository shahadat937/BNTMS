using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Commands;
using AutoMapper;
using System.Threading.Tasks;
using System.Threading;
using SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo.Validators;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Handlers.Commands
{
    public class UpdateTraineeBioDataGeneralInfoCommandHandler : IRequestHandler<UpdateTraineeBioDataGeneralInfoCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTraineeBioDataGeneralInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTraineeBioDataGeneralInfoCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTraineeBioDataGeneralInfoDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateTraineeBioDataGeneralInfoDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var TraineeBioDataGeneralInfos = await _unitOfWork.Repository<TraineeBioDataGeneralInfo>().Get(request.CreateTraineeBioDataGeneralInfoDto.TraineeId);

            if (TraineeBioDataGeneralInfos is null)
                throw new NotFoundException(nameof(TraineeBioDataGeneralInfo), request.CreateTraineeBioDataGeneralInfoDto.TraineeId);
                
            
                /////// File Upload //////////
                ///
                string uniqueFileName = null;

                if (request.CreateTraineeBioDataGeneralInfoDto.Image != null)
                {

                    var fileName = Path.GetFileName(request.CreateTraineeBioDataGeneralInfoDto.Image.FileName);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                //var filePath = Path.Combine(_hostingEnv.WebRootPath, "Content\\images\\profile", uniqueFileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\images\\profile", uniqueFileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.CreateTraineeBioDataGeneralInfoDto.Image.CopyToAsync(fileSteam);
                    }

                   // request.UpdateTraineeBIODataGeneralInfoDto.BnaPhotoUrl = "images/profile/" + uniqueFileName;
                }

            ////
            //  DateTime? d = request.TraineeBioDataGeneralInfoDto.DateOfBirth.ConvertToDateTime();



           
            _mapper.Map(request.CreateTraineeBioDataGeneralInfoDto, TraineeBioDataGeneralInfos);

          //  request.TraineeBioDataGeneralInfoDto.BnaPhotoUrl = request.TraineeBioDataGeneralInfoDto.BnaPhotoUrl ?? TraineeBioDataGeneralInfos.BnaPhotoUrl;


           // TraineeBioDataGeneralInfos.BnaPhotoUrl = request.TraineeBioDataGeneralInfoDto.BnaPhotoUrl ?? "images/profile/" + uniqueFileName;
            TraineeBioDataGeneralInfos.BnaPhotoUrl = request.CreateTraineeBioDataGeneralInfoDto.Image != null ? "images/profile/" + uniqueFileName : TraineeBioDataGeneralInfos.BnaPhotoUrl.Replace("https://localhost:44395/Content/",String.Empty);


            await _unitOfWork.Repository<TraineeBioDataGeneralInfo>().Update(TraineeBioDataGeneralInfos);
            try
            {
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            

            return Unit.Value;
        }
    }
}
