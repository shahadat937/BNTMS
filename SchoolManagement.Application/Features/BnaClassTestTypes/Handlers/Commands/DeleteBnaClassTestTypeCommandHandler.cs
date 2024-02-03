using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaClassTestTypes.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BnaClassTestTypes.Handlers.Commands
{
    public class DeleteBnaClassTestTypeCommandHandler: IRequestHandler<DeleteBnaClassTestTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBnaClassTestTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBnaClassTestTypeCommand request, CancellationToken cancellationToken)
        {
            var BnaClassTestType = await _unitOfWork.Repository<BnaClassTestType>().Get(request.BnaClassTestTypeId);

            if (BnaClassTestType == null)
                throw new NotFoundException(nameof(BnaClassTestType), request.BnaClassTestTypeId);

            await _unitOfWork.Repository<BnaClassTestType>().Delete(BnaClassTestType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
 