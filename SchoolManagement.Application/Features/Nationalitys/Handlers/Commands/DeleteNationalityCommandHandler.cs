using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Nationalitys.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Nationalitys.Handlers.Commands
{
    public class DeleteNationalityCommandHandler : IRequestHandler<DeleteNationalityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteNationalityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteNationalityCommand request, CancellationToken cancellationToken)
        {
            var Nationality = await _unitOfWork.Repository<Nationality>().Get(request.NationalityId);

            if (Nationality == null)
                throw new NotFoundException(nameof(Nationality), request.NationalityId);

            await _unitOfWork.Repository<Nationality>().Delete(Nationality);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
