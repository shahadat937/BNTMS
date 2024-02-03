using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Commands;
using AutoMapper;
using System.Threading.Tasks;
using System.Threading;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Handlers.Commands
{
    public class DeleteTraineeBioDataGeneralInfoCommandHandler : IRequestHandler<DeleteTraineeBioDataGeneralInfoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTraineeBioDataGeneralInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTraineeBioDataGeneralInfoCommand request, CancellationToken cancellationToken)
        {
            var TraineeBioDataGeneralInfo = await _unitOfWork.Repository<TraineeBioDataGeneralInfo>().Get(request.TraineeId);

            if (TraineeBioDataGeneralInfo == null)
                throw new NotFoundException(nameof(TraineeBioDataGeneralInfo), request.TraineeId);
            
                await _unitOfWork.Repository<TraineeBioDataGeneralInfo>().Delete(TraineeBioDataGeneralInfo);
                await _unitOfWork.Save();
            
            

            return Unit.Value;
        }
    }
}
