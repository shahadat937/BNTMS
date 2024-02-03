using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.BnaSubjectCurriculums.Requests.Commands;
using SchoolManagement.Application.DTOs.BnaSubjectCurriculums.Validators;

namespace SchoolManagement.Application.Features.BnaSubjectCurriculums.Handlers.Commands
{
    public class UpdateBnaSubjectCurriculumCommandHandler : IRequestHandler<UpdateBnaSubjectCurriculumCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBnaSubjectCurriculumCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBnaSubjectCurriculumCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBnaSubjectCurriculumDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.BnaSubjectCurriculumDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BnaSubjectCurriculum = await _unitOfWork.Repository<BnaSubjectCurriculum>().Get(request.BnaSubjectCurriculumDto.BnaSubjectCurriculumId);

            if (BnaSubjectCurriculum is null)
                throw new NotFoundException(nameof(BnaSubjectCurriculum), request.BnaSubjectCurriculumDto.BnaSubjectCurriculumId);

            _mapper.Map(request.BnaSubjectCurriculumDto, BnaSubjectCurriculum);

            await _unitOfWork.Repository<BnaSubjectCurriculum>().Update(BnaSubjectCurriculum);
            await _unitOfWork.Save();

            return Unit.Value;
        } 
    }
}
