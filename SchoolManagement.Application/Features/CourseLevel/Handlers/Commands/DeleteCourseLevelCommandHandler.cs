using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseLevels.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseLevels.Handlers.Commands
{
    public class DeleteCourseLevelCommandHandler : IRequestHandler<DeleteCourseLevelCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCourseLevelCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCourseLevelCommand request, CancellationToken cancellationToken)
        {
            var CourseLevel = await _unitOfWork.Repository<CourseLevel>().Get(request.CourseLevelId);

            if (CourseLevel == null)
                throw new NotFoundException(nameof(CourseLevel), request.CourseLevelId);

            await _unitOfWork.Repository<CourseLevel>().Delete(CourseLevel);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
