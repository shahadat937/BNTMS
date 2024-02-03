using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Languages.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Languages.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Languages.Handlers.Commands
{
    public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateLanguageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLanguageDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.LanguageDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 
             
            var Language = await _unitOfWork.Repository<Language>().Get(request.LanguageDto.LanguageId); 

            if (Language is null)  
                throw new NotFoundException(nameof(Language), request.LanguageDto.LanguageId); 

            _mapper.Map(request.LanguageDto, Language);  

            await _unitOfWork.Repository<Language>().Update(Language); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}