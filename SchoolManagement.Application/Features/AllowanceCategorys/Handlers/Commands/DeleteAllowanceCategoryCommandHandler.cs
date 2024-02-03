using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.AllowanceCategorys.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AllowanceCategorys.Handlers.Commands
{
    public class DeleteAllowanceCategoryCommandHandler : IRequestHandler<DeleteAllowanceCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAllowanceCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAllowanceCategoryCommand request, CancellationToken cancellationToken)
        {
            var AllowanceCategory = await _unitOfWork.Repository<AllowanceCategory>().Get(request.AllowanceCategoryId);

            if (AllowanceCategory == null)
                throw new NotFoundException(nameof(AllowanceCategory), request.AllowanceCategoryId);

            await _unitOfWork.Repository<AllowanceCategory>().Delete(AllowanceCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
