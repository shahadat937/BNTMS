using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.SwimmingDrivingLevels.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SwimmingDrivingLevels.Handlers.Commands
{
    public class DeleteSwimmingDrivingLevelCommandHandler : IRequestHandler<DeleteSwimmingDrivingLevelCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSwimmingDrivingLevelCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSwimmingDrivingLevelCommand request, CancellationToken cancellationToken)
        {
            var SwimmingDrivingLevels = await _unitOfWork.Repository<SwimmingDrivingLevel>().Get(request.SwimmingDrivingLevelId);

            if (SwimmingDrivingLevels == null)
                throw new NotFoundException(nameof(SwimmingDrivingLevel), request.SwimmingDrivingLevelId);

            await _unitOfWork.Repository<SwimmingDrivingLevel>().Delete(SwimmingDrivingLevels);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
