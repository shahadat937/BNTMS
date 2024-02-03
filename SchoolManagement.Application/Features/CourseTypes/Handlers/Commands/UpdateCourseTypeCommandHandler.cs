using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.CourseTypes.Requests.Commands;
using SchoolManagement.Application.DTOs.CourseTypes.Validators;

namespace SchoolManagement.Application.Features.CourseTypes.Handlers.Commands
{
    public class UpdateCourseTypeCommandHandler : IRequestHandler<UpdateCourseTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCourseTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCourseTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCourseTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.CourseTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var CourseType = await _unitOfWork.Repository<CourseType>().Get(request.CourseTypeDto.CourseTypeId);

            if (CourseType is null)
                throw new NotFoundException(nameof(CourseType), request.CourseTypeDto.CourseTypeId);

            _mapper.Map(request.CourseTypeDto, CourseType);

            await _unitOfWork.Repository<CourseType>().Update(CourseType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
