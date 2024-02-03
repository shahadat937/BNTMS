using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.SubjectClassifications.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.DTOs.SubjectClassifications.Validators;

namespace SchoolManagement.Application.Features.SubjectClassifications.Handlers.Commands
{
    public class UpdateSubjectClassificationCommandHandler : IRequestHandler<UpdateSubjectClassificationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSubjectClassificationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSubjectClassificationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSubjectClassificationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SubjectClassificationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var SubjectClassification = await _unitOfWork.Repository<SubjectClassification>().Get(request.SubjectClassificationDto.SubjectClassificationId);

            if (SubjectClassification is null)
                throw new NotFoundException(nameof(SubjectClassification), request.SubjectClassificationDto.SubjectClassificationId);

            _mapper.Map(request.SubjectClassificationDto, SubjectClassification);

            await _unitOfWork.Repository<SubjectClassification>().Update(SubjectClassification);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
