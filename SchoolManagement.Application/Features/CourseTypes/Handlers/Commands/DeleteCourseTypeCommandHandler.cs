using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseTypes.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseTypes.Handlers.Commands
{
    public class DeleteCourseTypeCommandHandler : IRequestHandler<DeleteCourseTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCourseTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCourseTypeCommand request, CancellationToken cancellationToken)
        {
            var CourseType = await _unitOfWork.Repository<CourseType>().Get(request.CourseTypeId);

            if (CourseType == null)
                throw new NotFoundException(nameof(CourseType), request.CourseTypeId);

            await _unitOfWork.Repository<CourseType>().Delete(CourseType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
