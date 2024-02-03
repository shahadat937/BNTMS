using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.WithdrawnDoc.Validators;
using SchoolManagement.Application.Features.WithdrawnDocs.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.WithdrawnDocs.Handlers.Commands
{
    public class CreateWithdrawnDocCommandHandler : IRequestHandler<CreateWithdrawnDocsCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public CreateWithdrawnDocCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateWithdrawnDocsCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateWithdrawnDocDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.WithdrawnDocDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var WithdrawnDoc = _mapper.Map<WithdrawnDoc>(request.WithdrawnDocDto); 

                WithdrawnDoc = await _unitOfWork.Repository<WithdrawnDoc>().Add(WithdrawnDoc);
                await _unitOfWork.Save();
                response.Success = true;
                response.Message = "Creation Successful"; 
                response.Id = WithdrawnDoc.WithdrawnDocId;
            }

            return response;
        }
    }
}
