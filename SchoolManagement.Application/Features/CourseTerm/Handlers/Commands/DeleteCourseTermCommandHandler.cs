using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseTerms.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseTerms.Handlers.Commands
{
    public class DeleteCourseTermCommandHandler : IRequestHandler<DeleteCourseTermCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCourseTermCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCourseTermCommand request, CancellationToken cancellationToken)
        {
            var CourseTerm = await _unitOfWork.Repository<CourseTerm>().Get(request.CourseTermId);

            if (CourseTerm == null)
                throw new NotFoundException(nameof(CourseTerm), request.CourseTermId);

            await _unitOfWork.Repository<CourseTerm>().Delete(CourseTerm);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
