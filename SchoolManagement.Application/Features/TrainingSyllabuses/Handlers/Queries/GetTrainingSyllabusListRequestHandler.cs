using SchoolManagement.Application.Features.TrainingSyllabuss.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TrainingSyllabus;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

using System.Text;


namespace SchoolManagement.Application.Features.TrainingSyllabuss.Handlers.Queries
{
    public class GetTrainingSyllabusListRequestHandler : IRequestHandler<GetTrainingSyllabusListRequest, PagedResult<TrainingSyllabusDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TrainingSyllabus> _TrainingSyllabusRepository;

        private readonly IMapper _mapper;

        public GetTrainingSyllabusListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TrainingSyllabus> TrainingSyllabusRepository, IMapper mapper)
        {
            _TrainingSyllabusRepository = TrainingSyllabusRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TrainingSyllabusDto>> Handle(GetTrainingSyllabusListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.TrainingSyllabus> TrainingSyllabuss = _TrainingSyllabusRepository.FilterWithInclude(x =>  String.IsNullOrEmpty(request.QueryParams.SearchText));
            var totalCount = TrainingSyllabuss.Count();
            TrainingSyllabuss = TrainingSyllabuss.OrderByDescending(x => x.TrainingSyllabusId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var TrainingSyllabusDtos = _mapper.Map<List<TrainingSyllabusDto>>(TrainingSyllabuss);
            var result = new PagedResult<TrainingSyllabusDto>(TrainingSyllabusDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
