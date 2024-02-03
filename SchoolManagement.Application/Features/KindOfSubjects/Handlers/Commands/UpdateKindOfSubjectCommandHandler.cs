using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.KindOfSubjects.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.KindOfSubjects.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading; 
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.KindOfSubjects.Handler.Commands  
{
    public class UpdateKindOfSubjectCommandHandler : IRequestHandler<UpdateKindOfSubjectCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;
         
        public UpdateKindOfSubjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateKindOfSubjectCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateKindOfSubjectDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.KindOfSubjectDto); 

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 

            var KindOfSubject = await _unitOfWork.Repository<KindOfSubject>().Get(request.KindOfSubjectDto.KindOfSubjectId);

            if (KindOfSubject is null)
                throw new NotFoundException(nameof(KindOfSubject), request.KindOfSubjectDto.KindOfSubjectId); 

            _mapper.Map(request.KindOfSubjectDto, KindOfSubject); 

            await _unitOfWork.Repository<KindOfSubject>().Update(KindOfSubject);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}