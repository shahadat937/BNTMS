using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Department;
using SchoolManagement.Application.Features.Departments.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Departments.Handlers.Queries
{
    public class GetDepartmentDetailRequestHandler: IRequestHandler<GetDepartmentDetailRequest, DepartmentDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Department> _DepartmentRepository;
        public GetDepartmentDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Department> DepartmentRepository, IMapper mapper)
        {
            _DepartmentRepository = DepartmentRepository;
            _mapper = mapper;
        }
        public async Task<DepartmentDto> Handle(GetDepartmentDetailRequest request, CancellationToken cancellationToken)
        {
            var Department = await _DepartmentRepository.Get(request.DepartmentId);
            return _mapper.Map<DepartmentDto>(Department);
        }
    }
}
