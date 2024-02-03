using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ForeignCourseGOInfo.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ForeignCourseGOInfos.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForeignCourseGOInfos.Handlers.Commands
{
    public class UpdateForeignCourseGOInfoCommandHandler : IRequestHandler<UpdateForeignCourseGOInfoCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateForeignCourseGOInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateForeignCourseGOInfoCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateForeignCourseGOInfoDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.CreateForeignCourseGOInfoDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ForeignCourseGOInfo = await _unitOfWork.Repository<ForeignCourseGOInfo>().Get(request.CreateForeignCourseGOInfoDto.ForeignCourseGOInfoId);

            if (ForeignCourseGOInfo is null)
                throw new NotFoundException(nameof(ForeignCourseGOInfo), request.CreateForeignCourseGOInfoDto.ForeignCourseGOInfoId);

            /////// File Upload //////////
            
            string uniqueFileName = null;

            if (request.CreateForeignCourseGOInfoDto.Doc != null)
            {

                var fileName = Path.GetFileName(request.CreateForeignCourseGOInfoDto.Doc.FileName);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                var a = Directory.GetCurrentDirectory();
                //var filePath = Path.Combine(_hostingEnv.WebRootPath, "Content\\images\\profile", uniqueFileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\reading-materials", uniqueFileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await request.CreateForeignCourseGOInfoDto.Doc.CopyToAsync(fileSteam);
                }

            }
            _mapper.Map(request.CreateForeignCourseGOInfoDto, ForeignCourseGOInfo);

            ForeignCourseGOInfo.FileUpload = request.CreateForeignCourseGOInfoDto.Doc != null ? "files/reading-materials/" + uniqueFileName : ForeignCourseGOInfo.FileUpload.Replace("https://localhost:44395/Content/", String.Empty);
            await _unitOfWork.Repository<ForeignCourseGOInfo>().Update(ForeignCourseGOInfo);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
