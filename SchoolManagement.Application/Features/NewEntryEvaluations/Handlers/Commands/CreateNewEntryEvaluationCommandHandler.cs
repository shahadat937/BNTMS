using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.NewEntryEvaluation.Validators;
using SchoolManagement.Application.Features.NewEntryEvaluations.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.NewEntryEvaluations.Handlers.Commands
{
    public class CreateNewEntryEvaluationCommandHandler : IRequestHandler<CreateNewEntryEvaluationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateNewEntryEvaluationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateNewEntryEvaluationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateNewEntryEvaluationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.NewEntryEvaluationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var newEntryEvaluation = request.NewEntryEvaluationDto;

                var traineeList = newEntryEvaluation.TraineeListForm.Select(x => new NewEntryEvaluation()
                {
                   BaseSchoolNameId = newEntryEvaluation.BaseSchoolNameId,
                   CourseNameId = newEntryEvaluation.CourseNameId,
                   CourseModuleId = newEntryEvaluation.CourseModuleId,
                   CourseDurationId = newEntryEvaluation.CourseDurationId,
                   CourseWeekId = newEntryEvaluation.CourseWeekId,
                   TraineeNominationId= x.TraineeNominationId,
                   TraineeId = x.TraineeId,
                   Noitikota= x.Noitikota,
                   Sahonsheelota=x.Sahonsheelota,
                   Utsaho=x.Utsaho,
                   Samayanubartita=x.Samayanubartita,
                   Manovhab=x.Manovhab,
                   Udyam=x.Udyam,
                   KhapKhawano=x.KhapKhawano,
                   Onyano=x.Onyano
                }) ;

                await _unitOfWork.Repository<NewEntryEvaluation>().AddRangeAsync(traineeList);
                await _unitOfWork.Save();

                //var NewEntryEvaluation = _mapper.Map<NewEntryEvaluation>(request.NewEntryEvaluationDto);

                //NewEntryEvaluation = await _unitOfWork.Repository<NewEntryEvaluation>().Add(NewEntryEvaluation);
                //await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                //response.Id = NewEntryEvaluation.NewEntryEvaluationId;
            }

            return response;
        }
    }
}
