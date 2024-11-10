using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Commands
{
    public class DeleteMultipleTraineeNominationCommandHandler : IRequestHandler<DeleteMultipleTraineeNominationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMultipleTraineeNominationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DeleteMultipleTraineeNominationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var successCount = 0;
            var errorCount = 0;

            foreach (var item in request.TraineeIds)
            {
                var TraineeNominations = await _unitOfWork.Repository<TraineeNomination>().Get(item);

                if (TraineeNominations == null)
                {
                    errorCount++;
                }
                var traineeBiodata = await _unitOfWork.Repository<TraineeBioDataGeneralInfo>().Get(TraineeNominations.TraineeId ?? 0);
                traineeBiodata.LocalNominationStatus = 0;

                await _unitOfWork.Repository<TraineeBioDataGeneralInfo>().Update(traineeBiodata);
                await _unitOfWork.Repository<TraineeNomination>().Delete(TraineeNominations);

                try
                {
                    await _unitOfWork.Save();
                    successCount++;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("An error occurred while deleting the Nomination.", ex);
                    errorCount++;
                }
            }

            response.Message = $"{successCount} Deleted and {errorCount} Unsuccessfull";

            return response;
        }
    }
}
