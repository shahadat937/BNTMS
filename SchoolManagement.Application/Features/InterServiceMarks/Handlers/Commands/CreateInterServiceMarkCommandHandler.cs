using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.InterServiceMark.Validators;
using SchoolManagement.Application.Features.InterServiceMarks.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InterServiceMarks.Handlers.Commands
{
    public class CreateInterServiceMarkCommandHandler : IRequestHandler<CreateInterServiceMarkCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateInterServiceMarkCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateInterServiceMarkCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateInterServiceMarkDtoValidator();
            var validationResult = await validator.ValidateAsync(request.InterServiceMarkDto);

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

                if (request.InterServiceMarkDto.document != null)
                {

                    var fileName = Path.GetFileName(request.InterServiceMarkDto.document.FileName);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;

                    //var filePath = Path.Combine(_hostingEnv.WebRootPath, "Content\\images\\profile", uniqueFileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\inter-service-mark", uniqueFileName);

                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.InterServiceMarkDto.document.CopyToAsync(fileSteam);
                    }


                }

                ////
                //  DateTime? d = request.TraineeBioDataGeneralInfoDto.DateOfBirth.ConvertToDateTime();               
                                
                var InterServiceMark = _mapper.Map<InterServiceMark>(request.InterServiceMarkDto);

                InterServiceMark.Doc = request.InterServiceMarkDto.Doc ?? "files/inter-service-mark/" + uniqueFileName;

                InterServiceMark = await _unitOfWork.Repository<InterServiceMark>().Add(InterServiceMark);
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
                response.Id = InterServiceMark.InterServiceMarkId;
            }

            return response;
        }
    }
}
