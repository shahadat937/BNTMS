using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.InstallmentPaidDetails.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InstallmentPaidDetails.Handler.Commands
{
    public class DeleteInstallmentPaidDetailCommandHandler : IRequestHandler<DeleteInstallmentPaidDetailCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public DeleteInstallmentPaidDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork; 
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteInstallmentPaidDetailCommand request, CancellationToken cancellationToken)
        {
            var InstallmentPaidDetail = await _unitOfWork.Repository<InstallmentPaidDetail>().Get(request.Id);
             
            if (InstallmentPaidDetail == null)
                throw new NotFoundException(nameof(InstallmentPaidDetail), request.Id);

            await _unitOfWork.Repository<InstallmentPaidDetail>().Delete(InstallmentPaidDetail); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}