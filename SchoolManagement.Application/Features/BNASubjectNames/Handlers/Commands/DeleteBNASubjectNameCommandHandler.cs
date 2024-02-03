using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading; 
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Handlers.Commands  
{ 
    public class DeleteBnaSubjectNameCommandHandler : IRequestHandler<DeleteBnaSubjectNameCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public DeleteBnaSubjectNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(DeleteBnaSubjectNameCommand request, CancellationToken cancellationToken)
        {  
            var BnaSubjectName = await _unitOfWork.Repository<BnaSubjectName>().Get(request.Id);

            if (BnaSubjectName == null)  
                throw new NotFoundException(nameof(BnaSubjectName), request.Id);
             
            await _unitOfWork.Repository<BnaSubjectName>().Delete(BnaSubjectName); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}