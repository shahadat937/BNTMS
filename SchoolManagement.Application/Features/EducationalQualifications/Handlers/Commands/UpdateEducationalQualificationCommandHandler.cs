using AutoMapper;
using SchoolManagement.Application.DTOs.EducationalQualification.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.EducationalQualifications.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.EducationalQualifications.Handlers.Commands
{
    public class UpdateEducationalQualificationCommandHandler : IRequestHandler<UpdateEducationalQualificationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEducationalQualificationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEducationalQualificationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateEducationalQualificationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.EducationalQualificationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var EducationalQualification = await _unitOfWork.Repository<EducationalQualification>().Get(request.EducationalQualificationDto.EducationalQualificationId);

            if (EducationalQualification is null)
                throw new NotFoundException(nameof(EducationalQualification), request.EducationalQualificationDto.EducationalQualificationId);

            _mapper.Map(request.EducationalQualificationDto, EducationalQualification);

            await _unitOfWork.Repository<EducationalQualification>().Update(EducationalQualification);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
