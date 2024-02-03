using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TdecQuestionNames.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TdecQuestionNames.Handlers.Commands
{
    public class DeleteTdecQuestionNameCommandHandler : IRequestHandler<DeleteTdecQuestionNameCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTdecQuestionNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTdecQuestionNameCommand request, CancellationToken cancellationToken)
        {
            var TdecQuestionName = await _unitOfWork.Repository<TdecQuestionName>().Get(request.TdecQuestionNameId);

            if (TdecQuestionName == null)
                throw new NotFoundException(nameof(TdecQuestionName), request.TdecQuestionNameId);

            await _unitOfWork.Repository<TdecQuestionName>().Delete(TdecQuestionName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
