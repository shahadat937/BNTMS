using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Genders.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Genders.Handlers.Commands
{
    public class DeleteGenderCommandHandler : IRequestHandler<DeleteGenderCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteGenderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteGenderCommand request, CancellationToken cancellationToken)
        {
            var Gender = await _unitOfWork.Repository<Gender>().Get(request.GenderId);

            if (Gender == null)
                throw new NotFoundException(nameof(Gender), request.GenderId);

            await _unitOfWork.Repository<Gender>().Delete(Gender);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
