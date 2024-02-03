using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.KindOfSubjects.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;
 
namespace SchoolManagement.Application.Features.KindOfSubjects.Handler.Commands
{ 
    public class DeleteKindOfSubjectCommandHandler : IRequestHandler<DeleteKindOfSubjectCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public DeleteKindOfSubjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork; 
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteKindOfSubjectCommand request, CancellationToken cancellationToken)
        {
            var KindOfSubject = await _unitOfWork.Repository<KindOfSubject>().Get(request.Id);
             
            if (KindOfSubject == null)
                throw new NotFoundException(nameof(KindOfSubject), request.Id);

            await _unitOfWork.Repository<KindOfSubject>().Delete(KindOfSubject); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}