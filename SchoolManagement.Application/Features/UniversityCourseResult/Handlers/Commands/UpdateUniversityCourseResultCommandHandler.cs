using AutoMapper;
using SchoolManagement.Application.DTOs.UniversityCourseResult.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.UniversityCourseResults.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.UniversityCourseResults.Handlers.Commands
{
    public class UpdateUniversityCourseResultCommandHandler : IRequestHandler<UpdateUniversityCourseResultCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUniversityCourseResultCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUniversityCourseResultCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateUniversityCourseResultDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UniversityCourseResultDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var UniversityCourseResult = await _unitOfWork.Repository<UniversityCourseResult>().Get(request.UniversityCourseResultDto.UniversityCourseResultId);

            if (UniversityCourseResult is null)
                throw new NotFoundException(nameof(UniversityCourseResult), request.UniversityCourseResultDto.UniversityCourseResultId);

            _mapper.Map(request.UniversityCourseResultDto, UniversityCourseResult);

            await _unitOfWork.Repository<UniversityCourseResult>().Update(UniversityCourseResult);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
