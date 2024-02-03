using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.DTOs.ExamPeriodTypes.Validators;
using SchoolManagement.Application.Features.ExamPeriodTypes.Requests.Commands;

namespace SchoolManagement.Application.Features.ExamPeriodTypes.Handlers.Commands
{
    public class UpdateExamPeriodTypeCommandHandler : IRequestHandler<UpdateExamPeriodTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateExamPeriodTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateExamPeriodTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateExamPeriodTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ExamPeriodTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ExamPeriodType = await _unitOfWork.Repository<ExamPeriodType>().Get(request.ExamPeriodTypeDto.ExamPeriodTypeId);

            if (ExamPeriodType is null)
                throw new NotFoundException(nameof(ExamPeriodType), request.ExamPeriodTypeDto.ExamPeriodTypeId);

            _mapper.Map(request.ExamPeriodTypeDto, ExamPeriodType);

            await _unitOfWork.Repository<ExamPeriodType>().Update(ExamPeriodType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
