using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.BnaSemester.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaSemesters.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text; 
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaSemesters.Handlers.Commands
{
    public class UpdateBnaSemesterCommandHandler: IRequestHandler<UpdateBnaSemesterCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBnaSemesterCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBnaSemesterCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBnaSemesterDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.BnaSemesterDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BnaSemester = await _unitOfWork.Repository<BnaSemester>().Get(request.BnaSemesterDto.BnaSemesterId);

            if (BnaSemester is null)
                throw new NotFoundException(nameof(BnaSemester), request.BnaSemesterDto.BnaSemesterId);

            _mapper.Map(request.BnaSemesterDto, BnaSemester);

            await _unitOfWork.Repository<BnaSemester>().Update(BnaSemester);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
