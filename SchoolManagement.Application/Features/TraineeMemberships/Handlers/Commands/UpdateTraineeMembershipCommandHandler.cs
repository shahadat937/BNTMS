using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeMembership.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeMemberships.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeMemberships.Handlers.Commands
{
    public class UpdateTraineeMembershipCommandHandler : IRequestHandler<UpdateTraineeMembershipCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTraineeMembershipCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTraineeMembershipCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTraineeMembershipDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TraineeMembershipDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var TraineeMemberships = await _unitOfWork.Repository<TraineeMembership>().Get(request.TraineeMembershipDto.TraineeMembershipId);

            if (TraineeMemberships is null)
                throw new NotFoundException(nameof(TraineeMembership), request.TraineeMembershipDto.TraineeMembershipId);

            _mapper.Map(request.TraineeMembershipDto, TraineeMemberships);

            await _unitOfWork.Repository<TraineeMembership>().Update(TraineeMemberships);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
