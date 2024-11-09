using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.OnlineLibrary.Validators;
using SchoolManagement.Application.DTOs.ReadingMaterial.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.OnlineLibrary.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OnlineLibrary.Handlers.Commands
{
    public class UpdateOnlineLibraryRequestHandler : IRequestHandler<UpdateOnlineLibraryRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateOnlineLibraryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateOnlineLibraryRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateOnlineLibraryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateOnlineLibraryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var libraryMaterials = await _unitOfWork.Repository<SchoolManagement.Domain.OnlineLibrary>().Get(request.CreateOnlineLibraryDto.OnlineLibraryId);

            if (libraryMaterials is null)
                throw new NotFoundException(nameof(ReadingMaterial), request.CreateOnlineLibraryDto.OnlineLibraryId);

            /////// File Upload //////////
            ///
            string uniqueFileName = null;

            if (request.CreateOnlineLibraryDto.Doc != null)
            {

                var fileName = Path.GetFileName(request.CreateOnlineLibraryDto.Doc.FileName);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                var a = Directory.GetCurrentDirectory();
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\online-library", uniqueFileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await request.CreateOnlineLibraryDto.Doc.CopyToAsync(fileSteam);
                }

            }

            _mapper.Map(request.CreateOnlineLibraryDto, libraryMaterials);
           
            libraryMaterials.DocumentLink = request.CreateOnlineLibraryDto.Doc != null ? "files/online-library/" + uniqueFileName : libraryMaterials.DocumentLink.Replace("https://localhost:44395/Content/", String.Empty);


            await _unitOfWork.Repository<SchoolManagement.Domain.OnlineLibrary>().Update(libraryMaterials);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
