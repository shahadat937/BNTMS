using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Handlers.Commands
{
    public class DeleteForeignCourseOthersDocumentCommandHandler : IRequestHandler<DeleteForeignCourseOthersDocumentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteForeignCourseOthersDocumentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteForeignCourseOthersDocumentCommand request, CancellationToken cancellationToken)
        {
            var ForeignCourseOthersDocument = await _unitOfWork.Repository<ForeignCourseOthersDocument>().Get(request.ForeignCourseOthersDocumentId);

            if (ForeignCourseOthersDocument == null)
                throw new NotFoundException(nameof(ForeignCourseOthersDocument), request.ForeignCourseOthersDocumentId);

            await _unitOfWork.Repository<ForeignCourseOthersDocument>().Delete(ForeignCourseOthersDocument);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
