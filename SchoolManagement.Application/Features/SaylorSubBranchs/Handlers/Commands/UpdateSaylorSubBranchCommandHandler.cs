using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.SaylorSubBranchs.Requests.Commands;
using SchoolManagement.Application.DTOs.SaylorSubBranch.Validators;

namespace SchoolManagement.Application.Features.SaylorSubBranchs.Handlers.Commands
{
    public class UpdateSaylorSubBranchCommandHandler : IRequestHandler<UpdateSaylorSubBranchCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSaylorSubBranchCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSaylorSubBranchCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSaylorSubBranchDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.SaylorSubBranchDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var SaylorSubBranch = await _unitOfWork.Repository<SaylorSubBranch>().Get(request.SaylorSubBranchDto.SaylorSubBranchId);

            if (SaylorSubBranch is null)
                throw new NotFoundException(nameof(SaylorSubBranch), request.SaylorSubBranchDto.SaylorSubBranchId);

            _mapper.Map(request.SaylorSubBranchDto, SaylorSubBranch);

            await _unitOfWork.Repository<SaylorSubBranch>().Update(SaylorSubBranch);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
