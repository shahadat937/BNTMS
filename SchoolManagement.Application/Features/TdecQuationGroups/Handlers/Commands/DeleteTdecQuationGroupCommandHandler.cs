using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TdecQuationGroups.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TdecQuationGroups.Handlers.Commands
{
    public class DeleteTdecQuationGroupCommandHandler : IRequestHandler<DeleteTdecQuationGroupCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTdecQuationGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTdecQuationGroupCommand request, CancellationToken cancellationToken)
        {
            var TdecQuationGroup = await _unitOfWork.Repository<TdecQuationGroup>().Get(request.TdecQuationGroupId);

            if (TdecQuationGroup == null)
                throw new NotFoundException(nameof(TdecQuationGroup), request.TdecQuationGroupId);

            await _unitOfWork.Repository<TdecQuationGroup>().Delete(TdecQuationGroup);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
