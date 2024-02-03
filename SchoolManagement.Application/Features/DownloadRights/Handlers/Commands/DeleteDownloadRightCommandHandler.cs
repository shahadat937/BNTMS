using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DownloadRights.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.DownloadRights.Handlers.Commands
{
    public class DeleteDownloadRightCommandHandler : IRequestHandler<DeleteDownloadRightCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDownloadRightCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDownloadRightCommand request, CancellationToken cancellationToken)
        {
            var DownloadRight = await _unitOfWork.Repository<DownloadRight>().Get(request.DownloadRightId);

            if (DownloadRight == null)
                throw new NotFoundException(nameof(DownloadRight), request.DownloadRightId);

            await _unitOfWork.Repository<DownloadRight>().Delete(DownloadRight);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
