using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SubjectMark.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.SubjectMarks.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.SubjectMarks.Handler.Queries
{
    public class UpdateSubjectMarkCommandHandler : IRequestHandler<UpdateSubjectMarkCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSubjectMarkCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSubjectMarkCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSubjectMarkDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SubjectMarkDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var SubjectMark = await _unitOfWork.Repository<SubjectMark>().Get(request.SubjectMarkDto.SubjectMarkId);

            if (SubjectMark is null)
                throw new NotFoundException(nameof(SubjectMark), request.SubjectMarkDto.SubjectMarkId);

            _mapper.Map(request.SubjectMarkDto, SubjectMark);

            await _unitOfWork.Repository<SubjectMark>().Update(SubjectMark);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}