using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.UniversityCourseResults.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.UniversityCourseResults.Handlers.Commands
{
    public class DeleteUniversityCourseResultCommandHandler : IRequestHandler<DeleteUniversityCourseResultCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteUniversityCourseResultCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteUniversityCourseResultCommand request, CancellationToken cancellationToken)
        {
            var UniversityCourseResult = await _unitOfWork.Repository<UniversityCourseResult>().Get(request.UniversityCourseResultId);

            if (UniversityCourseResult == null)
                throw new NotFoundException(nameof(UniversityCourseResult), request.UniversityCourseResultId);

            await _unitOfWork.Repository<UniversityCourseResult>().Delete(UniversityCourseResult);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
