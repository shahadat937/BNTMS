using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.KindOfSubjects.Validators;
using SchoolManagement.Application.Features.KindOfSubjects.Requests.Commands;
using SchoolManagement.Application.Responses; 
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks; 

namespace SchoolManagement.Application.Features.KindOfSubjects.Handler.Commands
{
    public class CreateKindOfSubjectCommandHandler : IRequestHandler<CreateKindOfSubjectCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
          
        public CreateKindOfSubjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper; 
        }
        public async Task<BaseCommandResponse> Handle(CreateKindOfSubjectCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateKindOfSubjectDtoValidator();
            var validationResult = await validator.ValidateAsync(request.KindOfSubjectDto); 

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var KindOfSubject = _mapper.Map<KindOfSubject>(request.KindOfSubjectDto); 

                KindOfSubject = await _unitOfWork.Repository<KindOfSubject>().Add(KindOfSubject);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = KindOfSubject.KindOfSubjectId;
            }

            return response;
        }
    }
}
