using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForeignCourseOtherDocs.Handlers.Commands
{
    public class DeleteForeignCourseOtherDocCommandHandler : IRequestHandler<DeleteForeignCourseOtherDocCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteForeignCourseOtherDocCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteForeignCourseOtherDocCommand request, CancellationToken cancellationToken)
        {
            var ForeignCourseOtherDoc = await _unitOfWork.Repository<ForeignCourseOtherDoc>().Get(request.ForeignCourseOtherDocId);

            if (ForeignCourseOtherDoc == null)
                throw new NotFoundException(nameof(ForeignCourseOtherDoc), request.ForeignCourseOtherDocId);

            await _unitOfWork.Repository<ForeignCourseOtherDoc>().Delete(ForeignCourseOtherDoc);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
