using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Branchs.Requests.Commands;
using SchoolManagement.Application.Features.EducationalInstitutions.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.EducationalInstitutions.Handlers.Commands  
{ 
    public class DeleteEducationalInstitutionCommandHandler : IRequestHandler<DeleteEducationalInstitutionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public DeleteEducationalInstitutionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(DeleteEducationalInstitutionCommand request, CancellationToken cancellationToken)
        {  
            var EducationalInstitution = await _unitOfWork.Repository<EducationalInstitution>().Get(request.Id);

            if (EducationalInstitution == null)  
                throw new NotFoundException(nameof(EducationalInstitution), request.Id);
             
            await _unitOfWork.Repository<EducationalInstitution>().Delete(EducationalInstitution); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}