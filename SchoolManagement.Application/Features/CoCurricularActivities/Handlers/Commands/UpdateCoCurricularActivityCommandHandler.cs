using AutoMapper;
using SchoolManagement.Application.DTOs.CoCurricularActivity.Validators;
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
    public class UpdateCoCurricularActivityCommandHandler : IRequestHandler<UpdateElectionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCoCurricularActivityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateElectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCoCurricularActivityDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CoCurricularActivityDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var CoCurricularActivity = await _unitOfWork.Repository<CoCurricularActivity>().Get(request.CoCurricularActivityDto.CoCurricularActivityId);

            if (CoCurricularActivity is null)
                throw new NotFoundException(nameof(CoCurricularActivity), request.CoCurricularActivityDto.CoCurricularActivityId);

            _mapper.Map(request.CoCurricularActivityDto, CoCurricularActivity);

            await _unitOfWork.Repository<CoCurricularActivity>().Update(CoCurricularActivity);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
