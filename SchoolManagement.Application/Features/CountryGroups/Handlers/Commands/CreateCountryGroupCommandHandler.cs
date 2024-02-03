using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CountryGroup.Validators;
using SchoolManagement.Application.Features.CountryGroups.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CountryGroups.Handlers.Commands
{
    public class CreateCountryGroupCommandHandler : IRequestHandler<CreateCountryGroupCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCountryGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCountryGroupCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCountryGroupDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CountryGroupDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var CountryGroup = _mapper.Map<CountryGroup>(request.CountryGroupDto);

                CountryGroup = await _unitOfWork.Repository<CountryGroup>().Add(CountryGroup);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CountryGroup.CountryGroupId;
            }

            return response;
        }
    }
}
