using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CoCurricularActivities.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CoCurricularActivities.Handlers.Commands
{
    public class DeleteCoCurricularActivityCommandHandler : IRequestHandler<DeleteCoCurricularActivityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCoCurricularActivityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCoCurricularActivityCommand request, CancellationToken cancellationToken)
        {
            var CoCurricularActivity = await _unitOfWork.Repository<CoCurricularActivity>().Get(request.CoCurricularActivityId);

            if (CoCurricularActivity == null)
                throw new NotFoundException(nameof(CoCurricularActivity), request.CoCurricularActivityId);

            await _unitOfWork.Repository<CoCurricularActivity>().Delete(CoCurricularActivity);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
