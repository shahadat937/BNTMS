using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TraineeCourseStatus.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeCourseStatuses.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeCourseStatuses.Handlers.Commands
{
    public class UpdateTraineeCourseStatusCommandHandler : IRequestHandler<UpdateTraineeCourseStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateTraineeCourseStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(UpdateTraineeCourseStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTraineeCourseStatusDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.TraineeCourseStatusDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 
             
            var TraineeCourseStatus = await _unitOfWork.Repository<TraineeCourseStatus>().Get(request.TraineeCourseStatusDto.TraineeCourseStatusId); 

            if (TraineeCourseStatus is null)  
                throw new NotFoundException(nameof(TraineeCourseStatus), request.TraineeCourseStatusDto.TraineeCourseStatusId); 

            _mapper.Map(request.TraineeCourseStatusDto, TraineeCourseStatus);  

            await _unitOfWork.Repository<TraineeCourseStatus>().Update(TraineeCourseStatus); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}