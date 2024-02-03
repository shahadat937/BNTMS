using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseNames.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseNames.Handlers.Commands
{
    public class DeleteCourseNameCommandHandler : IRequestHandler<DeleteCourseNameCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCourseNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCourseNameCommand request, CancellationToken cancellationToken)
        {
            var CourseName = await _unitOfWork.Repository<CourseName>().Get(request.CourseNameId);

            if (CourseName == null)
                throw new NotFoundException(nameof(CourseName), request.CourseNameId);

            await _unitOfWork.Repository<CourseName>().Delete(CourseName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
