using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaClassSections.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassSections.Handler.Commands
{
    public class DeleteBnaClassSectionCommandHandler : IRequestHandler<DeleteBnaClassSectionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBnaClassSectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBnaClassSectionCommand request, CancellationToken cancellationToken)
        {
            var BnaClassSection = await _unitOfWork.Repository<BnaClassSectionSelection>().Get(request.Id);

            if (BnaClassSection == null)
                throw new NotFoundException(nameof(BnaClassSection), request.Id);

            await _unitOfWork.Repository<BnaClassSectionSelection>().Delete(BnaClassSection);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}