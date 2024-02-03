using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaSemesterDurations.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaSemesterDurations.Handlers.Commands  
{ 
    public class DeleteBnaSemesterDurationCommandHandler : IRequestHandler<DeleteBnaSemesterDurationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public DeleteBnaSemesterDurationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(DeleteBnaSemesterDurationCommand request, CancellationToken cancellationToken)
        {  
            var BnaSemesterDuration = await _unitOfWork.Repository<BnaSemesterDuration>().Get(request.Id);

            if (BnaSemesterDuration == null)  
                throw new NotFoundException(nameof(BnaSemesterDuration), request.Id);
             
            await _unitOfWork.Repository<BnaSemesterDuration>().Delete(BnaSemesterDuration); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}