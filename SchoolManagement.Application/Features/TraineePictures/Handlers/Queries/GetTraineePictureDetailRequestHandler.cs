using AutoMapper;
using SchoolManagement.Application.DTOs.TraineePicture;
using SchoolManagement.Application.Features.TraineePictures.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineePictures.Handlers.Queries
{
    public class GetTraineePictureDetailRequestHandler : IRequestHandler<GetTraineePictureDetailRequest, TraineePictureDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineePicture> _TraineePictureRepository;
        public GetTraineePictureDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineePicture> TraineePictureRepository, IMapper mapper)
        {
            _TraineePictureRepository = TraineePictureRepository;
            _mapper = mapper;
        }
        public async Task<TraineePictureDto> Handle(GetTraineePictureDetailRequest request, CancellationToken cancellationToken)
        {
            var TraineePicture = await _TraineePictureRepository.FindOneAsync(x => x.TraineePictureId == request.TraineePictureId);
            return _mapper.Map<TraineePictureDto>(TraineePicture);
        }
    }
}
