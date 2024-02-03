using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.BnaExamInstructorAssign.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaExamInstructorAssigns.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaExamInstructorAssigns.Handlers.Commands
{
    public class UpdateBnaExamInstructorAssignCommandHandler : IRequestHandler<UpdateBnaExamInstructorAssignCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBnaExamInstructorAssignCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBnaExamInstructorAssignCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBnaExamInstructorAssignDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.BnaExamInstructorAssignDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BnaExamInstructorAssign = await _unitOfWork.Repository<BnaExamInstructorAssign>().Get(request.BnaExamInstructorAssignDto.BnaExamInstructorAssignId);

            if (BnaExamInstructorAssign is null)
                throw new NotFoundException(nameof(BnaExamInstructorAssign), request.BnaExamInstructorAssignDto.BnaExamInstructorAssignId);

            _mapper.Map(request.BnaExamInstructorAssignDto, BnaExamInstructorAssign);

            await _unitOfWork.Repository<BnaExamInstructorAssign>().Update(BnaExamInstructorAssign);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
