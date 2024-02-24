using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseWeekAll.Requests.Commands;
using SchoolManagement.Application.Features.CourseWeeks.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseWeekAll.Handlers.Commands
{
    public class DeleteCourseWeekAllCommandHandler : IRequestHandler<DeleteCourseWeekAllCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteCourseWeekAllCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteCourseWeekAllCommand request, CancellationToken cancellationToken)
        {
            var CourseWeek = await _unitOfWork.Repository<SchoolManagement.Domain.CourseWeekAll>().Get(request.WeekID);

            if (CourseWeek == null)
                throw new NotFoundException(nameof(CourseWeek), request.WeekID);

            await _unitOfWork.Repository<SchoolManagement.Domain.CourseWeekAll>().Delete(CourseWeek);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
   }
