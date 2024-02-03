using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MarkTypes.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MarkTypes.Handler.Queries
{
    public class DeleteMarkTypeCommandHandler : IRequestHandler<DeleteMarkTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMarkTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteMarkTypeCommand request, CancellationToken cancellationToken)
        {
            var MarkType = await _unitOfWork.Repository<MarkType>().Get(request.Id);

            if (MarkType == null)
                throw new NotFoundException(nameof(MarkType), request.Id);

            await _unitOfWork.Repository<MarkType>().Delete(MarkType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}