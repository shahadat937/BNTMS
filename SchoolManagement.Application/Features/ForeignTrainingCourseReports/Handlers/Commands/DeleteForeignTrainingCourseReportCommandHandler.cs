using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ForeignTrainingCourseReports.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForeignTrainingCourseReports.Handlers.Commands
{
    public class DeleteForeignTrainingCourseReportCommandHandler : IRequestHandler<DeleteForeignTrainingCourseReportCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteForeignTrainingCourseReportCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteForeignTrainingCourseReportCommand request, CancellationToken cancellationToken)
        {
            var ForeignTrainingCourseReport = await _unitOfWork.Repository<ForeignTrainingCourseReport>().Get(request.ForeignTrainingCourseReportid);

            if (ForeignTrainingCourseReport == null)
                throw new NotFoundException(nameof(ForeignTrainingCourseReport), request.ForeignTrainingCourseReportid);

            await _unitOfWork.Repository<ForeignTrainingCourseReport>().Delete(ForeignTrainingCourseReport);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
