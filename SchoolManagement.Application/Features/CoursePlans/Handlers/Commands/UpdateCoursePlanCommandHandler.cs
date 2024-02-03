using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.CoursePlan.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.CoursePlans.Requests.Commands;

namespace SchoolManagement.Application.Features.CoursePlans.Handlers.Commands
{
    public class UpdateCoursePlanCommandHandler : IRequestHandler<UpdateCoursePlanCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCoursePlanCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCoursePlanCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCoursePlanDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.CoursePlanDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            //var CoursePlan = await _unitOfWork.Repository<CoursePlanCreate>().Get(request.CoursePlanDto.CoursePlanCreateId);

            //if (CoursePlan is null)
            //    throw new NotFoundException(nameof(CoursePlan), request.CoursePlanDto.CoursePlanCreateId);

            //_mapper.Map(request.CoursePlanDto, CoursePlan);

            //await _unitOfWork.Repository<CoursePlanCreate>().Update(CoursePlan);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
