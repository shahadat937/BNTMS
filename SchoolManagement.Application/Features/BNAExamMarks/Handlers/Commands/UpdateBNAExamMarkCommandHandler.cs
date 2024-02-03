using AutoMapper;
using SchoolManagement.Application.DTOs.BnaExamMark.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaExamMarks.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaExamMarks.Handlers.Commands
{
    public class UpdateBnaExamMarkCommandHandler : IRequestHandler<UpdateBnaExamMarkCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBnaExamMarkCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBnaExamMarkCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBnaExamMarkDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaExamMarkDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BnaExamMarks = await _unitOfWork.Repository<BnaExamMark>().Get(request.BnaExamMarkDto.BnaExamMarkId);

            if (BnaExamMarks is null)
                throw new NotFoundException(nameof(BnaExamMark), request.BnaExamMarkDto.BnaExamMarkId);

            _mapper.Map(request.BnaExamMarkDto, BnaExamMarks);

            await _unitOfWork.Repository<BnaExamMark>().Update(BnaExamMarks);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
