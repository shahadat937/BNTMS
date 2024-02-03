using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.FamilyNomination;
using SchoolManagement.Application.Features.FamilyNominations.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Application.Features.FamilyNominations.Handlers.Queries
{
    public class GetFamilyNominationListRequestHandler : IRequestHandler<GetFamilyNominationListRequest, PagedResult<FamilyNominationDto>>
    { 

        private readonly ISchoolManagementRepository<FamilyNomination> _familyNominationRepository;    

        private readonly IMapper _mapper;  
         
        public GetFamilyNominationListRequestHandler(ISchoolManagementRepository<FamilyNomination> familyNominationRepository, IMapper mapper)
        {
            _familyNominationRepository = familyNominationRepository; 
            _mapper = mapper;  
        }

        public async Task<PagedResult<FamilyNominationDto>> Handle(GetFamilyNominationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString());

            IQueryable<FamilyNomination> FamilyNominations = _familyNominationRepository.FilterWithInclude(x => String.IsNullOrEmpty(request.QueryParams.SearchText), "RelationType");
            var totalCount = FamilyNominations.Count();
            FamilyNominations = FamilyNominations.OrderByDescending(x => x.FamilyNominationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
            var xyz = FamilyNominations.ToList();
            try
            {
                var FamilyNominationsDtos = _mapper.Map<List<FamilyNominationDto>>(FamilyNominations);
                var result = new PagedResult<FamilyNominationDto>(FamilyNominationsDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);
                return result;
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


            return null;
            
        }
    }
}
