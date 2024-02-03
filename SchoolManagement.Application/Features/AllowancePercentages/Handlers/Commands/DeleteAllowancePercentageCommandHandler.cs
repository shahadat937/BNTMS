using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.AllowancePercentages.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AllowancePercentages.Handlers.Commands
{
    public class DeleteAllowancePercentageCommandHandler : IRequestHandler<DeleteAllowancePercentageCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAllowancePercentageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAllowancePercentageCommand request, CancellationToken cancellationToken)
        {
            var AllowancePercentage = await _unitOfWork.Repository<AllowancePercentage>().Get(request.AllowancePercentageId);

            if (AllowancePercentage == null)
                throw new NotFoundException(nameof(AllowancePercentage), request.AllowancePercentageId);

            await _unitOfWork.Repository<AllowancePercentage>().Delete(AllowancePercentage);
            try
            {
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            
            {

                Console.WriteLine(ex);
            }
            

            return Unit.Value;
        }
    }
}
