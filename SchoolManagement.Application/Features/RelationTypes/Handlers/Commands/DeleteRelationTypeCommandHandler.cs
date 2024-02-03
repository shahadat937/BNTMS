using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.RelationTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.RelationTypes.Handlers.Commands
{
    public class DeleteRelationTypeCommandHandler : IRequestHandler<DeleteRelationTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteRelationTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteRelationTypeCommand request, CancellationToken cancellationToken)
        {
            var RelationType = await _unitOfWork.Repository<RelationType>().Get(request.RelationTypeId);

            if (RelationType == null)
                throw new NotFoundException(nameof(RelationType), request.RelationTypeId);

            await _unitOfWork.Repository<RelationType>().Delete(RelationType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
