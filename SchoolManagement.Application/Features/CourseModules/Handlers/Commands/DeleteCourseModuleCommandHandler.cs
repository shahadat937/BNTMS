using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseModules.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseModules.Handlers.Commands
{
    public class DeleteCourseModuleCommandHandler : IRequestHandler<DeleteCourseModuleCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCourseModuleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCourseModuleCommand request, CancellationToken cancellationToken)
        {
            var CourseModules = await _unitOfWork.Repository<CourseModule>().Get(request.CourseModuleId);

            if (CourseModules == null)
                throw new NotFoundException(nameof(CourseModule), request.CourseModuleId);

            await _unitOfWork.Repository<CourseModule>().Delete(CourseModules);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
