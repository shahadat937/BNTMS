using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.FamilyInfos.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FamilyInfos.Handlers.Commands
{
    public class DeleteFamilyInfoCommandHandler : IRequestHandler<DeleteFamilyInfoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteFamilyInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteFamilyInfoCommand request, CancellationToken cancellationToken)
        {
            var FamilyInfo = await _unitOfWork.Repository<FamilyInfo>().Get(request.FamilyInfoId);

            if (FamilyInfo == null)
                throw new NotFoundException(nameof(FamilyInfo), request.FamilyInfoId);

            await _unitOfWork.Repository<FamilyInfo>().Delete(FamilyInfo);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
