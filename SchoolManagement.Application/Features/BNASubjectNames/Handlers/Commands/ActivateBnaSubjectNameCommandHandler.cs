using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Commands;
using SchoolManagement.Application.Features.CourseDurations.Requests.Commands;
using SchoolManagement.Application.Features.CoursePlans.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CoursePlans.Handlers.Commands
{
    public class ActivateBnaSubjectNameCommandHandler : IRequestHandler<ActivateBnaSubjectNameCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<BnaSubjectName> _BnaSubjectNameRepository;

        public ActivateBnaSubjectNameCommandHandler(ISchoolManagementRepository<BnaSubjectName> BnaSubjectNameRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _BnaSubjectNameRepository = BnaSubjectNameRepository;
        }
        public async Task<Unit> Handle(ActivateBnaSubjectNameCommand request, CancellationToken cancellationToken)
        {
            var BnaSubjectName = await _unitOfWork.Repository<BnaSubjectName>().Get(request.BnaSubjectNameId);
           
            if(BnaSubjectName.SubjectActiveStatus == 0)
            {
                BnaSubjectName.SubjectActiveStatus = 1;
            }
            else 
            {
                BnaSubjectName.SubjectActiveStatus = 0;
            }

            await _unitOfWork.Repository<BnaSubjectName>().Update(BnaSubjectName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
