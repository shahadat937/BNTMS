using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeCourseStatuses.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeCourseStatuses.Handlers.Commands
{
    public class DeleteTraineeCourseStatusCommandHandler : IRequestHandler<DeleteTraineeCourseStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public DeleteTraineeCourseStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(DeleteTraineeCourseStatusCommand request, CancellationToken cancellationToken)
        {  
            var TraineeCourseStatus = await _unitOfWork.Repository<TraineeCourseStatus>().Get(request.Id);

            if (TraineeCourseStatus == null)  
                throw new NotFoundException(nameof(TraineeCourseStatus), request.Id);
             
            await _unitOfWork.Repository<TraineeCourseStatus>().Delete(TraineeCourseStatus); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}