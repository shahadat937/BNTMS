using AutoMapper;
using SchoolManagement.Application.DTOs.ClassRoutine.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Commands
{
    public class UpdateClassRoutineCommandHandler : IRequestHandler<UpdateClassRoutineCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateClassRoutineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateClassRoutineCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateClassRoutineDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ClassRoutineDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ClassRoutines = await _unitOfWork.Repository<ClassRoutine>().Get(request.ClassRoutineDto.ClassRoutineId);

            if (ClassRoutines is null)
                throw new NotFoundException(nameof(ClassRoutine), request.ClassRoutineDto.ClassRoutineId);

            try
            {
                _mapper.Map(request.ClassRoutineDto, ClassRoutines);

                await _unitOfWork.Repository<ClassRoutine>().Update(ClassRoutines);
                await _unitOfWork.Save();

               
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return Unit.Value;
        }
    }
}
