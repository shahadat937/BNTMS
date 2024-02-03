using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.SubjectTypes.Requests.Commands;
using SchoolManagement.Application.DTOs.SubjectTypes.Validators;

namespace SchoolManagement.Application.Features.SubjectTypes.Handlers.Commands
{
    public class UpdateSubjectTypeCommandHandler : IRequestHandler<UpdateSubjectTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSubjectTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSubjectTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSubjectTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.SubjectTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var SubjectType = await _unitOfWork.Repository<SubjectType>().Get(request.SubjectTypeDto.SubjectTypeId);

            if (SubjectType is null)
                throw new NotFoundException(nameof(SubjectType), request.SubjectTypeDto.SubjectTypeId);

            _mapper.Map(request.SubjectTypeDto, SubjectType);

            await _unitOfWork.Repository<SubjectType>().Update(SubjectType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
