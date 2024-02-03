using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.InstallmentPaidDetail;
using SchoolManagement.Application.Features.InstallmentPaidDetails.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InstallmentPaidDetails.Handler.Queries
{
    public class GetInstallmentPaidDetailDetailRequestHandler : IRequestHandler<GetInstallmentPaidDetailDetailRequest, InstallmentPaidDetailDto>
    {
        private readonly IMapper _mapper; 
        private readonly ISchoolManagementRepository<InstallmentPaidDetail> _InstallmentPaidDetailRepository;     
        public GetInstallmentPaidDetailDetailRequestHandler(ISchoolManagementRepository<InstallmentPaidDetail> InstallmentPaidDetailRepository, IMapper mapper)
        {
            _InstallmentPaidDetailRepository = InstallmentPaidDetailRepository;  
            _mapper = mapper; 
        }
        public async Task<InstallmentPaidDetailDto> Handle(GetInstallmentPaidDetailDetailRequest request, CancellationToken cancellationToken)
        {
            var InstallmentPaidDetail = await _InstallmentPaidDetailRepository.Get(request.Id);   
            return _mapper.Map<InstallmentPaidDetailDto>(InstallmentPaidDetail);  
        }
    }
}
