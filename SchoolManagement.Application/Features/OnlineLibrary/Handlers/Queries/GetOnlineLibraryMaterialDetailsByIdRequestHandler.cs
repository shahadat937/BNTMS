using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.OnlineLibrary;
using SchoolManagement.Application.Features.OnlineLibrary.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OnlineLibrary.Handlers.Queries
{
    public class GetOnlineLibraryMaterialDetailsByIdRequestHandler : IRequestHandler<GetOnlineLibraryMaterialDetailsByIdRequest, OnlineLibraryDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.OnlineLibrary> _onlineLibraryRepository;
        public GetOnlineLibraryMaterialDetailsByIdRequestHandler(IMapper mapper, ISchoolManagementRepository<SchoolManagement.Domain.OnlineLibrary> onlineLibraryRepository)
        {
            _onlineLibraryRepository = onlineLibraryRepository;
            _mapper = mapper;
        }
        public async Task<OnlineLibraryDto> Handle(GetOnlineLibraryMaterialDetailsByIdRequest request, CancellationToken cancellationToken)
        {
            var libarryMaterial = _onlineLibraryRepository.FinedOneInclude(x=> x.OnlineLibraryId == request.Id);
            return _mapper.Map<OnlineLibraryDto>(libarryMaterial);
        }
    }
}
