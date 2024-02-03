using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.InterServiceCourseDocType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.InterServiceCourseDocTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InterServiceCourseDocTypes.Handlers.Commands
{
    public class UpdateInterServiceCourseDocTypeCommandHandler : IRequestHandler<UpdateInterServiceCourseDocTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateInterServiceCourseDocTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateInterServiceCourseDocTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateInterServiceCourseDocTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.InterServiceCourseDocTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var InterServiceCourseDocType = await _unitOfWork.Repository<InterServiceCourseDocType>().Get(request.InterServiceCourseDocTypeDto.InterServiceCourseDocTypeId);

            if (InterServiceCourseDocType is null)
                throw new NotFoundException(nameof(InterServiceCourseDocType), request.InterServiceCourseDocTypeDto.InterServiceCourseDocTypeId);

            _mapper.Map(request.InterServiceCourseDocTypeDto, InterServiceCourseDocType);

            await _unitOfWork.Repository<InterServiceCourseDocType>().Update(InterServiceCourseDocType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
