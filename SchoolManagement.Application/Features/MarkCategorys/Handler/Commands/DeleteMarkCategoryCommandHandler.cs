using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MarkCategorys.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MarkCategorys.Handler.Queries
{
    public class DeleteMarkCategoryCommandHandler : IRequestHandler<DeleteMarkCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMarkCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteMarkCategoryCommand request, CancellationToken cancellationToken)
        {
            var MarkCategory = await _unitOfWork.Repository<MarkCategory>().Get(request.Id);

            if (MarkCategory == null)
                throw new NotFoundException(nameof(MarkCategory), request.Id);

            await _unitOfWork.Repository<MarkCategory>().Delete(MarkCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}