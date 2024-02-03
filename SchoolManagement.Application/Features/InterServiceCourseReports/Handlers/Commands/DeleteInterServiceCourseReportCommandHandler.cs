using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.InterServiceCourseReports.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InterServiceCourseReports.Handlers.Commands
{
    public class DeleteInterServiceCourseReportCommandHandler : IRequestHandler<DeleteInterServiceCourseReportCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteInterServiceCourseReportCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteInterServiceCourseReportCommand request, CancellationToken cancellationToken)
        {
            var InterServiceCourseReport = await _unitOfWork.Repository<InterServiceCourseReport>().Get(request.InterServiceCourseReportid);

            if (InterServiceCourseReport == null)
                throw new NotFoundException(nameof(InterServiceCourseReport), request.InterServiceCourseReportid);

            await _unitOfWork.Repository<InterServiceCourseReport>().Delete(InterServiceCourseReport);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
