using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaClassTests.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BnaClassTests.Handlers.Commands
{
    public class DeleteBnaClassTestCommandHandler: IRequestHandler<DeleteBnaClassTestCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBnaClassTestCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBnaClassTestCommand request, CancellationToken cancellationToken)
        {
            var BnaClassTest = await _unitOfWork.Repository<BnaClassTest>().Get(request.BnaClassTestId);

            if (BnaClassTest == null)
                throw new NotFoundException(nameof(BnaClassTest), request.BnaClassTestId);

            await _unitOfWork.Repository<BnaClassTest>().Delete(BnaClassTest);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
 