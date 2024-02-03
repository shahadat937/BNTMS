using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.Document.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Documents.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Documents.Handlers.Commands
{
    public class UpdateDocumentCommandHandler : IRequestHandler<UpdateDocumentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDocumentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDocumentDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.CreateDocumentDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Documents = await _unitOfWork.Repository<Document>().Get(request.CreateDocumentDto.DocumentId);

            if (Documents is null)
                throw new NotFoundException(nameof(Documents), request.CreateDocumentDto.DocumentId);

            /////// File Upload //////////
            ///
            string uniqueFileName = null;

            if (request.CreateDocumentDto.Doc != null)
            {

                var fileName = Path.GetFileName(request.CreateDocumentDto.Doc.FileName);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                var a = Directory.GetCurrentDirectory();
                //var filePath = Path.Combine(_hostingEnv.WebRootPath, "Content\\images\\profile", uniqueFileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\images\\profile", uniqueFileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await request.CreateDocumentDto.Doc.CopyToAsync(fileSteam);
                }

                // request.UpdateTraineeBIODataGeneralInfoDto.BnaPhotoUrl = "images/profile/" + uniqueFileName;
            }

            

            request.CreateDocumentDto.DocumentUpload = request.CreateDocumentDto.Doc != null ? "files/interservice-course-document/" + uniqueFileName : Documents.DocumentUpload;


            _mapper.Map(request.CreateDocumentDto, Documents);

            

            await _unitOfWork.Repository<Document>().Update(Documents);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
