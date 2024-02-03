using AutoMapper;
using SchoolManagement.Application.DTOs.CourseName.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseNames.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseNames.Handlers.Commands
{
    public class UpdateCourseNameCommandHandler : IRequestHandler<UpdateCourseNameCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCourseNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCourseNameCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCourseNameDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateCourseNameDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var CourseName = await _unitOfWork.Repository<CourseName>().Get(request.CreateCourseNameDto.CourseNameId);

            if (CourseName is null)
                throw new NotFoundException(nameof(CourseName), request.CreateCourseNameDto.CourseNameId);

            /////// File Upload //////////
            ///
            string uniqueFileName = null;

            if (request.CreateCourseNameDto.Doc != null)
            {

                var fileName = Path.GetFileName(request.CreateCourseNameDto.Doc.FileName);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                var a = Directory.GetCurrentDirectory();
                //var filePath = Path.Combine(_hostingEnv.WebRootPath, "Content\\images\\profile", uniqueFileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\reading-materials", uniqueFileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await request.CreateCourseNameDto.Doc.CopyToAsync(fileSteam);
                }

            }

            request.CreateCourseNameDto.CourseSyllabus = request.CreateCourseNameDto.Doc != null ? "files/reading-materials/" + uniqueFileName : CourseName.CourseSyllabus;


            _mapper.Map(request.CreateCourseNameDto, CourseName);

            await _unitOfWork.Repository<CourseName>().Update(CourseName);
            await _unitOfWork.Save();




            //request.CreateDocumentDto.DocumentUpload = request.CreateDocumentDto.Doc != null ? "files/interservice-course-document/" + uniqueFileName : Documents.DocumentUpload;


            //_mapper.Map(request.CreateDocumentDto, Documents);



            //await _unitOfWork.Repository<Document>().Update(Documents);

            return Unit.Value;
        }
    }
}
