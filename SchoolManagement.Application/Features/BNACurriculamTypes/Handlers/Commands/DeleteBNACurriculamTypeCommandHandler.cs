using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaCurriculamTypes.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaCurriculamTypes.Handlers.Commands
{
    public class DeleteBnaCurriculamTypeCommandHandler : IRequestHandler<DeleteBnaCurriculamTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBnaCurriculamTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBnaCurriculamTypeCommand request, CancellationToken cancellationToken)
        {
            var BnaCurriculamType = await _unitOfWork.Repository<BnaCurriculumType>().Get(request.BnaCurriculamTypeId);

            if (BnaCurriculamType == null)
                throw new NotFoundException(nameof(BnaCurriculamType), request.BnaCurriculamTypeId);

            await _unitOfWork.Repository<BnaCurriculumType>().Delete(BnaCurriculamType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
