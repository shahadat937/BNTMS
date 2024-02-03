using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseGradingEntrys.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseGradingEntrys.Handlers.Commands
{
    public class DeleteCourseGradingEntryCommandHandler : IRequestHandler<DeleteCourseGradingEntryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCourseGradingEntryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCourseGradingEntryCommand request, CancellationToken cancellationToken)
        {
            var CourseGradingEntry = await _unitOfWork.Repository<CourseGradingEntry>().Get(request.CourseGradingEntryId);

            if (CourseGradingEntry == null)
                throw new NotFoundException(nameof(CourseGradingEntry), request.CourseGradingEntryId);

            await _unitOfWork.Repository<CourseGradingEntry>().Delete(CourseGradingEntry);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
