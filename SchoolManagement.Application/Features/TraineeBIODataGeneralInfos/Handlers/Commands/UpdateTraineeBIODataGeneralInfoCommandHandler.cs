using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Commands;
using AutoMapper;
using System.Threading.Tasks;
using System.Threading;
using SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo.Validators;
using SchoolManagement.Domain;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Handlers.Commands
{
    public class UpdateTraineeBioDataGeneralInfoCommandHandler : IRequestHandler<UpdateTraineeBioDataGeneralInfoCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UpdateTraineeBioDataGeneralInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _config = config;
        }

        public async Task<Unit> Handle(UpdateTraineeBioDataGeneralInfoCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTraineeBioDataGeneralInfoDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateTraineeBioDataGeneralInfoDto);

            var apiUrl = _config["ApiUrl"];

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

                   
                }

           
            _mapper.Map(request.CreateTraineeBioDataGeneralInfoDto, TraineeBioDataGeneralInfos);

            //  request.TraineeBioDataGeneralInfoDto.BnaPhotoUrl = request.TraineeBioDataGeneralInfoDto.BnaPhotoUrl ?? TraineeBioDataGeneralInfos.BnaPhotoUrl;


            // TraineeBioDataGeneralInfos.BnaPhotoUrl = request.TraineeBioDataGeneralInfoDto.BnaPhotoUrl ?? "images/profile/" + uniqueFileName;
            if ((request.CreateTraineeBioDataGeneralInfoDto.BnaPhotoUrl != null && request.CreateTraineeBioDataGeneralInfoDto.Image !=null)|| request.CreateTraineeBioDataGeneralInfoDto.BnaPhotoUrl == null && request.CreateTraineeBioDataGeneralInfoDto.Image != null)
            {               
                    TraineeBioDataGeneralInfos.BnaPhotoUrl = request.CreateTraineeBioDataGeneralInfoDto.Image != null ? "images/profile/" + uniqueFileName : TraineeBioDataGeneralInfos.BnaPhotoUrl.Replace(apiUrl, String.Empty);
                           
               
            }           
            else if(request.CreateTraineeBioDataGeneralInfoDto.BnaPhotoUrl != null)
            {
                TraineeBioDataGeneralInfos.BnaPhotoUrl = TraineeBioDataGeneralInfos.BnaPhotoUrl.Replace(apiUrl, string.Empty);
            }
            else
            {
                TraineeBioDataGeneralInfos.BnaPhotoUrl = "";
            }
            TraineeBioDataGeneralInfos.DateOfBirth = request.CreateTraineeBioDataGeneralInfoDto.DateOfBirth ?? null;
            TraineeBioDataGeneralInfos.JoiningDate = request.CreateTraineeBioDataGeneralInfoDto.JoiningDate ?? null;
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
