using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeNomination.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Commands;
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

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Commands
{
    public class CreateTraineeNominationCommandHandler : IRequestHandler<CreateTraineeNominationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTraineeNominationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTraineeNominationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTraineeNominationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TraineeNominationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var TraineeNominations = _mapper.Map<TraineeNomination>(request.TraineeNominationDto);

                TraineeNominations = await _unitOfWork.Repository<TraineeNomination>().Add(TraineeNominations);

                var traineeBiodata = await _unitOfWork.Repository<TraineeBioDataGeneralInfo>().Get(request.TraineeNominationDto.TraineeId ?? 0);
                traineeBiodata.LocalNominationStatus = 1;

                await _unitOfWork.Repository<TraineeBioDataGeneralInfo>().Update(traineeBiodata);
                try
                {
                    await _unitOfWork.Save();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = TraineeNominations.TraineeNominationId;
            }

            return response;
        }
    }
}
