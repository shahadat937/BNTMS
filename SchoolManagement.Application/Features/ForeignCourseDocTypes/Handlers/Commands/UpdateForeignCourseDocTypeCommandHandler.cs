using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ForeignCourseDocType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ForeignCourseDocTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForeignCourseDocTypes.Handlers.Commands
{
    public class UpdateForeignCourseDocTypeCommandHandler : IRequestHandler<UpdateForeignCourseDocTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateForeignCourseDocTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateForeignCourseDocTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateForeignCourseDocTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ForeignCourseDocTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ForeignCourseDocType = await _unitOfWork.Repository<ForeignCourseDocType>().Get(request.ForeignCourseDocTypeDto.ForeignCourseDocTypeId);

            if (ForeignCourseDocType is null)
                throw new NotFoundException(nameof(ForeignCourseDocType), request.ForeignCourseDocTypeDto.ForeignCourseDocTypeId);

            _mapper.Map(request.ForeignCourseDocTypeDto, ForeignCourseDocType);

            await _unitOfWork.Repository<ForeignCourseDocType>().Update(ForeignCourseDocType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
