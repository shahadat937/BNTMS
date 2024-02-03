using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaPromotionStatuses.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic; 
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaPromotionStatuses.Handlers.Commands
{
    public class DeleteBnaPromotionStatusCommandHandler : IRequestHandler<DeleteBnaPromotionStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBnaPromotionStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBnaPromotionStatusCommand request, CancellationToken cancellationToken)
        {
            var BnaPromotionStatus = await _unitOfWork.Repository<BnaPromotionStatus>().Get(request.BnaPromotionStatusId);

            if (BnaPromotionStatus == null)
                throw new NotFoundException(nameof(BnaPromotionStatus), request.BnaPromotionStatusId);

            await _unitOfWork.Repository<BnaPromotionStatus>().Delete(BnaPromotionStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
