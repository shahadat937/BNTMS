using System;
using MediatR;
using AutoMapper;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Domain;
using SchoolManagement.Application.Responses;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo.Validators;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Commands;


namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Handlers.Commands
{
    public class CreateTraineeBioDataGeneralInfoCommandHandler : IRequestHandler<CreateTraineeBioDataGeneralInfoCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTraineeBioDataGeneralInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
          
        }

        public async Task<BaseCommandResponse> Handle(CreateTraineeBioDataGeneralInfoCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTraineeBioDataGeneralInfoDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TraineeBioDataGeneralInfoDto);

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

                if (request.TraineeBioDataGeneralInfoDto.Image != null)
                {

                    var fileName = Path.GetFileName(request.TraineeBioDataGeneralInfoDto.Image.FileName);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    
                    //var filePath = Path.Combine(_hostingEnv.WebRootPath, "Content\\images\\profile", uniqueFileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\images\\profile", uniqueFileName);

                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.TraineeBioDataGeneralInfoDto.Image.CopyToAsync(fileSteam);
                    }


                }

                ////
                //  DateTime? d = request.TraineeBioDataGeneralInfoDto.DateOfBirth.ConvertToDateTime();

                var TraineeBioDataGeneralInfo = _mapper.Map<TraineeBioDataGeneralInfo>(request.TraineeBioDataGeneralInfoDto);

                TraineeBioDataGeneralInfo.BnaPhotoUrl = request.TraineeBioDataGeneralInfoDto.BnaPhotoUrl ?? "images/profile/" + uniqueFileName;

                TraineeBioDataGeneralInfo = await _unitOfWork.Repository<TraineeBioDataGeneralInfo>().Add(TraineeBioDataGeneralInfo);
                TraineeBioDataGeneralInfo.LocalNominationStatus = 0;
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
                response.Id = TraineeBioDataGeneralInfo.TraineeId;
            }

            return response;
        }
    }
}
