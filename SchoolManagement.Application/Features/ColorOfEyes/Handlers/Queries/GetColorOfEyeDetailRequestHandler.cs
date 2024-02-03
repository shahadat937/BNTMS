using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ColorOfEye;
using SchoolManagement.Application.Features.ColorOfEyes.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ColorOfEyes.Handlers.Queries
{
    public class GetColorOfEyeDetailRequestHandler : IRequestHandler<GetColorOfEyeDetailRequest, ColorOfEyeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ColorOfEye> _ColorOfEyeRepository;
        public GetColorOfEyeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ColorOfEye> ColorOfEyeRepository, IMapper mapper)
        {
            _ColorOfEyeRepository = ColorOfEyeRepository;
            _mapper = mapper;
        }
        public async Task<ColorOfEyeDto> Handle(GetColorOfEyeDetailRequest request, CancellationToken cancellationToken)
        {
            var ColorOfEye = await _ColorOfEyeRepository.Get(request.ColorOfEyesId);
            return _mapper.Map<ColorOfEyeDto>(ColorOfEye);
        }
    }
}
