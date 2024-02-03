using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CoursePlans.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CoursePlans.Handlers.Commands
{
    public class DeleteCoursePlanCommandHandler : IRequestHandler<DeleteCoursePlanCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCoursePlanCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCoursePlanCommand request, CancellationToken cancellationToken)
        {
            var CoursePlan = await _unitOfWork.Repository<CoursePlanCreate>().Get(request.CoursePlanCreateId);

            if (CoursePlan == null)
                throw new NotFoundException(nameof(CoursePlan), request.CoursePlanCreateId);

            await _unitOfWork.Repository<CoursePlanCreate>().Delete(CoursePlan); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
