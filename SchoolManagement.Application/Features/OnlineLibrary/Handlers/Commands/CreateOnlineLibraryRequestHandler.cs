using AutoMapper;
using FluentValidation;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.OnlineLibrary.Validators;
using SchoolManagement.Application.DTOs.ReadingMaterial.Validators;
using SchoolManagement.Application.Features.OnlineLibrary.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OnlineLibrary.Handlers.Commands
{
    public class CreateOnlineLibraryRequestHandler : IRequestHandler<CreateOnlineLibraryRequest, BaseCommandResponse >
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateOnlineLibraryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }

        public async Task<BaseCommandResponse> Handle(CreateOnlineLibraryRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateOnlineLibraryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.OnlineLibraryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                /////// File Upload //////////
                
                string uniqueFileName = null;

                if (request.OnlineLibraryDto.Doc != null)
                {

                    var fileName = Path.GetFileName(request.OnlineLibraryDto.Doc.FileName);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();                  
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\online-library", uniqueFileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.OnlineLibraryDto.Doc.CopyToAsync(fileSteam);
                    }


                }


                var onlineLibraryMaterials = _mapper.Map<SchoolManagement.Domain.OnlineLibrary>(request.OnlineLibraryDto);

                onlineLibraryMaterials.DocumentLink = request.OnlineLibraryDto.DocumentLink ?? "files/online-library/" + uniqueFileName;

                onlineLibraryMaterials = await _unitOfWork.Repository<SchoolManagement.Domain.OnlineLibrary>().Add(onlineLibraryMaterials);
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
                response.Id = onlineLibraryMaterials.OnlineLibraryId;
            }

            return response;
        }
    }
}
