using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.SaylorBranchs.Requests.Commands;
using SchoolManagement.Application.DTOs.SaylorBranch.Validators;

namespace SchoolManagement.Application.Features.SaylorBranchs.Handlers.Commands
{
    public class UpdateSaylorBranchCommandHandler : IRequestHandler<UpdateSaylorBranchCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSaylorBranchCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSaylorBranchCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSaylorBranchDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.SaylorBranchDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var SaylorBranch = await _unitOfWork.Repository<SaylorBranch>().Get(request.SaylorBranchDto.SaylorBranchId);

            if (SaylorBranch is null)
                throw new NotFoundException(nameof(SaylorBranch), request.SaylorBranchDto.SaylorBranchId);

            _mapper.Map(request.SaylorBranchDto, SaylorBranch);

            await _unitOfWork.Repository<SaylorBranch>().Update(SaylorBranch);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
