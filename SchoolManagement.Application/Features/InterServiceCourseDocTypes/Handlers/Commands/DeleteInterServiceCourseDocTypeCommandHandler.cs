using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.InterServiceCourseDocTypes.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InterServiceCourseDocTypes.Handlers.Commands
{
    public class DeleteInterServiceCourseDocTypeCommandHandler : IRequestHandler<DeleteInterServiceCourseDocTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteInterServiceCourseDocTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteInterServiceCourseDocTypeCommand request, CancellationToken cancellationToken)
        {
            var InterServiceCourseDocType = await _unitOfWork.Repository<InterServiceCourseDocType>().Get(request.InterServiceCourseDocTypeId);

            if (InterServiceCourseDocType == null)
                throw new NotFoundException(nameof(InterServiceCourseDocType), request.InterServiceCourseDocTypeId);

            await _unitOfWork.Repository<InterServiceCourseDocType>().Delete(InterServiceCourseDocType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
