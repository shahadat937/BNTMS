using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaSemester;
using SchoolManagement.Application.Features.BnaSemesters.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaSemesters.Handlers.Queries
{
    public class GetBnaSemesterDetailRequestHandler: IRequestHandler<GetBnaSemesterDetailRequest, BnaSemesterDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BnaSemester> _BnaSemesterRepository;
        public GetBnaSemesterDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.BnaSemester> BnaSemesterRepository, IMapper mapper)
        {
            _BnaSemesterRepository = BnaSemesterRepository;
            _mapper = mapper;
        }
        public async Task<BnaSemesterDto> Handle(GetBnaSemesterDetailRequest request, CancellationToken cancellationToken)
        {
            var BnaSemester = await _BnaSemesterRepository.Get(request.BnaSemesterId);
            return _mapper.Map<BnaSemesterDto>(BnaSemester);
        }
    }
}
