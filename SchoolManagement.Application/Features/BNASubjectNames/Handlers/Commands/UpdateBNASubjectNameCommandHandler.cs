using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaSubjectName.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Handlers.Commands
{  
    public class UpdateBnaSubjectNameCommandHandler : IRequestHandler<UpdateBnaSubjectNameCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateBnaSubjectNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(UpdateBnaSubjectNameCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBnaSubjectNameDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.BnaSubjectNameDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);  
             
            var BnaSubjectName = await _unitOfWork.Repository<BnaSubjectName>().Get(request.BnaSubjectNameDto.BnaSubjectNameId); 

            if (BnaSubjectName is null)  
                throw new NotFoundException(nameof(BnaSubjectName), request.BnaSubjectNameDto.BnaSubjectNameId); 

            _mapper.Map(request.BnaSubjectNameDto, BnaSubjectName);  

            await _unitOfWork.Repository<BnaSubjectName>().Update(BnaSubjectName); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}