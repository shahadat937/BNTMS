using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.DTOs.CourseNomenees.Validators;
using SchoolManagement.Application.Features.CourseNomenees.Requests.Commands;

namespace SchoolManagement.Application.Features.CourseNomenees.Handlers.Commands
{
    public class UpdateCourseNomeneeCommandHandler : IRequestHandler<UpdateCourseNomeneeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCourseNomeneeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCourseNomeneeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCourseNomeneeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.CourseNomeneeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var CourseNomenee = await _unitOfWork.Repository<CourseNomenee>().Get(request.CourseNomeneeDto.CourseNomeneeId);

            if (CourseNomenee is null)
                throw new NotFoundException(nameof(CourseNomenee), request.CourseNomeneeDto.CourseNomeneeId);
          
            _mapper.Map(request.CourseNomeneeDto, CourseNomenee);


            CourseNomenee.CourseName = null;
            await _unitOfWork.Repository<CourseNomenee>().Update(CourseNomenee);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
