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
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.TraineeMemberships.Handlers.Commands
{
    public class CreateTraineeMembershipCommandHandler : IRequestHandler<CreateTraineeMembershipCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTraineeMembershipCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTraineeMembershipCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTraineeMembershipDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TraineeMembershipDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var TraineeMemberships = _mapper.Map<TraineeMembership>(request.TraineeMembershipDto);

                TraineeMemberships = await _unitOfWork.Repository<TraineeMembership>().Add(TraineeMemberships);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = TraineeMemberships.TraineeMembershipId;
            }

            return response;
        }
    }
}
