using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ForeignCourseOthersDocument.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Handlers.Commands
{
    public class UpdateForeignCourseOthersDocumentCommandHandler : IRequestHandler<UpdateForeignCourseOthersDocumentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateForeignCourseOthersDocumentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateForeignCourseOthersDocumentCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateForeignCourseOthersDocumentDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ForeignCourseOthersDocumentDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ForeignCourseOthersDocument = await _unitOfWork.Repository<ForeignCourseOthersDocument>().Get(request.ForeignCourseOthersDocumentDto.ForeignCourseOthersDocumentId);

            if (ForeignCourseOthersDocument is null)
                throw new NotFoundException(nameof(ForeignCourseOthersDocument), request.ForeignCourseOthersDocumentDto.ForeignCourseOthersDocumentId);

            _mapper.Map(request.ForeignCourseOthersDocumentDto, ForeignCourseOthersDocument);

            await _unitOfWork.Repository<ForeignCourseOthersDocument>().Update(ForeignCourseOthersDocument);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
