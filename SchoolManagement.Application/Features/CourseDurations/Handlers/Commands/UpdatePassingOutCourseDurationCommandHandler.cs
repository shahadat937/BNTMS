using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseDurations.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseDurations.Requests.Commands;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Commands
{
    public class UpdatePassingOutCourseDurationCommandHandler : IRequestHandler<UpdatePassingOutCourseDurationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CourseDuration> _courseDuration;
        public UpdatePassingOutCourseDurationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ISchoolManagementRepository<Domain.CourseDuration> courseDuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _courseDuration = courseDuration;
        }
        public async Task<Unit> Handle(UpdatePassingOutCourseDurationCommand request, CancellationToken cancellationToken)
        {
           
            DateTime today = DateTime.Today;

            var CourseDurations = _courseDuration.FilterWithInclude(x => x.CourseTypeId == request.CoureseTypeId && x.DurationTo < today && x.IsCompletedStatus == 0);

            if (CourseDurations != null) {

                foreach (var courseDuration in CourseDurations)
                {
                    courseDuration.IsCompletedStatus = 1;
                    await _unitOfWork.Repository<SchoolManagement.Domain.CourseDuration>().Update(courseDuration);                  
                }

                await _unitOfWork.Save();

            }

            return Unit.Value;

        }
    }
}
