using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CountryGroups.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CountryGroups.Handlers.Commands
{
    public class DeleteCountryGroupCommandHandler : IRequestHandler<DeleteCountryGroupCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCountryGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCountryGroupCommand request, CancellationToken cancellationToken)
        {
            var CountryGroup = await _unitOfWork.Repository<CountryGroup>().Get(request.CountryGroupId);

            if (CountryGroup == null)
                throw new NotFoundException(nameof(CountryGroup), request.CountryGroupId);

            await _unitOfWork.Repository<CountryGroup>().Delete(CountryGroup);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
