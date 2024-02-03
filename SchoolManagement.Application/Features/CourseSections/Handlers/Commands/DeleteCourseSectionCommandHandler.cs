using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseSections.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseSections.Handlers.Commands
{
    public class DeleteCourseSectionCommandHandler : IRequestHandler<DeleteCourseSectionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCourseSectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCourseSectionCommand request, CancellationToken cancellationToken)
        {
            var CourseSections = await _unitOfWork.Repository<CourseSection>().Get(request.CourseSectionId);

            if (CourseSections == null)
                throw new NotFoundException(nameof(CourseSection), request.CourseSectionId);

            await _unitOfWork.Repository<CourseSection>().Delete(CourseSections);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
