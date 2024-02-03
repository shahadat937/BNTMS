using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeBioDataOther.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeBioDataOthers.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeBioDataOthers.Handlers.Commands
{
    public class UpdateTraineeBioDataOtherCommandHandler : IRequestHandler<UpdateTraineeBioDataOtherCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTraineeBioDataOtherCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTraineeBioDataOtherCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTraineeBioDataOtherDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TraineeBioDataOtherDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var TraineeBioDataOther = await _unitOfWork.Repository<TraineeBioDataOther>().Get(request.TraineeBioDataOtherDto.TraineeBioDataOtherId);

            if (TraineeBioDataOther is null)
                throw new NotFoundException(nameof(TraineeBioDataOther), request.TraineeBioDataOtherDto.TraineeBioDataOtherId);

            _mapper.Map(request.TraineeBioDataOtherDto, TraineeBioDataOther);


            await _unitOfWork.Repository<TraineeBioDataOther>().Update(TraineeBioDataOther);

            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
