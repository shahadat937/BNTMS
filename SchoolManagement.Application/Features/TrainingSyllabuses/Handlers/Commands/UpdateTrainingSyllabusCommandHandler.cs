using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.TrainingSyllabus.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TrainingSyllabuss.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TrainingSyllabuss.Handlers.Commands
{
    public class UpdateTrainingSyllabusCommandHandler : IRequestHandler<UpdateTrainingSyllabusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTrainingSyllabusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTrainingSyllabusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTrainingSyllabusDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.TrainingSyllabusDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var TrainingSyllabus = await _unitOfWork.Repository<TrainingSyllabus>().Get(request.TrainingSyllabusDto.TrainingSyllabusId);

            if (TrainingSyllabus is null)
                throw new NotFoundException(nameof(TrainingSyllabus), request.TrainingSyllabusDto.TrainingSyllabusId);

            _mapper.Map(request.TrainingSyllabusDto, TrainingSyllabus);

            await _unitOfWork.Repository<TrainingSyllabus>().Update(TrainingSyllabus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
