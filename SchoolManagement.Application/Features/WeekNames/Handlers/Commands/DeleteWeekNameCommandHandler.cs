using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.WeekNames.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.WeekNames.Handlers.Commands
{
    public class DeleteWeekNameCommandHandler : IRequestHandler<DeleteWeekNameCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteWeekNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteWeekNameCommand request, CancellationToken cancellationToken)
        {
            var WeekName = await _unitOfWork.Repository<WeekName>().Get(request.WeekNameId);

            if (WeekName == null)
                throw new NotFoundException(nameof(WeekName), request.WeekNameId);

            await _unitOfWork.Repository<WeekName>().Delete(WeekName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
