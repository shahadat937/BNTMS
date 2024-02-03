using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseNomenees.Validators;
using SchoolManagement.Application.Features.CourseNomenees.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseNomenees.Handlers.Commands
{
    public class CreateCourseNomeneeCommandHandler : IRequestHandler<CreateCourseNomeneeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCourseNomeneeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCourseNomeneeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCourseNomeneeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CourseNomeneeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
            
                var CourseNomenee = _mapper.Map<CourseNomenee>(request.CourseNomeneeDto);

                CourseNomenee = await _unitOfWork.Repository<CourseNomenee>().Add(CourseNomenee);
              //  CourseNomenee.MarkEntryStatus = 0;
             
                await _unitOfWork.Save();
            
                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CourseNomenee.CourseNomeneeId;
            }

            return response;
        }
    }
}
