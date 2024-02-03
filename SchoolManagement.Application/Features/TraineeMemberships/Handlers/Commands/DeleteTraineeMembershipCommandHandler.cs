using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeMemberships.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeMemberships.Handlers.Commands
{
    public class DeleteTraineeMembershipCommandHandler : IRequestHandler<DeleteTraineeMembershipCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTraineeMembershipCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTraineeMembershipCommand request, CancellationToken cancellationToken)
        {
            var TraineeMemberships = await _unitOfWork.Repository<TraineeMembership>().Get(request.TraineeMembershipId);

            if (TraineeMemberships == null)
                throw new NotFoundException(nameof(TraineeMembership), request.TraineeMembershipId);

            await _unitOfWork.Repository<TraineeMembership>().Delete(TraineeMemberships);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
