using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ForeignCourseGOInfos.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForeignCourseGOInfos.Handlers.Commands
{
    public class DeleteForeignCourseGOInfoCommandHandler : IRequestHandler<DeleteForeignCourseGOInfoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteForeignCourseGOInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteForeignCourseGOInfoCommand request, CancellationToken cancellationToken)
        {
            var ForeignCourseGOInfo = await _unitOfWork.Repository<ForeignCourseGOInfo>().Get(request.ForeignCourseGOInfoId);

            if (ForeignCourseGOInfo == null)
                throw new NotFoundException(nameof(ForeignCourseGOInfo), request.ForeignCourseGOInfoId);

            await _unitOfWork.Repository<ForeignCourseGOInfo>().Delete(ForeignCourseGOInfo);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
