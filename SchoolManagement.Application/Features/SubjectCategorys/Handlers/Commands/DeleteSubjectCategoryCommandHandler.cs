using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.SubjectCategorys.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SubjectCategorys.Handlers.Commands
{
    public class DeleteSubjectCategoryCommandHandler : IRequestHandler<DeleteSubjectCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSubjectCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSubjectCategoryCommand request, CancellationToken cancellationToken)
        {
            var SubjectCategory = await _unitOfWork.Repository<SubjectCategory>().Get(request.SubjectCategoryId);

            if (SubjectCategory == null)
                throw new NotFoundException(nameof(SubjectCategory), request.SubjectCategoryId);

            await _unitOfWork.Repository<SubjectCategory>().Delete(SubjectCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
