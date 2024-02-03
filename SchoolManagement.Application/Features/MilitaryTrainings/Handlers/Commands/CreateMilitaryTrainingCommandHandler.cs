using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MilitaryTraining.Validators;
using SchoolManagement.Application.Features.MilitaryTrainings.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MilitaryTrainings.Handlers.Commands   
{
    public class CreateMilitaryTrainingCommandHandler : IRequestHandler<CreateMilitaryTrainingCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public CreateMilitaryTrainingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateMilitaryTrainingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateMilitaryTrainingDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.MilitaryTrainingDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var MilitaryTraining = _mapper.Map<MilitaryTraining>(request.MilitaryTrainingDto); 

                MilitaryTraining = await _unitOfWork.Repository<MilitaryTraining>().Add(MilitaryTraining);
                //await _unitOfWork.Save();
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
                response.Id = MilitaryTraining.MilitaryTrainingId;
            }

            return response;
        }
    }
}
