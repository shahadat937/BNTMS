﻿using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CoursePlans.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CoursePlans.Handlers.Commands
{
    public class ActivateCoursePlanCommandHandler : IRequestHandler<ActivateCoursePlanCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public ActivateCoursePlanCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ActivateCoursePlanCommand request, CancellationToken cancellationToken)
        {
            var CoursePlan = await _unitOfWork.Repository<CoursePlanCreate>().Get(request.CoursePlanCreateId);
            CoursePlan.IsActive = true;

            if (CoursePlan == null)
                throw new NotFoundException(nameof(CoursePlan), request.CoursePlanCreateId);

            await _unitOfWork.Repository<CoursePlanCreate>().Update(CoursePlan);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
