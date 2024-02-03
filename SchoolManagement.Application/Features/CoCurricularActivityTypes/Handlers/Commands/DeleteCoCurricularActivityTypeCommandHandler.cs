using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CoCurricularActivityTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CoCurricularActivityTypes.Handlers.Commands
{
    public class DeleteCoCurricularActivityTypeCommandHandler : IRequestHandler<DeleteCoCurricularActivityTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCoCurricularActivityTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCoCurricularActivityTypeCommand request, CancellationToken cancellationToken)
        {
            var CoCurricularActivityType = await _unitOfWork.Repository<CoCurricularActivityType>().Get(request.CoCurricularActivityTypeId);

            if (CoCurricularActivityType == null)
                throw new NotFoundException(nameof(CoCurricularActivityType), request.CoCurricularActivityTypeId);

            await _unitOfWork.Repository<CoCurricularActivityType>().Delete(CoCurricularActivityType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
