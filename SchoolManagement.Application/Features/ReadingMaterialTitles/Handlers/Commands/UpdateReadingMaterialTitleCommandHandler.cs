using AutoMapper;
using SchoolManagement.Application.DTOs.ReadingMaterialTitle.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ReadingMaterialTitles.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;

namespace SchoolManagement.Application.Features.ReadingMaterialTitles.Handlers.Commands
{
    public class UpdateReadingMaterialTitleCommandHandler : IRequestHandler<UpdateReadingMaterialTitleCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateReadingMaterialTitleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateReadingMaterialTitleCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateReadingMaterialTitleDtoValidator();
            //var validationResult = await validator.ValidateAsync(request.ReadingMaterialTitleDto);

            //if (validationResult.IsValid == false)
            //    throw new ValidationException(validationResult);

            var ReadingMaterialTitle = await _unitOfWork.Repository<ReadingMaterialTitle>().Get(request.ReadingMaterialTitleDto.ReadingMaterialTitleId);

            if (ReadingMaterialTitle is null)
                throw new NotFoundException(nameof(ReadingMaterialTitle), request.ReadingMaterialTitleDto.ReadingMaterialTitleId);

            _mapper.Map(request.ReadingMaterialTitleDto, ReadingMaterialTitle);

            await _unitOfWork.Repository<ReadingMaterialTitle>().Update(ReadingMaterialTitle);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
