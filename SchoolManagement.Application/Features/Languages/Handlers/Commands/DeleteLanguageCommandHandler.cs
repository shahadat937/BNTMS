using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Languages.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Languages.Handlers.Commands
{
    public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public DeleteLanguageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
        {  
            var Language = await _unitOfWork.Repository<Language>().Get(request.Id);

            if (Language == null)  
                throw new NotFoundException(nameof(Language), request.Id);
             
            await _unitOfWork.Repository<Language>().Delete(Language); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}