using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseNomenees.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseNomenees.Handlers.Commands
{
    public class DeleteCourseNomeneeCommandHandler : IRequestHandler<DeleteCourseNomeneeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCourseNomeneeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCourseNomeneeCommand request, CancellationToken cancellationToken)
        {
            var CourseNomenee = await _unitOfWork.Repository<CourseNomenee>().Get(request.CourseNomeneeId);

            if (CourseNomenee == null)
                throw new NotFoundException(nameof(CourseNomenee), request.CourseNomeneeId);

            await _unitOfWork.Repository<CourseNomenee>().Delete(CourseNomenee);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
