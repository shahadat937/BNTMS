using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.EducationalQualifications.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.EducationalQualifications.Handlers.Commands
{
    public class DeleteEducationalQualificationCommandHandler : IRequestHandler<DeleteEducationalQualificationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteEducationalQualificationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEducationalQualificationCommand request, CancellationToken cancellationToken)
        {
            var EducationalQualification = await _unitOfWork.Repository<EducationalQualification>().Get(request.EducationalQualificationId);

            if (EducationalQualification == null)
                throw new NotFoundException(nameof(EducationalQualification), request.EducationalQualificationId);

            await _unitOfWork.Repository<EducationalQualification>().Delete(EducationalQualification);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
