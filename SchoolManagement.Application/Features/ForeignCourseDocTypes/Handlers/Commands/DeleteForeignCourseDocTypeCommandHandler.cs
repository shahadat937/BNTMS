using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ForeignCourseDocTypes.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForeignCourseDocTypes.Handlers.Commands
{
    public class DeleteForeignCourseDocTypeCommandHandler : IRequestHandler<DeleteForeignCourseDocTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteForeignCourseDocTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteForeignCourseDocTypeCommand request, CancellationToken cancellationToken)
        {
            var ForeignCourseDocType = await _unitOfWork.Repository<ForeignCourseDocType>().Get(request.ForeignCourseDocTypeId);

            if (ForeignCourseDocType == null)
                throw new NotFoundException(nameof(ForeignCourseDocType), request.ForeignCourseDocTypeId);

            await _unitOfWork.Repository<ForeignCourseDocType>().Delete(ForeignCourseDocType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
