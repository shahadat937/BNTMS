using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseDurations.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Commands
{
    public class DeleteCourseDurationCommandHandler : IRequestHandler<DeleteCourseDurationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISchoolManagementRepository<CourseDuration> _courseDurationRepository;
        private readonly IMapper _mapper;

        public DeleteCourseDurationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ISchoolManagementRepository<CourseDuration> courseDurationRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _courseDurationRepository = courseDurationRepository;
        }

        public async Task<Unit> Handle(DeleteCourseDurationCommand request, CancellationToken cancellationToken)
        {
            var CourseDuration = await _unitOfWork.Repository<CourseDuration>().Get(request.CourseDurationId);

            if (CourseDuration == null)
                throw new NotFoundException(nameof(CourseDuration), request.CourseDurationId);

            //await _unitOfWork.Repository<CourseDuration>().Delete(CourseDuration);
            //await _unitOfWork.Save();

            var spQuery = $"exec [DeleteCourseDurationForcefullyDynamic] {request.CourseDurationId}";

            try
            {
                // Execute the stored procedure
                _courseDurationRepository.ExecWithSqlQuery(spQuery);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while deleting the course duration.", ex);
            }

            return Unit.Value;
        }
    }
}
