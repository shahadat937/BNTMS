using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Document.Validators;
using SchoolManagement.Application.Features.Documents.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Documents.Handlers.Commands
{
    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDocumentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDocumentDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DocumentDto);

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

                if (request.DocumentDto.Doc != null)
                {

                    var fileName = Path.GetFileName(request.DocumentDto.Doc.FileName);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\interservice-course-document", uniqueFileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.DocumentDto.Doc.CopyToAsync(fileSteam);
                    }


                }
                var Document = _mapper.Map<Document>(request.DocumentDto);

                Document.DocumentUpload = request.DocumentDto.DocumentUpload ?? "files/interservice-course-document/" + uniqueFileName;
                //ForeignCourseGOInfo.Status = 0;
                Document = await _unitOfWork.Repository<Document>().Add(Document);
                await _unitOfWork.Save();


                //var Document = _mapper.Map<Document>(request.DocumentDto);

                //Document = await _unitOfWork.Repository<Document>().Add(Document);
               
                //await _unitOfWork.Save();
                

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Document.DocumentId;
            }

            return response;
        }
    }
}
