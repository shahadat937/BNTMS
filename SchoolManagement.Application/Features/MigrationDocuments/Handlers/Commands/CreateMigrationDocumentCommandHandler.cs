using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MigrationDocument.Validators;
using SchoolManagement.Application.Features.MigrationDocuments.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MigrationDocuments.Handlers.Commands
{
    public class CreateMigrationDocumentCommandHandler : IRequestHandler<CreateMigrationDocumentCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public CreateMigrationDocumentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateMigrationDocumentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateMigrationDocumentDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.MigrationDocumentDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var MigrationDocument = _mapper.Map<MigrationDocument>(request.MigrationDocumentDto);

                MigrationDocument = await _unitOfWork.Repository<MigrationDocument>().Add(MigrationDocument);
                await _unitOfWork.Save();
                response.Success = true;
                response.Message = "Creation Successful"; 
                response.Id = MigrationDocument.MigrationDocumentId;
            } 

            return response;
        }
    }
}
